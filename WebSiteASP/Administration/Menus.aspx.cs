using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSiteASP.BusinessLayer;

namespace WebSiteASP.Administration
{
    public partial class Menus : WebSiteASP.Base
    {
        public RoleDb[] RoleData { get; set; }
        protected override void DoBeforePageLoad()
        {
            this.ThisPageName = "Administration.aspx";
            this.OnlyAuthorizedUsers();
            this.OnlyAdmin();
            this.RoleData = OperationManager.Singleton.izvrsiOperaciju(new OpRoleSelect()).DbItems.Cast<RoleDb>().ToArray();
        }
        protected override void DoWithoutPostBack()
        {
            this.add_DropDownListMenuRole.DataSource = this.RoleData;
            this.add_DropDownListMenuRole.DataTextField = "RoleName";
            this.add_DropDownListMenuRole.DataValueField = "idRole";
            this.add_DropDownListMenuRole.DataBind();
        }
        protected override void DoAfterPageLoad()
        {
            this.PanelShowData.Visible = false;
            this.GridViewMenus.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpMenuSelect()).DbItems.Cast<MenuDb>().ToArray();
            this.GridViewMenus.DataBind();
        }

        protected void btnEditMenu_Click(object sender, EventArgs e)
        {
            this.DropDownListRole.DataSource = RoleData;
            this.DropDownListRole.DataTextField = "RoleName";
            this.DropDownListRole.DataValueField = "idRole";
            this.DropDownListRole.DataBind();
            Button btn = (Button)sender;
            string[] args = btn.CommandArgument.Split(';').ToArray();
            this.LabelMenuId.Text = args[0];
            this.tbMenuTitle.Text = args[1];
            this.tbMenuLink.Text = args[2];
            this.DropDownListRole.SelectedValue = args[3];
            this.PanelShowData.Visible = true;
        }

        protected void btnDeleteMenu_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int menuid = Convert.ToInt32(btn.CommandArgument);

            this.GridViewMenus.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpMenuDelete() {Menu = new MenuDb() {IdMenu = menuid } }).DbItems.Cast<MenuDb>().ToArray();
            this.GridViewMenus.DataBind();
        }

        protected void ButtonUpdateMenu_Click(object sender, EventArgs e)
        {
            MenuDb menu = new MenuDb()
            {
                IdMenu = Convert.ToInt32(this.LabelMenuId.Text),
                Link = this.tbMenuLink.Text,
                Title = this.tbMenuTitle.Text,
                IdRole = Convert.ToInt32(this.DropDownListRole.SelectedValue),
                IdUserLastChange = (int)Session["idUser"]
            };
            this.GridViewMenus.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpMenuUpdate() {Menu = menu } ).DbItems.Cast<MenuDb>().ToArray();
            this.GridViewMenus.DataBind();
            this.LabelMenuId.Text = "";
        }

        protected void btnAddMenu_Click(object sender, EventArgs e)
        {
            MenuDb menu = new MenuDb()
            {
                Title = this.add_tbMenuTitle.Text,
                Link = this.add_tbMenuLink.Text,
                IdRole = Convert.ToInt32(this.add_DropDownListMenuRole.SelectedValue)
            };
            this.GridViewMenus.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpMenuInsert() { Menu = menu }).DbItems.Cast<MenuDb>().ToArray();
            this.GridViewMenus.DataBind();
        }
    }
}