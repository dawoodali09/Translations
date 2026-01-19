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
    public partial class TranslationKeys : BaseClass
    {
        public static bool categorised;
        public TranslationKeys()
        {
            TranslationKeyRepo = new TranslationKeysRepository(DbContext);
            TranslationRepo = new TranslationsRepository(DbContext);
            CountryLanguageRepo = new CountryLanguagesRepository(DbContext);
        }
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                diverror.Visible = false;
                btnAddNew.Visible = true;
                btnAdd.Text = "Add";
                divKeys.Visible = true;
                divAddEdit.Visible = false;
                ListKeys();
            }
        }

        public void ListKeys()
        {
            gvKeys.DataSource = TranslationKeyRepo.GetAllNonDeleted();
            gvKeys.DataBind();
            categorised = false;
            divSearch.Visible = true;
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            btnAdd.Text = "Add";
            btnAddNew.Visible = false;
            divAddEdit.Visible = true;
            divKeys.Visible = false;
            txtKey.Enabled = true;
            txtKey.Text = txtEnglishText.Text = txtComments.Text = "";
            divSearch.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddNew.Visible = true;
            divKeys.Visible = true;
            divAddEdit.Visible = false;
            divSearch.Visible = true;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add")
            {
                //check if key exists
                TranslationKey obj = TranslationKeyRepo.GetNonDeletedByKey(txtKey.Text);
                if (obj == null)
                {
                    TranslationKey objNew = TranslationKeyRepo.CreateTranslationKey(txtKey.Text, txtEnglishText.Text, User.Id, chkbxActive.Checked, txtComments.Text);
                    foreach (CountryLanguage cl in CountryLanguageRepo.GetAllNonDeleted())
                    {
                        TranslationRepo.CreateTranslation(objNew.Id, 0, cl.Id, txtEnglishText.Text, txtComments.Text, false);
                    }

                    //update UK n US translation
                    TranslationRepo.UpdateTranslationForUKAndUS(objNew.Id, User.Id, txtEnglishText.Text, txtComments.Text);
                    TranslationRepo.SaveChanges();

                    diverror.Visible = false;
                    Response.Redirect("TranslationKeys.aspx");
                    divSearch.Visible = true;
                }
                else
                {
                    //message to show that this key has already been used
                    diverror.Visible = true;
                }
            }
            else if (btnAdd.Text == "Update")
            {
                TranslationKey obj = TranslationKeyRepo.GetNonDeletedByKey(txtKey.Text);
                if (obj != null)
                {
                    TranslationKeyRepo.UpdateTranslationKey(txtKey.Text, txtEnglishText.Text, User.Id, chkbxActive.Checked,txtComments.Text);
                    TranslationKeyRepo.SaveChanges();
                }
                Response.Redirect("TranslationKeys.aspx");
                divSearch.Visible = true;
            }

        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ((e.CommandName.ToLower().Contains("editrecord")))
            {
                btnAddNew.Visible = false;
                divAddEdit.Visible = true;
                divKeys.Visible = false;

                TranslationKey obj = TranslationKeyRepo.GetNonDeletedById(long.Parse(e.CommandArgument.ToString()));

                ViewState["Id"] = obj.Id;
                txtKey.Enabled = false;
                txtKey.Text = obj.Key;
                txtEnglishText.Text = obj.EnglishValue;
                txtComments.Text = obj.Comments;
                chkbxActive.Checked = obj.Active;

                btnAdd.Text = "Update";
                divSearch.Visible = false;
            }
            else if ((e.CommandName.ToLower().Contains("deleterecord")))
            {
                long id = long.Parse(e.CommandArgument.ToString());
                TranslationKey key = TranslationKeyRepo.GetNonDeletedById(id);

                if (key != null)
                {

                    TranslationKeyRepo.DeleteTranslationKey(key);

                    TranslationKeyRepo.SaveChanges();
                }
                ListKeys();
            }
        }

        protected void gvKeys_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvKeys.PageIndex = e.NewPageIndex;
            if (categorised == false)
            {
                ListKeys();
            }
            else
            {
                Search();
            }
        }

        public string GetEngTranslation(string Translation)
        {
            string Result = string.Empty;

            if (Translation.Length > 25)
            {
                Result = "Big Text, Click Edit to see .";
            }
            else
            {
                Result = Translation;
            }
            return Result;
        }

        public void Search()
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                if (ddlSearchBy.SelectedValue == "1")
                {
                    gvKeys.DataSource = TranslationKeyRepo.SearchKeysByKey(txtSearch.Text);
                    gvKeys.DataBind();
                }
                else if (ddlSearchBy.SelectedValue == "2")
                {
                    gvKeys.DataSource = TranslationKeyRepo.SearchKeysTranslation(txtSearch.Text);
                    gvKeys.DataBind();
                }
                categorised = true;
            }
            else
            {
                ListKeys();
            }
        }

        public string GetString(string str )
        {
            string ss = str;

            return ss;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            ListKeys();
            txtSearch.Text = "";
        }
    }
}