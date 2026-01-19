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
            if(!IsPostBack)
            { 
                ListCountries();
            }
        }

        public void ListCountries()
        {
            gvCountries.DataSource = CountryRepo.GetAllNonDeleted();
            gvCountries.DataBind();
        }

        protected void gvCountries_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCountries.PageIndex = e.NewPageIndex;
            ListCountries();
        }

        //protected void gvCountries_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvCountries.PageIndex = e.NewPageIndex;
        //    ListCountries();
        //}
    }
}