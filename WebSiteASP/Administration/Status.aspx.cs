using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSiteASP.BusinessLayer;

namespace WebSiteASP.Administration
{
    public partial class Status : WebSiteASP.Base
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
            this.GridViewStatus.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpStatusSelect()).DbItems.Cast<StatusDb>().ToArray();
            this.GridViewStatus.DataBind();
        }

        protected void btnDeleteStatus_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int statusid = Convert.ToInt32(btn.CommandArgument);

            this.GridViewStatus.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpStatusDelete() { Status = new StatusDb() {IdStatus = statusid } }).DbItems.Cast<StatusDb>().ToArray();
            this.GridViewStatus.DataBind();
        }

        protected void btnEditStatus_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string[] args = btn.CommandArgument.Split(';').ToArray();
            this.LabelStatusId.Text = args[0];
            this.tbStatusName.Text = args[1];
            this.PanelShowData.Visible = true;
        }

        protected void ButtonUpdateStatus_Click(object sender, EventArgs e)
        {
            StatusDb status = new StatusDb()
            {
                IdStatus = Convert.ToInt32(this.LabelStatusId.Text),
                StatusName = this.tbStatusName.Text
            };
            this.GridViewStatus.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpStatusUpdate() {Status = status }).DbItems.Cast<StatusDb>().ToArray();
            this.GridViewStatus.DataBind();
            this.LabelStatusId.Text = "";
        }

        protected void ButtonAddStatus_Click(object sender, EventArgs e)
        {
            StatusDb status = new StatusDb()
            {
                StatusName = this.add_TextBoxStatusName.Text
            };
            this.GridViewStatus.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpStatusInsert() { Status = status}).DbItems.Cast<StatusDb>().ToArray();
            this.GridViewStatus.DataBind();
        }
    }
}