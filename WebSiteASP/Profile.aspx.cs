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
    public partial class Profile : WebSiteASP.Base
    {
        protected override void DoBeforePageLoad()
        {
            this.ThisPageName = "Profile.aspx";
            this.OnlyAuthorizedUsers();
            this.SqlDataSourceProjectImage.SelectCommand = @"SELECT [idProject], [title], [mainImageLink], [numberOfLikes], [tag], [description] FROM [Projects] WHERE [idUser] ="+(int)Session["idUser"];
        }

        protected override void DoAfterPageLoad()
        {
            this.LabelMessage.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(this.Page.IsValid)
            {
                if (this.CheckBoxEditing.Checked)
                {
                    ProjectDb project = new ProjectDb()
                    {
                        IdProject = Convert.ToInt32(this.LabelEditingId.Text),
                        IdUser = (int)Session["idUser"],
                        Title = this.tbTitle.Text,
                        Tag = this.tbTag.Text,
                        Description = this.taDescription.Value
                    };
                    if (this.CheckBoxEditImage.Checked)
                    {
                        UploadImageDb image = UploadFile.UploadImage(this.FileUploadMainImage, Server.MapPath("~/Upload/"));

                        if (image.IsUploaded)
                        {
                            project.MainImageLink = image.BigPictureUrl;
                            this.LabelMessage.ForeColor = System.Drawing.Color.Green;
                            this.CheckBoxEditImage.Checked = false;
                            this.CheckBoxEditImage.Visible = false;
                            OperationManager.Singleton.izvrsiOperaciju( new OpProjectUpdateOnlyWithImg() {Project = project });
                        }
                        else
                        {
                            this.LabelMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                    else
                    {
                        this.CheckBoxEditImage.Checked = false;
                        this.CheckBoxEditImage.Visible = false;
                        OperationManager.Singleton.izvrsiOperaciju(new OpProjectUpdateOnlyWithoutImg() { Project = project });
                    }
                    this.tbTitle.Text = "";
                    this.tbTag.Text = "";
                    this.taDescription.Value = "";
                }
                else
                {
                    //obradi ono za sliku prvo
                    UploadImageDb image = UploadFile.UploadImage(this.FileUploadMainImage, Server.MapPath("~/Upload/"));

                    if (image.IsUploaded)
                    {
                        ProjectDb project = new ProjectDb()
                        {
                            IdUser = (int)Session["idUser"],
                            Title = this.tbTitle.Text,
                            Tag = this.tbTag.Text,
                            Description = this.taDescription.Value,
                            MainImageLink = image.BigPictureUrl
                        };
                        OperationManager.Singleton.izvrsiOperaciju(new OpProjectInsertOnly() { Project = project });
                        this.tbTitle.Text = "";
                        this.tbTag.Text = "";
                        this.taDescription.Value = "";

                        this.CheckBoxEditImage.Visible = false;
                        this.LabelMessage.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        this.LabelMessage.ForeColor = System.Drawing.Color.Red;
                    }
                    this.LabelMessage.Visible = true;
                    this.LabelMessage.Text = image.ErrorMessage;
                }
            }
            this.LabelEditingId.Text = "";
            this.CheckBoxEditing.Checked = false;
            this.GridView1.DataBind();
        }

        protected void deliting_Click(object sender, EventArgs e)
        {
            Button remove = (Button)sender;
            int projectId = Convert.ToInt32(remove.CommandArgument);
            
            OperacijaRezultat res = OperationManager.Singleton.izvrsiOperaciju(new OpProjectDeleteOnly() { Project = new ProjectDb() { IdProject = projectId } });
            if (res.Status)
            {
                this.LabelDelete.Text = "Project deleted.";
                this.LabelDelete.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                this.LabelDelete.Text = "Something went wrong!";
                this.LabelDelete.ForeColor = System.Drawing.Color.Red;
            }
            this.GridView1.DataBind();
        }

        protected void editing_Click(object sender, EventArgs e)
        {

            this.CheckBoxEditing.Checked = true;
            Button remove = (Button)sender;
            string[] args = remove.CommandArgument.Split(';').ToArray();
            int projectId = Convert.ToInt32(args[0]);

            this.LabelEditingId.Text = ""+projectId;
            this.tbTitle.Text = args[1];
            this.tbTag.Text = args[2];
            this.taDescription.Value = args[3];
            this.CheckBoxEditImage.Visible = true;
        }
    }
}