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
        private TranslatorsRepository TranslatorsRepo = null;
        protected Entities DbContext;

        public Admin()
        {
            DbContext = new Entities();
            TranslatorsRepo = new TranslatorsRepository(DbContext);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
            SetActiveNavigation();
            SetNavigationVisibility();
        }

        private void LoadUserInfo()
        {
            try
            {
                HttpCookie cookie = Request.Cookies["TranslatorID"];
                if (cookie != null)
                {
                    long userId = long.Parse(cookie.Value.Split('=')[1]);
                    Translator user = TranslatorsRepo.GetActiveById(userId);

                    if (user != null)
                    {
                        // Set user name
                        litUserName.Text = user.FirstName + " " + user.LastName;

                        // Set user role
                        litUserRole.Text = user.Role ?? "User";

                        // Set user initials (first letter of first name + first letter of last name)
                        string initials = "";
                        if (!string.IsNullOrEmpty(user.FirstName))
                            initials += user.FirstName[0].ToString().ToUpper();
                        if (!string.IsNullOrEmpty(user.LastName))
                            initials += user.LastName[0].ToString().ToUpper();

                        litUserInitials.Text = initials;
                    }
                    else
                    {
                        litUserName.Text = "User";
                        litUserRole.Text = "";
                        litUserInitials.Text = "U";
                    }
                }
                else
                {
                    litUserName.Text = "Guest";
                    litUserRole.Text = "";
                    litUserInitials.Text = "G";
                }
            }
            catch
            {
                litUserName.Text = "User";
                litUserRole.Text = "";
                litUserInitials.Text = "U";
            }
        }

        private bool IsAdmin()
        {
            try
            {
                HttpCookie cookie = Request.Cookies["TranslatorID"];
                if (cookie != null)
                {
                    long userId = long.Parse(cookie.Value.Split('=')[1]);
                    Translator user = TranslatorsRepo.GetActiveById(userId);
                    if (user != null)
                    {
                        return user.Role == "Administrator";
                    }
                }
            }
            catch { }
            return false;
        }

        private void SetNavigationVisibility()
        {
            bool isAdmin = IsAdmin();

            // Admin-only pages - hide for Translators
            liTranslators.Visible = isAdmin;
            liCountries.Visible = isAdmin;
            liLanguages.Visible = isAdmin;
            liCountryLanguages.Visible = isAdmin;
            liTranslatorLanguages.Visible = isAdmin;
            liTranslatorTranslations.Visible = isAdmin;
            liResourceGenerator.Visible = isAdmin;

            // Translator pages - visible to all
            liTranslationKeys.Visible = true;
            liTranslations.Visible = true;
        }

        private void SetActiveNavigation()
        {
            string url = Request.Url.AbsolutePath.ToLowerInvariant();

            // Reset all nav items
            navTranslators.Attributes.Remove("class");
            navCountries.Attributes.Remove("class");
            navLanguages.Attributes.Remove("class");
            navCountryLanguages.Attributes.Remove("class");
            navTranslatorLanguages.Attributes.Remove("class");
            navTranslationKeys.Attributes.Remove("class");
            navTranslations.Attributes.Remove("class");
            navTranslatorTranslations.Attributes.Remove("class");
            navResourceGenerator.Attributes.Remove("class");

            // Set active based on current page
            if (url.Contains("translators.aspx"))
                navTranslators.Attributes.Add("class", "active");
            else if (url.Contains("countries.aspx"))
                navCountries.Attributes.Add("class", "active");
            else if (url.Contains("languages.aspx"))
                navLanguages.Attributes.Add("class", "active");
            else if (url.Contains("countrylanguages.aspx"))
                navCountryLanguages.Attributes.Add("class", "active");
            else if (url.Contains("translatorcountylanguage.aspx"))
                navTranslatorLanguages.Attributes.Add("class", "active");
            else if (url.Contains("translationkeys.aspx"))
                navTranslationKeys.Attributes.Add("class", "active");
            else if (url.Contains("translatortranslations.aspx"))
                navTranslatorTranslations.Attributes.Add("class", "active");
            else if (url.Contains("translations.aspx") || url.Contains("translations2.aspx"))
                navTranslations.Attributes.Add("class", "active");
            else if (url.Contains("resourcegenerator.aspx"))
                navResourceGenerator.Attributes.Add("class", "active");
        }
    }
}
