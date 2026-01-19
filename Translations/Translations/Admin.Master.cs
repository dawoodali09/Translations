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
    public partial class Admin : System.Web.UI.MasterPage
    {
        private Bll.Repositories.TranslatorsRepository TranslatorsRepo = null;
        protected Entities DbContext;
       
        public Admin()
        {
            TranslatorsRepo = new TranslatorsRepository(DbContext);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
         //   SetUserMenu();
          //  SetActiveMenu();
        }

        //public void SetActiveMenu()
        //{
        //    string URL = Request.Url.AbsolutePath;

        //    if (URL.ToLowerInvariant().Contains("translator.aspx"))
        //    {
        //        liCountry.Attributes.Remove("class");
        //        liCountryLang.Attributes.Remove("class");
        //        liLanguages.Attributes.Remove("class");
        //        liTranslatorCountryLanguages.Attributes.Remove("class");
        //        liTranlationKey.Attributes.Remove("class");
        //        liTranlation.Attributes.Remove("class");
        //        liTranslatorTranslations.Attributes.Remove("class");
        //        liTranlator.Attributes.Add("class", "active");
        //    }
        //    else if (URL.ToLowerInvariant().Contains("countries.aspx"))
        //    {
        //        liCountryLang.Attributes.Remove("class");
        //        liLanguages.Attributes.Remove("class");
        //        liTranslatorCountryLanguages.Attributes.Remove("class");
        //        liTranlationKey.Attributes.Remove("class");
        //        liTranlation.Attributes.Remove("class");
        //        liTranlator.Attributes.Remove("class");
        //        liTranslatorTranslations.Attributes.Remove("class");
        //        liCountry.Attributes.Add("class", "active");
        //    }
        //    else if (URL.ToLowerInvariant().Contains("countrylanguages.aspx"))
        //    {
        //        liLanguages.Attributes.Remove("class");
        //        liCountry.Attributes.Remove("class");
        //        liTranslatorCountryLanguages.Attributes.Remove("class");
        //        liTranlationKey.Attributes.Remove("class");
        //        liTranlation.Attributes.Remove("class");
        //        liTranlator.Attributes.Remove("class");
        //        liTranslatorTranslations.Attributes.Remove("class");
        //        liCountryLang.Attributes.Add("class", "active");
        //    }
        //    else if (URL.ToLowerInvariant().Contains("languages.aspx"))
        //    {
        //        liCountryLang.Attributes.Remove("class");
        //        liCountry.Attributes.Remove("class");
        //        liTranslatorCountryLanguages.Attributes.Remove("class");
        //        liTranlationKey.Attributes.Remove("class");
        //        liTranlation.Attributes.Remove("class");
        //        liTranlator.Attributes.Remove("class");
        //        liTranslatorTranslations.Attributes.Remove("class");
        //        liLanguages.Attributes.Add("class", "active");                
        //    }   
        //    else if(URL.ToLowerInvariant().Contains("translatortranslations.aspx"))
        //    {
        //        liCountryLang.Attributes.Remove("class");
        //        liCountry.Attributes.Remove("class");
        //        liTranslatorCountryLanguages.Attributes.Remove("class");
        //        liTranlationKey.Attributes.Remove("class");
        //        liTranlation.Attributes.Remove("class");
        //        liTranlator.Attributes.Remove("class");                
        //        liLanguages.Attributes.Remove("class");
        //        liTranslatorTranslations.Attributes.Add("class", "active");
        //    }
        //    else if (URL.ToLowerInvariant().Contains("translations.aspx") | URL.ToLowerInvariant().Contains("translations2.aspx"))
        //    {
        //        liLanguages.Attributes.Remove("class");
        //        liCountry.Attributes.Remove("class");
        //        liTranslatorCountryLanguages.Attributes.Remove("class");
        //        liTranlationKey.Attributes.Remove("class");                
        //        liTranlator.Attributes.Remove("class");
        //        liCountryLang.Attributes.Remove("class");
        //        liTranslatorTranslations.Attributes.Remove("class");
        //        liTranlation.Attributes.Add("class", "active");
        //    }
        //    else if (URL.ToLowerInvariant().Contains("translationkeys.aspx"))
        //    {
        //        liLanguages.Attributes.Remove("class");
        //        liCountry.Attributes.Remove("class");
        //        liTranslatorCountryLanguages.Attributes.Remove("class");                
        //        liTranlator.Attributes.Remove("class");
        //        liCountryLang.Attributes.Remove("class");
        //        liTranlation.Attributes.Remove("class");
        //        liTranslatorTranslations.Attributes.Remove("class");
        //        liTranlationKey.Attributes.Add("class", "active");                
        //    }
        //    else if (URL.ToLowerInvariant().Contains("translatorcountylanguage.aspx"))
        //    {
        //        liLanguages.Attributes.Remove("class");
        //        liCountry.Attributes.Remove("class");                            
        //        liTranlator.Attributes.Remove("class");
        //        liCountryLang.Attributes.Remove("class");
        //        liTranlation.Attributes.Remove("class");
        //        liTranlationKey.Attributes.Remove("class");
        //        liTranslatorTranslations.Attributes.Remove("class");
        //        liTranslatorCountryLanguages.Attributes.Add("class", "active");
        //    }

            
        //}
        
        //void SetUserMenu()
        //{
        //    Translator _user = new Translator();
        //    if(Session["translator"]!=null)
        //    {
        //        _user = Session["translator"] as Translator;
        //        string PageName = string.Empty;

        //        if(_user != null)
        //        {
                    
        //            if(_user.Role.ToLowerInvariant() == "administrator")
        //            {
        //                liTranlator.Visible = true;
        //                liCountryLang.Visible = true;
        //                liTranlation.Visible = true;
        //                liTranlationKey.Visible = true;
        //                liCountry.Visible = true;
        //                liLanguages.Visible = true;
        //                liTranslatorCountryLanguages.Visible = true;
        //                liTranslatorTranslations.Visible = true;
        //            }
        //            else if (_user.Role.ToLowerInvariant() == "translator" )
        //            {
        //                string currentPage = Request.Url.AbsolutePath.ToLowerInvariant().ToString().Trim();
        //                if (currentPage.Contains("countries") | currentPage.Contains("languages") | currentPage.Contains("translation"))
        //                {     
        //                    liCountry.Visible = true;
        //                    liLanguages.Visible = true;
        //                    liTranslatorCountryLanguages.Visible = false;
        //                    liTranlator.Visible = false;
        //                    liCountryLang.Visible = false;
        //                    liTranlation.Visible = true;
        //                    liTranlationKey.Visible = false;
        //                    liTranslatorTranslations.Visible = false;
        //                }
        //                else
        //                {
        //                    Session.Abandon();
        //                    Response.Redirect("Login.aspx");
        //                }
        //            }
        //            // enable and disable links
        //        }
        //    }
        //}
    }
}