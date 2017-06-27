using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSiteASP.BusinessLayer;

namespace WebSiteASP
{
    public partial class Register : WebSiteASP.Base
    {
        protected override void DoBeforePageLoad()
        {
            OnlyNonAuthorizedUsers();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                UserDb register = new UserDb()
                {
                    firstName = this.firstName.Value,
                    lastName = this.lastName.Value,
                    email = this.inputEmail.Value,
                    password = this.inputPassword.Value,
                    idStatus = 2,
                    idRole = 2
                };
                if (OperationManager.Singleton.izvrsiOperaciju(new OpUserInsertOnly() { User = register }).Status)
                    Response.Redirect("Login.aspx");
                else
                    this.labelError.Visible = true;
            }
        }
    }
}