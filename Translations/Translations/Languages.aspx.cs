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
    public partial class Languages : BaseClass
    {
        public Languages()
        {
            LanguageRepo = new LanguagesRepository(DbContext);
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            RequireAdmin();
            if (!IsPostBack)
            {
                divAddEdit.Visible = false;
                divLanguages.Visible = true;
                ListLanguages();
            }
        }

        public void ListLanguages()
        {
            gvLanguages.DataSource = LanguageRepo.GetAllNonDeleted();
            gvLanguages.DataBind();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ViewState["EditId"] = null;
            btnSave.Text = "Add";
            ClearForm();
            divAddEdit.Visible = true;
            divLanguages.Visible = false;
            diverror.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            divAddEdit.Visible = false;
            divLanguages.Visible = true;
            ClearForm();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ViewState["EditId"] == null)
            {
                // Add new language
                Language existing = LanguageRepo.GetByname(txtName.Text.Trim());
                if (existing != null)
                {
                    diverror.Visible = true;
                    return;
                }

                LanguageRepo.CreateLanguage(
                    txtCode.Text.Trim().ToLower(),
                    txtNativeName.Text.Trim(),
                    txtName.Text.Trim(),
                    txtNote.Text.Trim(),
                    chkActive.Checked
                );
                LanguageRepo.SaveChanges();
            }
            else
            {
                // Update existing language
                long id = long.Parse(ViewState["EditId"].ToString());
                Language existing = LanguageRepo.GetByname(txtName.Text.Trim());
                if (existing != null && existing.Id != id)
                {
                    diverror.Visible = true;
                    return;
                }

                LanguageRepo.UpdateLanguage(
                    id,
                    txtCode.Text.Trim().ToLower(),
                    txtName.Text.Trim(),
                    txtNativeName.Text.Trim(),
                    txtNote.Text.Trim(),
                    chkActive.Checked
                );
                LanguageRepo.SaveChanges();
            }

            Response.Redirect("Languages.aspx");
        }

        protected void gvLanguages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "editrecord")
            {
                long id = long.Parse(e.CommandArgument.ToString());
                Language language = LanguageRepo.GetNonDeletedById(id);

                if (language != null)
                {
                    ViewState["EditId"] = language.Id;
                    txtName.Text = language.Name;
                    txtNativeName.Text = language.NativeName;
                    txtCode.Text = language.Code;
                    txtNote.Text = language.Note;
                    chkActive.Checked = language.Active;

                    btnSave.Text = "Update";
                    divAddEdit.Visible = true;
                    divLanguages.Visible = false;
                    diverror.Visible = false;
                }
            }
            else if (e.CommandName.ToLower() == "deleterecord")
            {
                long id = long.Parse(e.CommandArgument.ToString());
                LanguageRepo.DeleteLanguage(id);
                LanguageRepo.SaveChanges();
                ListLanguages();
            }
        }

        protected void gvLanguages_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLanguages.PageIndex = e.NewPageIndex;
            ListLanguages();
        }

        private void ClearForm()
        {
            txtName.Text = "";
            txtNativeName.Text = "";
            txtCode.Text = "";
            txtNote.Text = "";
            chkActive.Checked = true;
            ViewState["EditId"] = null;
        }
    }
}
