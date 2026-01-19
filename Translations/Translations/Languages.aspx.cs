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
            if(!IsPostBack)
            { 
                ListLanguages();
            }
        }

        public void ListLanguages()
        {
            gvLanguages.DataSource = LanguageRepo.GetAllNonDeleted();
            gvLanguages.DataBind();
        }

        protected void gvCountries_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLanguages.PageIndex = e.NewPageIndex;
            ListLanguages();
        }
    }
}