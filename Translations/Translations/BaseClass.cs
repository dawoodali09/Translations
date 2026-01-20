using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using Bll.Repositories;
using System.Web.UI;

namespace Translations
{
    public abstract class BaseClass : System.Web.UI.Page
    {
        private Translator _user = null;

        protected TranslatorsRepository TranslatorsRepo;
        protected Entities DbContext;
        protected TranslationKeysRepository TranslationKeyRepo;
        protected CountryLanguagesRepository CountryLanguageRepo;
        protected CountriesRepository CountryRepo;
        protected LanguagesRepository LanguageRepo;
        protected TranslationsRepository TranslationRepo;
        protected TranslatorCountryLanguagesRepository TranslatorCountryLanguageRepo;
        
     

        new public Translator User
        {
            get
            {
                HttpCookie cookie = Request.Cookies["TranslatorID"];

                if (cookie != null && !String.IsNullOrEmpty(cookie["TranslatorID"]))
                {
                    long userID = long.Parse(cookie["TranslatorID"]);

                    if (Session["translator"] == null)
                    {
                        _user = TranslatorsRepo.GetActiveById(userID);
                        Session["translator"] = _user;
                    }
                    else
                    {
                        _user = Session["translator"] as Translator;
                    }
                }
                return _user;
            }
            set
            {
                _user = value;
            }
        }

        protected BaseClass()
        {
            DbContext = new Entities();
            TranslatorsRepo = new TranslatorsRepository(DbContext);

            this.Load += new EventHandler(this.Page_Load);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Checklogin();
            long? UserID = 0;
            if (_user != null)
            {
                UserID = _user.Id;
            }
        }

      
        public void Checklogin()
        {
            HttpCookie cookie = Request.Cookies["TranslatorID"];

            if (cookie != null && !String.IsNullOrEmpty(cookie["TranslatorID"]))
            {
                long TranslatorID = long.Parse(cookie["TranslatorID"]);

                if (Session["translator"] == null)
                {
                    _user = TranslatorsRepo.GetActiveById(TranslatorID);
                    Session["translator"] = _user;
                }
                else
                {
                    _user = Session["translator"] as Translator;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        /// <summary>
        /// Check if current user is an Administrator
        /// </summary>
        public bool IsAdmin()
        {
            if (_user != null)
            {
                return _user.Role == "Administrator";
            }
            return false;
        }

        /// <summary>
        /// Redirect to Translations page if user is not an Administrator
        /// Call this in Page_Load of admin-only pages
        /// </summary>
        public void RequireAdmin()
        {
            if (!IsAdmin())
            {
                Response.Redirect("Translations.aspx");
            }
        }
    }
}