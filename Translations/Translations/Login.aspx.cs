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
    public partial class Login : System.Web.UI.Page
    {
        private Entities DbContext;
        private TranslatorsRepository TranslatorsRepo;

        public Login()
        {
            DbContext = new Entities();
            TranslatorsRepo = new TranslatorsRepository(DbContext);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                diverror.Visible = false;
                if (Request.Params["logoff"] != null)
                {
                    HttpCookie cookie1 = Request.Cookies["TranslatorID"];
                    if (cookie1 != null)
                    {
                        cookie1.Expires = DateTime.Now.AddDays(-1d);
                        Response.Cookies.Add(cookie1);
                        Session.Abandon();
                    }
                    Response.Redirect("Login.aspx");
                }

                HttpCookie cookie = Request.Cookies["TranslatorID"];
                if (cookie != null)
                {
                    Translator Obj = null;
                    Obj = TranslatorsRepo.GetActiveById(long.Parse(Request.Cookies["TranslatorID"].Value.Split('=')[1]));

                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                    if (Obj!=null)
                    { 
                        if(Obj.Role.ToLowerInvariant() =="administrator")
                        {
                            Response.Redirect("Translators.aspx");
                        }
                        else
                        {
                            Response.Redirect("Translations.aspx");
                        }
                    }
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Translator Obj = null;

            Obj = TranslatorsRepo.CheckLogin(txtEmail.Text, txtPassword.Text);

            if (Obj == null)
            {
               diverror.Visible = true;
            }
            else
            {
                HttpCookie cookie = Request.Cookies["TranslatorID"];
                if (cookie == null)
                {
                    cookie = new HttpCookie("TranslatorID");
                }

                cookie["TranslatorID"] = Obj.Id.ToString();
                cookie.Expires = DateTime.Now.AddDays(1d);
                Response.Cookies.Add(cookie);
                if (Obj.Role.ToLowerInvariant() == "Administrator")
                { 
                   Response.Redirect("Translators.aspx", true);  
                }
                else
                {
                    Response.Redirect("Translations.aspx", true);  
                }
            }
        }
    }
}