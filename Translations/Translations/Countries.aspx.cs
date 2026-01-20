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
    public partial class Countries : BaseClass
    {
        public Countries()
        {
            CountryRepo = new CountriesRepository(DbContext);
        }

        protected new void Page_Load(object sender, EventArgs e)
        {
            RequireAdmin();
            if (!IsPostBack)
            {
                divAddEdit.Visible = false;
                divCountries.Visible = true;
                ListCountries();
            }
        }

        public void ListCountries()
        {
            gvCountries.DataSource = CountryRepo.GetAllNonDeleted();
            gvCountries.DataBind();
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            ViewState["EditId"] = null;
            btnSave.Text = "Add";
            ClearForm();
            divAddEdit.Visible = true;
            divCountries.Visible = false;
            diverror.Visible = false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            divAddEdit.Visible = false;
            divCountries.Visible = true;
            ClearForm();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ViewState["EditId"] == null)
            {
                // Add new country
                Country existing = CountryRepo.GetNonDeletedByName(txtName.Text.Trim());
                if (existing != null)
                {
                    diverror.Visible = true;
                    return;
                }

                CountryRepo.CreateCountry(
                    txtName.Text.Trim(),
                    txtISONumber.Text.Trim(),
                    txtISOCode.Text.Trim().ToUpper(),
                    txtShortCode.Text.Trim().ToUpper(),
                    chkActive.Checked
                );
                CountryRepo.SaveChanges();
            }
            else
            {
                // Update existing country
                long id = long.Parse(ViewState["EditId"].ToString());
                Country existing = CountryRepo.GetNonDeletedByName(txtName.Text.Trim());
                if (existing != null && existing.Id != id)
                {
                    diverror.Visible = true;
                    return;
                }

                CountryRepo.UpdateCountry(
                    id,
                    txtISONumber.Text.Trim(),
                    txtName.Text.Trim(),
                    txtISOCode.Text.Trim().ToUpper(),
                    txtShortCode.Text.Trim().ToUpper(),
                    chkActive.Checked
                );
                CountryRepo.SaveChanges();
            }

            Response.Redirect("Countries.aspx");
        }

        protected void gvCountries_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "editrecord")
            {
                long id = long.Parse(e.CommandArgument.ToString());
                Country country = CountryRepo.GetNonDeletedById(id);

                if (country != null)
                {
                    ViewState["EditId"] = country.Id;
                    txtName.Text = country.Name;
                    txtISONumber.Text = country.ISONumber;
                    txtISOCode.Text = country.ISOCode;
                    txtShortCode.Text = country.ShortCode;
                    chkActive.Checked = country.Active;

                    btnSave.Text = "Update";
                    divAddEdit.Visible = true;
                    divCountries.Visible = false;
                    diverror.Visible = false;
                }
            }
            else if (e.CommandName.ToLower() == "deleterecord")
            {
                long id = long.Parse(e.CommandArgument.ToString());
                CountryRepo.DeleteCountry(id);
                CountryRepo.SaveChanges();
                ListCountries();
            }
        }

        protected void gvCountries_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCountries.PageIndex = e.NewPageIndex;
            ListCountries();
        }

        private void ClearForm()
        {
            txtName.Text = "";
            txtISONumber.Text = "";
            txtISOCode.Text = "";
            txtShortCode.Text = "";
            chkActive.Checked = true;
            ViewState["EditId"] = null;
        }
    }
}
