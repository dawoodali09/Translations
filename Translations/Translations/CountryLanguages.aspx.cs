using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Bll.Repositories;

namespace Translations
{
    public partial class CountryLanguages : BaseClass
    {
        public CountryLanguages()
        {
            CountryLanguageRepo = new CountryLanguagesRepository(DbContext);
            CountryRepo = new CountriesRepository(DbContext);
            LanguageRepo = new LanguagesRepository(DbContext);
            TranslationKeyRepo = new TranslationKeysRepository(DbContext);
            TranslationRepo = new TranslationsRepository(DbContext);
        }
        protected new void Page_Load(object sender, EventArgs e)
        {
            RequireAdmin();
            if (!IsPostBack)
            {
                btnAddNew.Visible = true;
                btnAdd.Text = "Add";
                divCountryLanguages.Visible = true;
                divAddEdit.Visible = false;
                ListCountryLanguages();
            }
        }

        public void ListCountryLanguages()
        {
            IEnumerable<CountryLanguage> trans = new List<CountryLanguage>();
            trans = CountryLanguageRepo.GetAllNonDeleted();
            if (trans != null)
            {
                gvKeys.DataSource = trans;
                gvKeys.DataBind();
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            btnAdd.Text = "Add";
            btnAddNew.Visible = false;
            divAddEdit.Visible = true;
            divCountryLanguages.Visible = false;
            txtTitle.Text = txtNote.Text = "";
            bindCountries(); 
            bindLanguages();
        }

       
        private void bindCountries()
        {
            ddlCountries.DataSource = CountryRepo.GetAllNonDeleted();
            ddlCountries.DataTextField = "Name";
            ddlCountries.DataValueField = "Id";
            ddlCountries.DataBind();
        }

        private void bindLanguages()
        {
            ddlLanguage.DataSource = LanguageRepo.GetAllNonDeleted();
            ddlLanguage.DataTextField = "Name";
            ddlLanguage.DataValueField = "Id";
            ddlLanguage.DataBind();
        }
      

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddNew.Visible = true;
            divCountryLanguages.Visible = true;
            divAddEdit.Visible = false;
        }

        public void AddTranslations(long countryLanguageId)
        {
            foreach(TranslationKey key in TranslationKeyRepo.GetAllNonDeleted())
            {
                TranslationRepo.CreateTranslation(key.Id, 0, countryLanguageId, key.EnglishValue, key.Comments, true);
            }
            TranslationRepo.SaveChanges();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add")
            {
                //check if countryLanguage exists
                CountryLanguage obj = CountryLanguageRepo.GetNonDeletedByCountryAndLanguage(long.Parse(ddlCountries.SelectedValue), long.Parse(ddlLanguage.SelectedValue));
                if (obj == null)
                {
                    CountryLanguage lang = new CountryLanguage();
                    lang = CountryLanguageRepo.CreateCountryLanguage(long.Parse(ddlCountries.SelectedValue), txtTitle.Text, chkbxActive.Checked, long.Parse(ddlLanguage.SelectedValue));
                    //CountryLanguageRepo.SaveChanges();
                    AddTranslations(lang.Id);
                    diverror.Visible = false;
                    Response.Redirect("CountryLanguages.aspx");
                }
                else
                {
                    //message to show that this key has already been used
                    diverror.Visible = true;
                }
            }
            else if (btnAdd.Text == "Update")
            {
                CountryLanguage obj = CountryLanguageRepo.GetNonDeletedById(long.Parse(ViewState["Id"].ToString()));

                if (obj != null)
                {
                    CountryLanguageRepo.UpdateCountryLanguage(long.Parse(ViewState["Id"].ToString()), long.Parse(ddlCountries.SelectedValue), txtTitle.Text, chkbxActive.Checked, long.Parse(ddlLanguage.SelectedValue));
                    CountryLanguageRepo.SaveChanges();
                    Response.Redirect("CountryLanguages.aspx");
                }

            }

        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ((e.CommandName.ToLower().Contains("editrecord")))
            {
                btnAddNew.Visible = false;
                divAddEdit.Visible = true;
                divCountryLanguages.Visible = false;

                CountryLanguage obj = CountryLanguageRepo.GetNonDeletedById(long.Parse(e.CommandArgument.ToString()));

                ViewState["Id"] = obj.Id;
                txtTitle.Text = obj.Title;
                txtNote.Text = obj.Note;
                chkbxActive.Checked = obj.Active;
                bindCountries();
                bindLanguages();
                ddlLanguage.SelectedValue = obj.LanguageId.ToString();
                ddlCountries.SelectedValue = obj.CountryId.ToString();

                btnAdd.Text = "Update";
            }
            else if ((e.CommandName.ToLower().Contains("deleterecord")))
            {
                long id = long.Parse(e.CommandArgument.ToString());
                CountryLanguageRepo.DeleteCountryLanguage(long.Parse(e.CommandArgument.ToString()));
                CountryLanguageRepo.SaveChanges();
                ListCountryLanguages();
            }
        }
    }
}