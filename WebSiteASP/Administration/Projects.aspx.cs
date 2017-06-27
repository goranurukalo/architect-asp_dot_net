using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSiteASP.BusinessLayer;
using WebSiteASP.Helpers;

namespace WebSiteASP.Administration
{
    public partial class Projects : WebSiteASP.Base
    {
        protected override void DoBeforePageLoad()
        {
            this.ThisPageName = "Administration.aspx";
            this.OnlyAuthorizedUsers();
            this.OnlyAdmin();
        }
        protected override void DoAfterPageLoad()
        {

            //this.PanelShowEditImage.Visible = false;
            //this.PanelShowData.Visible = false;



            //this.GridViewProjects.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpProjectSelect()).DbItems.Cast<ProjectDb>().ToArray();
            //this.GridViewProjects.DataBind();

            this.GridView1.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpProjectSelect()).DbItems.Cast<ProjectDb>().ToArray();
            this.GridView1.DataBind();
        }

        protected void btnDeleteProject_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            //this.GridViewProjects.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpProjectDelete() {Project = new ProjectDb() {IdProject = Convert.ToInt32(btn.CommandArgument) } }).DbItems.Cast<ProjectDb>().ToArray();
            //this.GridViewProjects.DataBind();
            this.GridView1.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpProjectDelete() {Project = new ProjectDb() {IdProject = Convert.ToInt32(btn.CommandArgument) } }).DbItems.Cast<ProjectDb>().ToArray();
            this.GridView1.DataBind();
        }

        protected void btnEditProject_Click(object sender, EventArgs e)
        {
            this.CheckBoxUploadNewMainImage.Checked = false;
            this.PanelShowData.Visible = true;
            Button btn = (Button)sender;
            string[] args = btn.CommandArgument.Split(';').ToArray();

            this.LabelProjectId.Text = args[0];
            this.tbProjectTitle.Text = args[1];
            this.tbProjectTag.Text = args[2];
            this.TextAreaDescription.Value = args[3];
            this.MainImageProject.ImageUrl = args[4];

            //this.GridViewImages.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpImageSelect() {Kriterijum = new KriterijumFullProject() {IdProject = Convert.ToInt32(args[0]) } }).DbItems.Cast<ImageDb>().ToArray();
            //this.GridViewImages.DataBind();
            this.GridView2.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpImageSelect() { Kriterijum = new KriterijumFullProject() { IdProject = Convert.ToInt32(args[0]) } }).DbItems.Cast<ImageDb>().ToArray();
            this.GridView2.DataBind();
        }
        protected void btnUpdateProject_Click(object sender, EventArgs e)
        {
            ProjectDb project = new ProjectDb()
            {
                IdProject = Convert.ToInt32(this.LabelProjectId.Text),
                Description = this.TextAreaDescription.Value,
                Title = this.tbProjectTitle.Text,
                Tag = this.tbProjectTag.Text
            };

            if (this.CheckBoxUploadNewMainImage.Checked)
            {
                UploadImageDb img = UploadFile.UploadImage(this.FileUploadMainImage, Server.MapPath("~/Upload/"));
                if (img.IsUploaded)
                {
                    project.MainImageLink = img.BigPictureUrl;
                    //this.GridViewProjects.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpProjectUpdateWithImg() { Project = project }).DbItems.Cast<ProjectDb>().ToArray();
                    this.GridView1.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpProjectUpdateWithImg() { Project = project }).DbItems.Cast<ProjectDb>().ToArray();
                }
                else
                {
                    //this.GridViewProjects.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpProjectUpdateWithoutImg() { Project = project }).DbItems.Cast<ProjectDb>().ToArray();
                    this.GridView1.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpProjectUpdateWithoutImg() { Project = project }).DbItems.Cast<ProjectDb>().ToArray();
                }
            }
            else
            {
                //this.GridViewProjects.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpProjectUpdateWithoutImg() {Project = project }).DbItems.Cast<ProjectDb>().ToArray();
                this.GridView1.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpProjectUpdateWithoutImg() {Project = project }).DbItems.Cast<ProjectDb>().ToArray();
            }
            this.PanelShowData.Visible = false;
            //this.GridViewProjects.DataBind();
            this.GridView1.DataBind();
        }

        protected void btnEditProjectImage_Click(object sender, EventArgs e)
        {
            this.PanelShowEditImage.Visible = true;
            this.CheckBoxNewImage.Checked = false;

            Button btn = (Button)sender;
            string[] args = btn.CommandArgument.Split(';').ToArray();

            this.LabelImageId.Text = args[0];
            this.tbEditImageName.Text = args[4];
            this.tbEditImageAlt.Text = args[3];
        }

        protected void btnDeleteProjectImage_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            this.GridView2.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpImageDelete()
            {
                Kriterijum = new KriterijumFullProject() {IdProject = Convert.ToInt32(this.LabelProjectId.Text) },
                Image = new ImageDb() {IdImage = Convert.ToInt32(btn.CommandArgument) }
            }).DbItems.Cast<ImageDb>().ToArray();

            this.GridView2.DataBind();
        }

        protected void UpdateImage_Click(object sender, EventArgs e)
        {
            ImageDb image = new ImageDb()
            {
                IdImage = Convert.ToInt32(this.LabelImageId.Text),
                ImageName = this.tbEditImageName.Text,
                ImgAlt = this.tbEditImageAlt.Text
            };

            if (this.CheckBoxNewImage.Checked)
            {
                UploadImageDb img = UploadFile.UploadImage(this.FileUploadEditImage, Server.MapPath("~/Upload/"), true);
                if (img.IsUploaded)
                {
                    image.BigPictureUrl = img.BigPictureUrl;
                    image.SmallPictureUrl = img.SmallPictureUrl;
                    this.GridView2.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpImageUpdate() { Image = image }).DbItems.Cast<ImageDb>().ToArray();
                    this.GridView2.DataBind();
                }
            }
            else
            {
                this.GridView2.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpImageUpdateWithoutImg() { Image = image }).DbItems.Cast<ImageDb>().ToArray();
                this.GridView2.DataBind();
            }
            this.PanelShowEditImage.Visible = false;
        }



        #region EmptyEvents
        protected void GridViewEmpty_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridViewEmpty_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        #endregion

    }
}