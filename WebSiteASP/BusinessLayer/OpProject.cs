using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSiteASP.DataLayer;

namespace WebSiteASP.BusinessLayer
{
    public class ProjectDb : DbItem
    {
        public int IdProject { get; set; }
        public int IdUser { get; set; }
        public string Title { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public DateTime TimeOfPost { get; set; }
        public int NumberOfLikes { get; set; }
        public string MainImageLink { get; set; }
        public int? IdUserLastChange { get; set; }
        public DateTime? LastTimeChanged { get; set; }

    }

    public class KriterijumProject : KriterijumZaSelekciju
    {
        public int? IdProject { get; set; }
        public int? IdUser { get; set; }
        public int? NumberOfLikes { get; set; }
    }

    public abstract class OpProjectBase : Operacija
    {
        public KriterijumProject Kriterijum { get; set; }

        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            IEnumerable<ProjectDb> ieProjects;

            if (Kriterijum != null)
            {
                ieProjects = from project in entiteti.Projects
                             where (
                                (Kriterijum.IdProject == null ? true : Kriterijum.IdProject == project.idProject) &&
                                (Kriterijum.IdUser == null ? true : Kriterijum.IdUser == project.idUser) &&
                                (Kriterijum.NumberOfLikes == null ? true : Kriterijum.NumberOfLikes < project.numberOfLikes)
                             )
                             select new ProjectDb()
                             {
                                 Description = project.description,
                                 IdProject = project.idProject,
                                 IdUser = project.idUser,
                                 LastTimeChanged = project.lastTimeChanged,
                                 NumberOfLikes = project.numberOfLikes,
                                 Tag = project.tag,
                                 TimeOfPost = project.timeOfPost,
                                 Title = project.title,
                                 MainImageLink = project.mainImageLink
                             };
            }
            else
            {
                ieProjects = from project in entiteti.Projects
                             select new ProjectDb()
                             {
                                 Description = project.description,
                                 IdProject = project.idProject,
                                 IdUser = project.idUser,
                                 LastTimeChanged = project.lastTimeChanged,
                                 NumberOfLikes = project.numberOfLikes,
                                 Tag = project.tag,
                                 TimeOfPost = project.timeOfPost,
                                 Title = project.title,
                                 MainImageLink = project.mainImageLink
                             };
            }
            OperacijaRezultat result = new OperacijaRezultat() { Status = true, Poruka = "Project Select" };
            result.DbItems = ieProjects.ToArray();
            result.CheckDbItems();

            return result;
        }
    }

    public class OpProjectSelect : OpProjectBase
    {

    }
    public class OpProjectSelectDefaultShowCase : Operacija
    {
        public int? Numer { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            IEnumerable<ProjectDb> ieProjects;

            if (Numer != null)
            {
                ieProjects =
                (from project in entiteti.Projects
                 orderby project.timeOfPost descending
                 select new ProjectDb()
                 {
                     IdProject = project.idProject,
                     NumberOfLikes = project.numberOfLikes,
                     Tag = project.tag,
                     Title = project.title,
                     MainImageLink = project.mainImageLink
                 }).Take((int)Numer);
            }
            else
            {
                ieProjects =
                (from project in entiteti.Projects
                 orderby project.timeOfPost descending
                 select new ProjectDb()
                 {
                     IdProject = project.idProject,
                     NumberOfLikes = project.numberOfLikes,
                     Tag = project.tag,
                     Title = project.title,
                     MainImageLink = project.mainImageLink
                 });
            }
            
            
            OperacijaRezultat result = new OperacijaRezultat() { Status = true, Poruka = "Project Select" };
            result.DbItems = ieProjects.ToArray();
            result.CheckDbItems();

            return result;
        }
    }
    public class OpProjectInsert : OpProjectBase
    {
        public ProjectDb Project { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Project != null)
                entiteti.spInsertProject(Project.IdUser, Project.Title, Project.Tag, Project.Description, Project.MainImageLink);
            return base.izvrsi(entiteti);
        }
    }
    public class OpProjectInsertOnly : OpProjectBase
    {
        public ProjectDb Project { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Project != null)
                entiteti.spInsertProject(Project.IdUser, Project.Title, Project.Tag, Project.Description, Project.MainImageLink);
            OperacijaRezultat rez = new OperacijaRezultat() { HaveItems = false, Status = true };
            return rez;
        }
    }
    public class OpProjectDelete : OpProjectBase
    {
        public ProjectDb Project { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Project != null)
                entiteti.spDeleteProject(Project.IdProject);
            return base.izvrsi(entiteti);
        }
    }
    public class OpProjectDeleteOnly : OpProjectBase
    {
        public ProjectDb Project { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Project != null)
                entiteti.spDeleteProject(Project.IdProject);
            return new OperacijaRezultat() {Status=true, Poruka=" only project delete", HaveItems = false };
        }
    }

    public class OpProjectUpdate : OpProjectBase
    {
        
        public ProjectDb Project { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Project != null)
            {
                this.Kriterijum.IdProject = Project.IdProject;
                entiteti.spUpdateProject(Project.IdProject,Project.Title, Project.Tag, Project.Description,Project.NumberOfLikes,Project.MainImageLink,Project.IdUserLastChange);
            }
            return base.izvrsi(entiteti);
        }
    }

    public class OpProjectUpdateOnlyWithImg : OpProjectBase
    {
        public ProjectDb Project { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Project != null)
            {
                entiteti.spUpdateProjectWithImg(Project.IdProject, Project.Title, Project.Tag, Project.Description, Project.MainImageLink, Project.IdUserLastChange);
            }
            return new OperacijaRezultat() { Status = true, Poruka = "project update with img", HaveItems = false };
        }
    }
    public class OpProjectUpdateOnlyWithoutImg : OpProjectBase
    {
        public ProjectDb Project { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Project != null)
            {
                entiteti.spUpdateProjectWithoutImg(Project.IdProject, Project.Title, Project.Tag, Project.Description, Project.IdUserLastChange);
            }
            return new OperacijaRezultat() { Status = true, Poruka = "project update without img", HaveItems = false };
        }
    }

    public class OpProjectUpdateWithImg : OpProjectBase
    {
        public ProjectDb Project { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Project != null)
            {
                entiteti.spUpdateProjectWithImg(Project.IdProject, Project.Title, Project.Tag, Project.Description, Project.MainImageLink, Project.IdUserLastChange);
            }
            return base.izvrsi(entiteti);
        }
    }
    public class OpProjectUpdateWithoutImg : OpProjectBase
    {
        public ProjectDb Project { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Project != null)
            {
                entiteti.spUpdateProjectWithoutImg(Project.IdProject, Project.Title, Project.Tag, Project.Description,Project.IdUserLastChange);
            }
            return base.izvrsi(entiteti);
        }
    }
}