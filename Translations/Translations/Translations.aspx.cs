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
    public partial class Translations : BaseClass
    {
        public Translations()
        {
            TranslationRepo = new TranslationsRepository(DbContext);
        }
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //diverror.Visible = false;
                //btnAddNew.Visible = true;
                //btnAdd.Text = "Add";                
                divTranslations.Visible = true;
                divAddEdit.Visible = false;
                ListPendingTranslations();
            }
        }

        public void ListCompletedTranslations()
        {
            gvTranslationsPending.Visible = false;
            gvTranslations.Visible = true;
            gvTranslations.DataSource = TranslationRepo.GetCompletedTranslationsByUserId(User.Id);
            gvTranslations.DataBind();
            divTranslationsPending.Visible = false;
        }

        public string GetTranslator(string translatorId)
        {

            Translator obj = new Translator();
            obj = TranslatorsRepo.GetAllById(long.Parse(translatorId.ToString()));
            return obj.FirstName+" "+obj.LastName;
        }

        public void ListPendingTranslations()
        {
            string count = TranslationRepo.GetPendingTranslations(User.Id).Count().ToString();
            lblTranslationPending.Text = "You have " + count + " translation(s) pending";
            divTranslationsPending.Visible = true;
            gvTranslationsPending.Visible = true;
            gvTranslations.Visible = false;
            gvTranslationsPending.DataSource = TranslationRepo.GetPendingTranslations(User.Id);
            gvTranslationsPending.DataBind();
            
        }

        protected void btnPendingTranslations_Click(object sender,EventArgs e)
        {
            ListPendingTranslations();
        }

        protected void btnCompleted_Click(object sender, EventArgs e)
        {
            ListCompletedTranslations();
            //Response.Redirect("Translations.aspx");
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ((e.CommandName.ToLower().Contains("editrecord")))
            {
                divAddEdit.Visible = true;
                divTranslations.Visible = false;

                Translation obj = TranslationRepo.GetNonDeletedById(long.Parse(e.CommandArgument.ToString()));

                ViewState["Id"] = obj.Id;
                txtTranslationKey.Enabled = false;
                txtTranslationKey.Text = obj.TranslationKey.Key;
                txtEnglishText.Text = obj.TranslationKey.EnglishValue;
                txtTranslation.Text = !string.IsNullOrEmpty(obj.Value) ? obj.Value : "";
                chkbxActive.Checked = obj.Active;              
            }

            ListCompletedTranslations();            
        }

        protected void btnCancel_Click(object sender,EventArgs e)
        {
           divAddEdit.Visible = false;
           divTranslations.Visible = true;
           ListPendingTranslations();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Translation obj = TranslationRepo.GetNonDeletedById(long.Parse(ViewState["Id"].ToString()));
            if (obj != null)
            {
                TranslationRepo.UpdateTranslation(long.Parse(ViewState["Id"].ToString()), User.Id, txtTranslation.Text, txtComments.Text, chkbxActive.Checked);
                TranslationRepo.SaveChanges();
            }
            Response.Redirect("Translations.aspx");
        }

        public string GetEngTranslation(string Translation)
        {
            string Result = string.Empty;

            if (Translation.Length > 25)
            {
                Result = Translation.Remove(25) + ".........";
            }
            else
            {
                Result = Translation;
            }
            return Result;
        }

        protected void gvTranslations_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTranslations.PageIndex = e.NewPageIndex;
            ListCompletedTranslations();
        }

        protected void gvTranslationsPending_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTranslationsPending.PageIndex = e.NewPageIndex;
            ListPendingTranslations();
        }   
    }
}