using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSiteASP.BusinessLayer;
using WebSiteASP.Helpers;

namespace WebSiteASP
{
    public partial class Base : System.Web.UI.Page
    {
        public string ThisPageName { get; protected set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DoBeforePageLoad();

            if (this.ThisPageName == null)
                this.ThisPageName = "Default.aspx";

            LiteralControl userLinks = MenuMethods.MakeUserLinks(SessionMethodes.RoleId(Session["idRole"]));
            this.Master.FindControl("cphUserForm").Controls.Add(userLinks);

            OperacijaRezultat rezult = OpMenuSelect.SelectMenuByRole(SessionMethodes.RoleId(Session["idRole"]));
            LiteralControl menuLinks = MenuMethods.MakeMenuLinks(rezult.DbItems.Cast<MenuDb>().ToArray(), this.ThisPageName);
            this.Master.FindControl("cphMenu").Controls.Add(menuLinks);

            if (!Page.IsPostBack)
            {
                this.DoWithoutPostBack();
            }

            this.DoAfterPageLoad();
        }

        protected virtual void DoBeforePageLoad()
        {
            //this is only for access checking
        }
        protected virtual void DoAfterPageLoad()
        {
            //this replace page load in child classes
        }
        protected virtual void DoWithoutPostBack()
        {

        }
 
        protected void OnlyNonAuthorizedUsers()
        {
            if (Session["idUser"] != null)
                Response.Redirect("Default.aspx");
        }
        protected void OnlyAuthorizedUsers()
        {
            if (Session["idUser"] == null)
                Response.Redirect("Default.aspx");
        }
        protected void OnlyAdmin()
        {
            if((int)Session["idRole"] != 1)
                Response.Redirect("Default.aspx");
        }
    }
}