using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSiteASP.BusinessLayer;

namespace WebSiteASP.Administration
{
    public partial class Roles : WebSiteASP.Base
    {
        protected override void DoBeforePageLoad()
        {
            this.ThisPageName = "Administration.aspx";
            this.OnlyAuthorizedUsers();
            this.OnlyAdmin();
        }
        protected override void DoAfterPageLoad()
        {
            this.PanelShowData.Visible = false;
            this.GridViewRoles.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpRoleSelect()).DbItems.Cast<RoleDb>().ToArray();
            this.GridViewRoles.DataBind();
        }

        protected void btnEditRole_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string[] args = btn.CommandArgument.Split(';').ToArray();
            this.LabelRoleId.Text = args[0];
            this.tbRoleName.Text = args[1];
            this.PanelShowData.Visible = true;
        }

        protected void btnDeleteRole_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int roleid = Convert.ToInt32(btn.CommandArgument);

            this.GridViewRoles.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpRoleDelete() { Role = new RoleDb() {IdRole = roleid } }).DbItems.Cast<RoleDb>().ToArray();
            this.GridViewRoles.DataBind();
        }

        protected void ButtonUpdateRole_Click(object sender, EventArgs e)
        {
            RoleDb role = new RoleDb()
            {
                IdRole = Convert.ToInt32(this.LabelRoleId.Text),
                RoleName = this.tbRoleName.Text
            };
            this.GridViewRoles.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpRoleUpdate() { Role = role }).DbItems.Cast<RoleDb>().ToArray();
            this.GridViewRoles.DataBind();
            this.LabelRoleId.Text = "";
        }

        protected void ButtonAddRole_Click(object sender, EventArgs e)
        {
            RoleDb role = new RoleDb()
            {
                RoleName = this.add_TextBoxRoleName.Text
            };
            this.GridViewRoles.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpRoleInsert() { Role = role }).DbItems.Cast<RoleDb>().ToArray();
            this.GridViewRoles.DataBind();
        }
    }
}