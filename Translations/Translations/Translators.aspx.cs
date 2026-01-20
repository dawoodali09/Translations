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
    public partial class Translators : BaseClass
    {
        //private TranslatorsRepository TranslatorsRepo;
        public Translators()
        {
            TranslatorsRepo = new TranslatorsRepository(DbContext);
        }
        protected new void Page_Load(object sender, EventArgs e)
        {
            RequireAdmin();
            if (!IsPostBack)
            {
                btnAddNew.Visible = true;
                btnAdd.Text = "Add";
                divTranslators.Visible = true;
                ListTranslators();
            }
        }

        public void ListTranslators()
        {
            divAddEdit.Visible = false;
            gvTranslators.DataSource = TranslatorsRepo.GetAllNonDeleted();
            gvTranslators.DataBind();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            //btnSave.Text = "Save";
            txtEmail.Enabled = true;
            divConfrmPaswrd.Visible = true;
            divPaswrd.Visible = true;
            btnAddNew.Visible = false;
            divAddEdit.Visible = true;
            divTranslators.Visible = false;
            txtEmail.Text = txtPasswrd.Text = txtCnfrmPaswrd.Text = txtFirstName.Text = txtLastName.Text = txtContact.Text = txtAddress.Text = txtMobile.Text = string.Empty;
            ddlRole.SelectedIndex = 0;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            btnAddNew.Visible = true;
            divTranslators.Visible = true;
            divAddEdit.Visible = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (btnAdd.Text == "Add")
            {
                //check if countryLanguage exists
                //CountryLanguage obj = CountryLanguageRepo.GetNonDeletedByCountryAndLanguage(long.Parse(ddlCountries.SelectedValue), long.Parse(ddlLanguage.SelectedValue));
                //if (obj == null)
                //{
                //    CountryLanguageRepo.CreateCountryLanguage(long.Parse(ddlCountries.SelectedValue), txtTitle.Text, chkbxActive.Checked, long.Parse(ddlLanguage.SelectedValue));
                //    CountryLanguageRepo.SaveChanges();
                //    diverror.Visible = false;
                //    Response.Redirect("CountryLanguages.aspx");
                //}
                //else
                //{
                //    //message to show that this key has already been used
                //    diverror.Visible = true;
                //}



                //if (string.IsNullOrEmpty(txtAddress.Text) | string.IsNullOrEmpty(txtPasswrd.Text) | string.IsNullOrEmpty(txtCnfrmPaswrd.Text) | string.IsNullOrEmpty(txtEmail.Text) | string.IsNullOrEmpty(txtFirstName.Text) | string.IsNullOrEmpty(txtLastName.Text) | string.IsNullOrEmpty(txtContact.Text) | string.IsNullOrEmpty(txtMobile.Text))
                //{
                //    diverror.Visible = true;
                //    litError.Text = "Please Fill All Fields.";
                //    return;
                //}
                if (txtPasswrd.Text.Trim().ToString() != txtCnfrmPaswrd.Text.Trim().ToString())
                {
                    //diverror.Visible = true;
                    //litError.Text = "Passwords do not match.";
                    return;
                }
                else
                {
                    string filename1 = System.IO.Path.GetFileName(fuPictureUpload.FileName);
                    Translator check = TranslatorsRepo.GetNonDeletedByEmail(txtEmail.Text);
                    if (check == null)
                    {
                        Translator obj = TranslatorsRepo.CreateTranslator(txtEmail.Text, txtCnfrmPaswrd.Text, txtFirstName.Text, txtLastName.Text, txtMobile.Text, txtContact.Text, txtAddress.Text, filename1, chkbxActive.Checked, ddlRole.SelectedItem.ToString());
                        if (obj != null && !string.IsNullOrEmpty(filename1))
                        {
                            fuPictureUpload.SaveAs(Server.MapPath("~/images/Users/" + filename1));
                        }
                        else
                        {
                            //error msg in saving
                        }
                        Response.Redirect("Translators.aspx");
                    }
                    else
                    {
                        diverror.Visible = true;
                    }
                }

            }
            else if (btnAdd.Text == "Update")
            {
                Translator obj = TranslatorsRepo.GetNonDeletedById(long.Parse(ViewState["Id"].ToString()));
                string filename1 = System.IO.Path.GetFileName(fuPictureUpload.FileName);
                if (obj != null)
                {
                    TranslatorsRepo.UpdateTranslator(long.Parse(ViewState["Id"].ToString()), txtFirstName.Text,txtLastName.Text,txtMobile.Text,txtContact.Text,txtAddress.Text,!string.IsNullOrEmpty(filename1)? filename1 : obj.PhotoURL, chkbxActive.Checked,ddlRole.SelectedItem.ToString());
                    TranslatorsRepo.SaveChanges();
                    Response.Redirect("Translators.aspx");
                    if (!string.IsNullOrEmpty(filename1))
                    {
                        fuPictureUpload.SaveAs(Server.MapPath("~/images/Users/" + filename1));
                    }                   
                }

            }





        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if ((e.CommandName.ToLower().Contains("editrecord")))
            {
                btnAddNew.Visible = false;
                divAddEdit.Visible = true;
                divTranslators.Visible = false;

                Translator obj = TranslatorsRepo.GetNonDeletedById(long.Parse(e.CommandArgument.ToString()));

                ViewState["Id"] = obj.Id;
                txtEmail.Text = obj.EmailAddress;
                txtEmail.Enabled = false;
                txtAddress.Text = obj.Address;
                txtFirstName.Text = obj.FirstName;
                txtLastName.Text = obj.LastName;
                txtContact.Text = obj.ContactNo;
                txtMobile.Text = obj.MobileNumber;
                divConfrmPaswrd.Visible = false;
                divPaswrd.Visible = false;
                chkbxActive.Checked = obj.Active;

                btnAdd.Text = "Update";
            }
            else if ((e.CommandName.ToLower().Contains("deleterecord")))
            {
                TranslatorsRepo.DeleteTranslator(long.Parse(e.CommandArgument.ToString()));
                TranslatorsRepo.SaveChanges();
                ListTranslators();
            }
        }

        protected void gvTranslators_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}