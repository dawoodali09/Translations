using Bll.Repositories;
using DAL;
using System;
using System.Web.UI.WebControls;

namespace Translations
{
    public partial class Translations2 : BaseClass
    {
        public Translations2()
        {
            TranslationRepo = new TranslationsRepository(DbContext);
            TranslationKeyRepo = new TranslationKeysRepository(DbContext);
            TranslatorCountryLanguageRepo = new TranslatorCountryLanguagesRepository(DbContext);
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindKeys();
                BindLanguages();
                if (Request["ID"] != null)
                {
                    long currentKeyID = 0;
                    long.TryParse(Request["ID"].ToString().Trim(), out currentKeyID);

                    if (currentKeyID != 0)
                    {
                        ddlPendingKeys.SelectedValue = currentKeyID.ToString();
                    }
                }
                updateEnglishText();
                divsuccess.Visible = false;
            }
        }

        public void BindKeys()
        {
            ddlPendingKeys.Items.Clear();
            foreach (Translation tr in TranslationRepo.GetPendingTranslations(User.Id))
            {
                ListItem li = new ListItem(tr.TranslationKey.Key, tr.TranslationKey.Id.ToString());
                ddlPendingKeys.Items.Add(li);
            }
            if (ddlPendingKeys.Items.Count == 0)
            {
                btnInsert.Enabled = false;
            }
            else
            {
                btnInsert.Enabled = true;
            }
        }

        public void BindLanguages()
        {
            ddlLangauges.Items.Clear();
            foreach (TranslatorCountryLanguage tcl in TranslatorCountryLanguageRepo.GetNonDeletedByTranslatorID(User.Id))
            {
                ListItem li = new ListItem(tcl.CountryLanguage.Title, tcl.CountryLanguageId.ToString());
                ddlLangauges.Items.Add(li);
            }
            BindTranslations();
        }

        public void BindTranslations()
        {
            Translation newObj = new Translation();
            if (ddlPendingKeys.Items.Count > 0)
            {
                newObj = TranslationRepo.GetNonDeletedByTranslationKeyIdAndCountryLanguageID(long.Parse(ddlPendingKeys.SelectedValue.ToString()), long.Parse(ddlLangauges.SelectedValue.ToString()));
                txtTranslation.Text = string.IsNullOrEmpty(newObj.Value) ? "" : newObj.Value.ToString();
            }
        }

        protected void ddl_selectIndexChanged(object sender, EventArgs e)
        {
            updateEnglishText();
        }

        private void updateEnglishText()
        {
            if (ddlPendingKeys.Items.Count > 0)
            {
                TranslationKey obj = new TranslationKey();
                obj = TranslationKeyRepo.GetAllById(long.Parse(ddlPendingKeys.SelectedValue.ToString()));
                txtEnglish.Text = Server.HtmlEncode(string.IsNullOrEmpty(obj.EnglishValue) ? "" : obj.EnglishValue.ToString());
            }
            BindTranslations();
        }

        protected void ddlLanguages_selectIndexChanged(object sender, EventArgs e)
        {
            BindTranslations();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            //get translation using keyid and languageid
            Translation obj = new Translation();
            obj = TranslationRepo.GetNonDeletedByTranslationKeyIdAndCountryLanguageID(long.Parse(ddlPendingKeys.SelectedValue.ToString()), long.Parse(ddlLangauges.SelectedValue.ToString()));
            TranslationRepo.UpdateTranslation(obj.Id, User.Id, txtTranslation.Text, txtComments.Text, cbActive.Checked);
            TranslationRepo.SaveChanges();

            txtComments.Text = "";
            txtEnglish.Text = "";
            txtTranslation.Text = "";
            BindKeys();
            BindLanguages();
            updateEnglishText();
            divsuccess.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtComments.Text = "";
            txtEnglish.Text = "";
            txtTranslation.Text = "";
            Response.Redirect("Translations.aspx");
        }
    }
}