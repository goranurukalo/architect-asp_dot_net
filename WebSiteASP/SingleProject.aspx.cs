using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSiteASP.BusinessLayer;
using WebSiteASP.Helpers;

namespace WebSiteASP
{
    public partial class SingleProject : WebSiteASP.Base
    {
        public int ProjectId { get; set; }

        protected override void DoBeforePageLoad()
        {
            this.ThisPageName = "SingleProject.aspx";

            string inputId = Request.QueryString["projectid"];
            if (inputId != null)
            {
                Regex rgx = new Regex(@"^\d{1,32}$");
                if (!rgx.IsMatch(inputId))
                    Response.Redirect("Default.aspx");
                else
                    this.ProjectId = Convert.ToInt32(inputId);
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
        protected override void DoAfterPageLoad()
        {
            OperacijaRezultat res = OperationManager.Singleton.izvrsiOperaciju(new OpFullProject() { Kriterijum = new KriterijumFullProject() { IdProject = ProjectId }});
            if (res.Status && res.HaveItems)
            {
                bool candelete = false;
                FullProjectDb full = res.DbItems.Cast<FullProjectDb>().ToArray()[0];
                this.singleprojectTitle.InnerText = full.Project.Title;
                full.Project.MainImageLink = ResolveClientUrl(full.Project.MainImageLink);

                if(Session["idUser"] != null)
                    if (full.Project.IdUser == (int)Session["idUser"])
                    {
                        this.PanelAddImage.Visible = true;
                        candelete = true;
                    }

                foreach (ImageDb img in full.Images)
                {
                    img.BigPictureUrl = ResolveClientUrl(img.BigPictureUrl);//.Substring(1)
                    img.SmallPictureUrl = ResolveClientUrl(img.SmallPictureUrl);
                }
                this.PanelSingleProject.Controls.Add(ProjectsPresentation.MakeSingleProject(full, candelete));
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                UploadImageDb img = UploadFile.UploadImage(this.FileUploadImage, Server.MapPath("~/Upload/"), true);
                if (img.IsUploaded)
                {
                    ImageDb image = new ImageDb()
                    {
                        IdProject = ProjectId,
                        ImageName = this.tbImageName.Text,
                        ImgAlt = this.tbImageAlt.Text,
                        SmallPictureUrl = img.SmallPictureUrl,
                        BigPictureUrl = img.BigPictureUrl
                    };

                    OperacijaRezultat res = OperationManager.Singleton.izvrsiOperaciju(new OpImageInsertOnly() {Image = image });
                    if (res.Status)
                    {
                        Response.Redirect("/SingleProject.aspx?projectid=" + ProjectId);
                    }
                    else
                    {
                        this.LabelMessage.Visible = true;
                        this.LabelMessage.Text = "something went wrong. we couldnt insert into database";
                    }
                }
                else
                {
                    this.LabelMessage.Visible = true;
                    this.LabelMessage.Text = "something went wrong. we couldnt upload image";
                }
            }
            
        }
    }
}