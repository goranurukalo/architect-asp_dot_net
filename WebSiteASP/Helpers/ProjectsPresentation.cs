using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using WebSiteASP.BusinessLayer;

namespace WebSiteASP.Helpers
{
    public class ProjectsPresentation
    {
        public static LiteralControl MakeSliderForDefault(ProjectDb[] projects)
        {
            LiteralControl slideshow = new LiteralControl();

            slideshow.Text += "<ul class='slides'>";

            foreach (ProjectDb p in projects)
            {
                slideshow.Text += "<li style='background-image: url(" + p.MainImageLink + ");'>"+
                                        "<div class='overlay'></div>"+
                                        "<div class='container-fluid'>" +
                                            "<div class='row'>" +
                                                "<div class='col-md-6 col-xs-8 col-md-offset-1 slider-text'>" +
                                                    "<div class='slider-text-inner'>" +
                                                        "<h1><a href='SingleProject.aspx?projectid="+p.IdProject+"' >" + p.Title+"</a></h1>" +
                                                        "<h2>"+p.Tag+"</h2>" +
                                                    "</div>" +
                                                "</div>" +
                                            "</div>" +
                                        "</div>" +
			   	                    "</li>";
            }

            slideshow.Text += "</ul>";

            return slideshow;
        }
        public static LiteralControl MakeProjectShowCaseDefault(ProjectDb[] projects)
        {
            string leftside, rightside;

            leftside = @"<div class='col-md-6 padding-left'>";
            rightside = @"<div class='col-md-6 padding-right'>";

            for (int i = 0; i < projects.Length; i++)
            {
                string pattern = @"<div class='col-md-12 animate-box'>" +
                                    "<a href='SingleProject.aspx?projectid="+projects[i].IdProject+"' class='portfolio-grid'>" +
                                        "<img src='"+ projects[i].MainImageLink+ "' class='img-responsive' alt='"+ projects[i].Tag+ "'>" +
                                        "<div class='desc'>" +
                                            "<h3>"+ projects[i].Title+ "</h3>" +
                                            "<span>"+ projects[i].Tag+ "</span>" +
                                        "</div>" +
                                    "</a>" +
                                "</div>";
                if (i % 2 == 0)
                {
                    leftside += pattern;
                }
                else
                {
                    rightside += pattern;
                }
            }

            leftside += @"</div>";
            rightside += @"</div>";


            //posalji sledecih 10 projekata
            return new LiteralControl(rightside + leftside);
        }

        public static LiteralControl MakeSingleProject(FullProjectDb fullproject, bool canDelete)
        {
            LiteralControl lit = new LiteralControl();

            
            lit.Text += @"<div class='col-md-4 col-md-push-8 sticky-parent'>"+
                    "<div class='detail' id='sticky_item'>" +
                        "<div class='animate-box'>" +
                            "<h2>" + fullproject.Project.Title + "</h2>" +
                            "<span>" + fullproject.Project.Tag + "</span>" +
                            "<p>" + fullproject.Project.Description + "</p>" +
                        "</div>" +
                    "</div>" +
                "</div>";

            lit.Text += @"<div class='col-md-7 col-md-pull-4 image-content'>";
            lit.Text += @"<div class='image-item  animate-box'>" +
                                "<img src='"+fullproject.Project.MainImageLink+"' class='img-responsive' alt='"+fullproject.Project.Tag+"'>" +
                            "</div>";
           
            
            
            
            
            
            
            
            
            
            
            
            if (canDelete)
            {
                //dodati button da se moze obrisati img
                foreach (ImageDb img in fullproject.Images)
                {
                    lit.Text += @"<div class='image-item img-single-small animate-box'>" +
                                    "<a href='" + img.BigPictureUrl + "' data-lightbox='singleProject' data-title='" + img.ImageName + "'>" +
                                    "<img src='" + img.SmallPictureUrl + "' class='img-responsive' alt='" + img.ImgAlt + "'>" +
                                    "</a>" +
                                    "<input id='delete' value='Delete' type='button' class='btn btn-primary' onclick='ajax_imgDelete(this, " + img.IdImage + ");'/>" +
                                "</div>";
                }
            }
            else
            {
                foreach (ImageDb img in fullproject.Images)
                {
                    lit.Text += @"<div class='image-item img-single-small animate-box'>" +
                                    "<a href='" + img.BigPictureUrl + "' data-lightbox='singleProject' data-title='" + img.ImageName + "'>" +
                                    "<img src='" + img.SmallPictureUrl + "' class='img-responsive' alt='" + img.ImgAlt + "'>" +
                                    "</a>" +
                                "</div>";
                }
            }
            


            
















            lit.Text += @"</div>";

            return lit;
        }
    }
}