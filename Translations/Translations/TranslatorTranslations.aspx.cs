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
    public partial class TranslatorTranslations : BaseClass
    {
        public TranslatorTranslations()
        {
            TranslatorsRepo = new TranslatorsRepository(DbContext);
            TranslationRepo = new TranslationsRepository(DbContext);
        }
        protected new void Page_Load(object sender, EventArgs e)
        {
            RequireAdmin();
            if (!Page.IsPostBack)
            {
                BindTranslators();
                BindGridTranslations(long.Parse(ddlTranslators.SelectedValue));
                divAddEdit.Visible = false;
            }
        }

        public void BindTranslators()
        {
            ddlTranslators.DataSource = TranslatorsRepo.GetAllNonDeleted();
            ddlTranslators.DataTextField = "EmailAddress";
            ddlTranslators.DataValueField = "Id";
            ddlTranslators.DataBind();
        }

        protected void ddlTranslators_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridTranslations(long.Parse(ddlTranslators.SelectedValue));
        }

        public void BindGridTranslations(long userID)
        {
            gvTranslatorTranslations.DataSource = TranslationRepo.GetCompletedTranslationsByUserId(userID);
            gvTranslatorTranslations.DataBind();
            lblTranslationDone.Text = TranslationRepo.GetCompletedTranslationsByUserId(userID).Count().ToString() + " translations completed";
        }

        protected void gvTranslatorTranslations_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTranslatorTranslations.PageIndex = e.NewPageIndex;
            BindGridTranslations(long.Parse(ddlTranslators.SelectedValue));
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

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ((e.CommandName.ToLower().Contains("viewrecord")))
            {
                divAddEdit.Visible = true;
                divTranslators.Visible = false;

                Translation obj = TranslationRepo.GetNonDeletedById(long.Parse(e.CommandArgument.ToString()));

                ViewState["Id"] = obj.Id;
                txtTranslationKey.Enabled = false;
                txtTranslationKey.Text = obj.TranslationKey.Key;
                txtEnglishText.Text = obj.TranslationKey.EnglishValue;
                txtTranslation.Text = !string.IsNullOrEmpty(obj.Value) ? obj.Value : "";
                chkbxActive.Checked = obj.Active;
            }

            BindGridTranslations(long.Parse(ddlTranslators.SelectedValue));
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            divAddEdit.Visible = false;
            divTranslators.Visible = true;
            BindGridTranslations(long.Parse(ddlTranslators.SelectedValue));
        }

    }
}