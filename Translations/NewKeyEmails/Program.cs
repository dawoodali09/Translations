using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bll.Repositories;
using DAL;
using System.IO;
using System.Web;

namespace NewKeyEmails
{
    class Program
    {

        static void Main(string[] args)
        {
            #region Send daily created keys only
            //Entities DbContext = new Entities();
            //TranslationKeysRepository TranslationKeyRepo =new TranslationKeysRepository(DbContext);
            //TranslatorsRepository TranslatorRepo = new TranslatorsRepository(DbContext);


            //IEnumerable<TranslationKey> obj = new List<TranslationKey>();
            //obj = TranslationKeyRepo.GetNewNonDeletedKeys();
            //foreach (Translator t in TranslatorRepo.GetAllNonDeleted())
            //{
            //    StringBuilder template = new StringBuilder();
            //    string body = string.Empty;
            //    StreamReader sr = new StreamReader(@"..\\..\\..\\Utility\\Templates\\NewKeyEmail.txt");
            //    template.Append(sr.ReadToEnd());
            //    sr.Close();
            //    body = template.ToString();
            //    body = body.Replace("#NAME#", (t.FirstName + " " + t.LastName));
            //    StringBuilder sb = new StringBuilder();
            //    foreach (TranslationKey key in TranslationKeyRepo.GetNewNonDeletedKeys())
            //    {
            //        sb.Append(key.Key + "<br><br>");
            //    }
            //    body = body.Replace("#KEYS#", sb.ToString());
            //    //Utility.StaticFunctions.SendMail("admin@translations.local", body, "New Translations added");
            //    Utility.StaticFunctions.SendMail(t.EmailAddress, body, "New Translations added");
            //}

            #endregion





            #region SendAllRemainingRequiredTranslations
            Entities DbContext = new Entities();
            TranslationKeysRepository TranslationKeyRepo = new TranslationKeysRepository(DbContext);
            TranslatorsRepository TranslatorRepo = new TranslatorsRepository(DbContext);
            CountryLanguagesRepository CountryLanguageRepo = new CountryLanguagesRepository(DbContext);
            TranslatorCountryLanguagesRepository TranslatorCountryLanguageRepo = new TranslatorCountryLanguagesRepository(DbContext);
            TranslationsRepository TranslationRepo = new TranslationsRepository(DbContext);


            //IEnumerable<TranslationKey> obj = new List<TranslationKey>();
            //obj = TranslationKeyRepo.GetNewNonDeletedKeys();
            foreach (Translator t in TranslatorRepo.GetAllNonDeleted())
            {
                StringBuilder template = new StringBuilder();
                string body = string.Empty;
                StreamReader sr = new StreamReader(@"..\\..\\..\\Utility\\Templates\\NewKeyEmail.txt");
                template.Append(sr.ReadToEnd());
                sr.Close();
                body = template.ToString();
                body = body.Replace("#NAME#", (t.FirstName + " " + t.LastName));
                StringBuilder sb = new StringBuilder();
                if (TranslationRepo.GetPendingTranslations(t.Id).Count() > 0)
                {
                    foreach (Translation tr in TranslationRepo.GetPendingTranslations(t.Id))
                    {
                        string objs = TranslationKeyRepo.GetNonDeletedById(tr.TranslationKeyId).Key;
                        sb.Append(objs + "<br><br>");
                    }

                    body = body.Replace("#KEYS#", sb.ToString());
                    //Utility.StaticFunctions.SendMail("admin@translations.local", body, "New Translations added");
                    Utility.StaticFunctions.SendMail(t.EmailAddress, body, "New Translations added");
                }
            }
            #endregion


        }

    }
}
