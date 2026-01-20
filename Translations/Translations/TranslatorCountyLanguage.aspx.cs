using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll.Repositories;
using DAL;

namespace Translations
{
    public partial class TranslatorCountyLanguage : BaseClass
    {
        public TranslatorCountyLanguage()
        {
            TranslatorCountryLanguageRepo = new TranslatorCountryLanguagesRepository(DbContext);
            TranslatorsRepo = new TranslatorsRepository(DbContext);
            CountryLanguageRepo = new CountryLanguagesRepository(DbContext);
        }
        protected new void Page_Load(object sender, EventArgs e)
        {
            RequireAdmin();
            if(!IsPostBack)
            {
                divTranslatorCountryLanguages.Visible = true;
                divAddEdit.Visible = false;
                ListTranslatorCountryLanguages();
                BindTranslators();
                BindCountryLanguage();
            }
        }

        public void ListTranslatorCountryLanguages()
        {
            gvTranslatorCountryLanguages.DataSource = TranslatorCountryLanguageRepo.GetAllNonDeleted();
            gvTranslatorCountryLanguages.DataBind();
        }

        public void BindTranslators()
        {
            ddlTranslator.Items.Clear();
            ddlTranslator.Items.Clear();
            foreach (Translator c in TranslatorsRepo.GetAllNonDeleted())
            {
                ListItem li = new ListItem(c.FirstName+" "+c.LastName, c.Id.ToString());
                ddlTranslator.Items.Add(li);
            }
            ddlTranslator.Enabled = true;
            //ddlTranslator.DataSource = TranslatorsRepo.GetAllNonDeleted();           
            //ddlTranslator.DataTextField = "FirstName";
            //ddlTranslator.DataValueField = "Id";
            //ddlTranslator.DataBind();
            
        }

        public void BindCountryLanguage()
        {
            ddlCountryLanguage.Items.Clear();
            ddlCountryLanguage.DataSource = CountryLanguageRepo.GetAllNonDeleted();
            ddlCountryLanguage.DataTextField = "Title";
            ddlCountryLanguage.DataValueField = "Id";
            ddlCountryLanguage.DataBind();            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add")
            {
                //check if countryLanguage exists
                TranslatorCountryLanguage obj = TranslatorCountryLanguageRepo.GetByTranslatorAndCountryLanguageId(long.Parse(ddlTranslator.SelectedValue), long.Parse(ddlCountryLanguage.SelectedValue));
                if (obj == null)
                {
                    TranslatorCountryLanguageRepo.CreateTranslatorCountryLanguage(long.Parse(ddlTranslator.SelectedValue),long.Parse(ddlCountryLanguage.SelectedValue),txtNote.Text,chkbxActive.Checked);
                    TranslatorCountryLanguageRepo.SaveChanges();
                    diverror.Visible = false;
                    ListTranslatorCountryLanguages();
                    Response.Redirect("TranslatorCountyLanguage.aspx");
                }
                else
                {
                    //message to show that this key has already been used
                    diverror.Visible = true;
                }
            }
            else if (btnAdd.Text == "Update")
            {
                TranslatorCountryLanguage obj = TranslatorCountryLanguageRepo.GetNonDeletedById(long.Parse(ViewState["Id"].ToString()));

                if (obj != null)
                {
                    TranslatorCountryLanguageRepo.UpdateTranslatorCountryLanguage(long.Parse(ViewState["Id"].ToString()), long.Parse(ddlTranslator.SelectedValue), long.Parse(ddlCountryLanguage.SelectedValue),txtNote.Text,chkbxActive.Checked);
                    TranslatorCountryLanguageRepo.SaveChanges();
                    Response.Redirect("TranslatorCountyLanguage.aspx");
                    ListTranslatorCountryLanguages();
                }

            }

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            btnAdd.Text = "Add";
            btnAddNew.Visible = false;
            divAddEdit.Visible = true;
            divTranslatorCountryLanguages.Visible = false;
            txtNote.Text = "";
            BindCountryLanguage();
            BindTranslators();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddNew.Visible = true;
            divTranslatorCountryLanguages.Visible = true;
            divAddEdit.Visible = false;
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ((e.CommandName.ToLower().Contains("editrecord")))
            {
                //btnAddNew.Visible = false;
                divAddEdit.Visible = true;
                divTranslatorCountryLanguages.Visible = false;

                TranslatorCountryLanguage obj = TranslatorCountryLanguageRepo.GetNonDeletedById(long.Parse(e.CommandArgument.ToString()));

                ViewState["Id"] = obj.Id;
                BindTranslators();
                BindCountryLanguage();
                ddlTranslator.SelectedValue = obj.TranslatorId.ToString();
                ddlTranslator.Enabled = false;
                ddlCountryLanguage.SelectedValue = obj.CountryLanguageId.ToString();
                txtNote.Text = obj.Note.ToString();
                chkbxActive.Checked = obj.Active;              

                btnAdd.Text = "Update";
            }
            else if ((e.CommandName.ToLower().Contains("deleterecord")))
            {
                long id = long.Parse(e.CommandArgument.ToString());
                TranslatorCountryLanguageRepo.DeleteTranslatorCountryLanguage(long.Parse(e.CommandArgument.ToString()));
                TranslatorCountryLanguageRepo.SaveChanges();
                ListTranslatorCountryLanguages();
            }
        }
    }
}