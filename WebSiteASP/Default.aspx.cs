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
    public partial class Default : WebSiteASP.Base
    {
        protected override void DoAfterPageLoad()
        {
            OperacijaRezultat rez = OperationManager.Singleton.izvrsiOperaciju(new OpProjectSelectDefaultShowCase() { Numer = 15});

            ProjectDb[] projects = rez.DbItems.Cast<ProjectDb>().ToArray();
            foreach (ProjectDb p in projects)
            {
                p.MainImageLink = ResolveClientUrl(p.MainImageLink);
            }

            ProjectDb[] projectsSlider, projectsShowCase;
            projectsSlider = projects.Take(5).ToArray();
            projectsShowCase = projects.Skip(5).ToArray();

            //prihvati i stavi de treba
            this.PanelSlider.Controls.Add(ProjectsPresentation.MakeSliderForDefault(projectsSlider));
            
            //prihvati i stavi de treba
            this.showcase.Controls.Add(ProjectsPresentation.MakeProjectShowCaseDefault(projectsShowCase));
        }
    }
}