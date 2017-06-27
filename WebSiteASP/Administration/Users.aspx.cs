using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSiteASP.BusinessLayer;

namespace WebSiteASP.Administration
{
    public partial class Users : WebSiteASP.Base
    {
        protected override void DoBeforePageLoad()
        {
            this.ThisPageName = "Administration.aspx";
            this.OnlyAuthorizedUsers();
            this.OnlyAdmin();
        }
        protected override void DoAfterPageLoad()
        {
            this.GridViewUsers.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpUserSelect()).DbItems.Cast<UserDb>().ToArray();
            this.GridViewUsers.DataBind();
        }
        protected override void DoWithoutPostBack()
        {
            this.add_DropDownListRole.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpRoleSelect()).DbItems.Cast<RoleDb>().ToArray();
            this.add_DropDownListRole.DataTextField = "RoleName";
            this.add_DropDownListRole.DataValueField = "IdRole"; 
            this.add_DropDownListRole.DataBind();

            this.add_DropDownListStatus.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpStatusSelect()).DbItems.Cast<StatusDb>().ToArray();
            this.add_DropDownListStatus.DataTextField = "StatusName";
            this.add_DropDownListStatus.DataValueField = "IdStatus";
            this.add_DropDownListStatus.DataBind();
        }
        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            UserDb user = new UserDb()
            {
                IdUser = Convert.ToInt32(btn.CommandArgument)
            };
            this.GridViewUsers.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpUserDelete() { User = user }).DbItems.Cast<UserDb>().ToArray();
            this.GridViewUsers.DataBind();

            this.PanelEditUser.Visible = false;
        }

        protected void btnEditUser_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string[] args = btn.CommandArgument.Split(';').ToArray();

            this.LabelUserId.Text = args[0];
            this.tbFirstName.Text = args[1];
            this.tbLastName.Text = args[2];
            this.tbEmail.Text = args[3];
            //this.tbPassword.Text = args[4];

            this.ddlRole.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpRoleSelect()).DbItems.Cast<RoleDb>().ToArray();
            this.ddlRole.DataTextField = "RoleName";
            this.ddlRole.DataValueField = "IdRole"; 
            this.ddlRole.DataBind();
            this.ddlRole.SelectedValue = args[5];

            this.ddlStatus.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpStatusSelect()).DbItems.Cast<StatusDb>().ToArray();
            this.ddlStatus.DataTextField = "StatusName";
            this.ddlStatus.DataValueField = "IdStatus"; 
            this.ddlStatus.DataBind();
            this.ddlStatus.SelectedValue = args[6];

            this.PanelEditUser.Visible = true;
        }

        protected void ButtonAddUser_Click(object sender, EventArgs e)
        {
            UserDb user = new UserDb()
            {
                email = this.add_tbEmail.Text,
                firstName = this.add_tbFirstName.Text,
                lastName = this.add_tbLastName.Text,
                password = this.add_tbPassword.Text,
                idRole = Convert.ToInt32(this.add_DropDownListRole.SelectedValue),
                idStatus = Convert.ToInt32(this.add_DropDownListStatus.SelectedValue)
            };

            this.GridViewUsers.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpUserInsert() { User = user }).DbItems.Cast<UserDb>().ToArray();
            this.GridViewUsers.DataBind();
        }

        protected void btnUpdateUser_Click(object sender, EventArgs e)
        {
            UserDb user = new UserDb()
            {
                IdUser = Convert.ToInt32(this.LabelUserId.Text),
                email = this.tbEmail.Text,
                firstName = this.tbFirstName.Text,
                lastName = this.tbLastName.Text,
                idRole = Convert.ToInt32(this.ddlRole.SelectedValue),
                idStatus = Convert.ToInt32(this.ddlStatus.SelectedValue)
            };
            if (this.CheckBoxChangePassword.Checked)
                user.password = this.tbPassword.Text;

            this.GridViewUsers.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpUserUpdate() { User = user }).DbItems.Cast<UserDb>().ToArray();
            this.GridViewUsers.DataBind();
            this.PanelEditUser.Visible = false;
            this.CheckBoxChangePassword.Checked = false;
        }
    }
}