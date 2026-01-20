using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll.Repositories;
using DAL;

namespace Translations
{
    public partial class ResourceGenerator : BaseClass
    {
        public ResourceGenerator()
        {
            CountryLanguageRepo = new CountryLanguagesRepository(DbContext);
            TranslationKeyRepo = new TranslationKeysRepository(DbContext);
            TranslationRepo = new TranslationsRepository(DbContext);
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            RequireAdmin();
            if (!IsPostBack)
            {
                BindCountryLanguages();
                BindStatistics();
            }
        }

        private void BindCountryLanguages()
        {
            ddlCountryLanguage.Items.Clear();
            foreach (CountryLanguage cl in CountryLanguageRepo.GetAllNonDeleted())
            {
                ddlCountryLanguage.Items.Add(new ListItem(cl.Title, cl.Id.ToString()));
            }
        }

        private void BindStatistics()
        {
            var stats = new List<TranslationStats>();
            var allKeys = TranslationKeyRepo.GetAllNonDeleted().ToList();
            int totalKeys = allKeys.Count;

            foreach (CountryLanguage cl in CountryLanguageRepo.GetAllNonDeleted())
            {
                int translatedCount = 0;
                foreach (var key in allKeys)
                {
                    var translation = TranslationRepo.GetNonDeletedByTranslationKeyIdAndCountryLanguageID(key.Id, cl.Id);
                    if (translation != null && !string.IsNullOrEmpty(translation.Value))
                    {
                        translatedCount++;
                    }
                }

                stats.Add(new TranslationStats
                {
                    CountryLanguage = cl.Title,
                    TotalKeys = totalKeys,
                    TranslatedKeys = translatedCount,
                    PendingKeys = totalKeys - translatedCount,
                    CompletionPercent = totalKeys > 0 ? Math.Round((decimal)translatedCount / totalKeys * 100, 1) + "%" : "0%"
                });
            }

            gvStats.DataSource = stats.OrderByDescending(s => s.TranslatedKeys);
            gvStats.DataBind();
        }

        protected void btnDownloadLanguage_Click(object sender, EventArgs e)
        {
            long countryLanguageId = long.Parse(ddlCountryLanguage.SelectedValue);
            CountryLanguage cl = CountryLanguageRepo.GetNonDeletedById(countryLanguageId);

            if (cl == null) return;

            string filePrefix = string.IsNullOrEmpty(txtFilePrefix.Text) ? "Resources" : txtFilePrefix.Text.Trim();
            string languageCode = GetLanguageCode(cl);
            string fileName = filePrefix + "." + languageCode + ".resx";

            byte[] fileContent = GenerateResxFile(countryLanguageId, chkIncludeEmpty.Checked);

            SendFileToClient(fileContent, fileName, "application/xml");
        }

        protected void btnDownloadGlobal_Click(object sender, EventArgs e)
        {
            string fileName = string.IsNullOrEmpty(txtGlobalFileName.Text) ? "Resources" : txtGlobalFileName.Text.Trim();
            fileName += ".resx";

            byte[] fileContent = GenerateGlobalResxFile();

            SendFileToClient(fileContent, fileName, "application/xml");
        }

        protected void btnDownloadAll_Click(object sender, EventArgs e)
        {
            string filePrefix = string.IsNullOrEmpty(txtFilePrefix.Text) ? "Resources" : txtFilePrefix.Text.Trim();
            string globalFileName = string.IsNullOrEmpty(txtGlobalFileName.Text) ? "Resources" : txtGlobalFileName.Text.Trim();

            using (MemoryStream zipStream = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
                {
                    // Add global resource file
                    byte[] globalContent = GenerateGlobalResxFile();
                    ZipArchiveEntry globalEntry = archive.CreateEntry(globalFileName + ".resx");
                    using (Stream entryStream = globalEntry.Open())
                    {
                        entryStream.Write(globalContent, 0, globalContent.Length);
                    }

                    // Add language-specific resource files
                    foreach (CountryLanguage cl in CountryLanguageRepo.GetAllNonDeleted())
                    {
                        string languageCode = GetLanguageCode(cl);
                        string fileName = filePrefix + "." + languageCode + ".resx";

                        byte[] content = GenerateResxFile(cl.Id, chkIncludeEmpty.Checked);
                        ZipArchiveEntry entry = archive.CreateEntry(fileName);
                        using (Stream entryStream = entry.Open())
                        {
                            entryStream.Write(content, 0, content.Length);
                        }
                    }
                }

                zipStream.Position = 0;
                SendFileToClient(zipStream.ToArray(), "ResourceFiles.zip", "application/zip");
            }
        }

        private byte[] GenerateResxFile(long countryLanguageId, bool includeEmpty)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (ResXResourceWriter resx = new ResXResourceWriter(ms))
                {
                    foreach (TranslationKey key in TranslationKeyRepo.GetAllNonDeleted())
                    {
                        Translation translation = TranslationRepo.GetNonDeletedByTranslationKeyIdAndCountryLanguageID(key.Id, countryLanguageId);

                        string keyName = key.Key;
                        string value = "";

                        if (translation != null && !string.IsNullOrEmpty(translation.Value))
                        {
                            value = translation.Value;
                        }
                        else if (includeEmpty)
                        {
                            // Use English value as fallback
                            value = key.EnglishValue ?? "";
                        }

                        if (!string.IsNullOrEmpty(value))
                        {
                            resx.AddResource(keyName, value);
                        }
                    }

                    resx.Generate();
                }

                return ms.ToArray();
            }
        }

        private byte[] GenerateGlobalResxFile()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (ResXResourceWriter resx = new ResXResourceWriter(ms))
                {
                    foreach (TranslationKey key in TranslationKeyRepo.GetAllNonDeleted())
                    {
                        string keyName = key.Key;
                        string value = key.EnglishValue ?? "";

                        if (!string.IsNullOrEmpty(keyName))
                        {
                            resx.AddResource(keyName, value);
                        }
                    }

                    resx.Generate();
                }

                return ms.ToArray();
            }
        }

        private string GetLanguageCode(CountryLanguage cl)
        {
            // Try to build a proper language code like "en-US", "fr-FR", etc.
            string langCode = cl.Language?.Code ?? "en";
            string countryCode = cl.Country?.ISOCode ?? "";

            if (!string.IsNullOrEmpty(countryCode))
            {
                return langCode.ToLower() + "-" + countryCode.ToUpper();
            }

            return langCode.ToLower();
        }

        private void SendFileToClient(byte[] content, string fileName, string contentType)
        {
            Response.Clear();
            Response.ContentType = contentType;
            Response.AddHeader("Content-Disposition", "attachment; filename=\"" + fileName + "\"");
            Response.AddHeader("Content-Length", content.Length.ToString());
            Response.BinaryWrite(content);
            Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        private class TranslationStats
        {
            public string CountryLanguage { get; set; }
            public int TotalKeys { get; set; }
            public int TranslatedKeys { get; set; }
            public int PendingKeys { get; set; }
            public string CompletionPercent { get; set; }
        }
    }
}
