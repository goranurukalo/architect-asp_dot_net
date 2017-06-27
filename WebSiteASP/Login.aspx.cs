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
    public partial class Login : WebSiteASP.Base
    {
        protected override void DoBeforePageLoad()
        {
            OnlyNonAuthorizedUsers();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (this.Page.IsValid)
            {
                string email = this.inputEmail.Value;
                string password = this.inputPassword.Value;

                KriterijumUser login = new KriterijumUser()
                {
                    Email = email,
                    Password = password,
                    //Status = 1
                }; //Verified ->posto email ne radi onda ne moze ni da se verifikuje
                OperacijaRezultat rezult = OperationManager.Singleton.izvrsiOperaciju(new OpUserSelect() { Kriterijum = login });

                if (rezult.Status && rezult.HaveItems)
                {
                    UserDb user = rezult.DbItems.Cast<UserDb>().ToArray()[0];

                    if (BCrypt.Net.BCrypt.Verify(password, user.password))
                    {
                        Session["idUser"] = user.IdUser;
                        Session["idRole"] = user.idRole;
                        Session["fullName"] = user.firstName + " " + user.lastName;

                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        this.labelErrorDisplay.Visible = true;
                    }
                }
                else
                {
                    this.labelErrorDisplay.Visible = true;
                }
            }
        }
    }
}