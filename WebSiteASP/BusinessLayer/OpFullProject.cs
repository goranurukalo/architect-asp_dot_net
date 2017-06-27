using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSiteASP.DataLayer;

namespace WebSiteASP.BusinessLayer
{
    public class ImageDb : DbItem
    {
        public int IdImage { get; set; }
        public int IdProject { get; set; }
        public string SmallPictureUrl { get; set; }
        public string BigPictureUrl { get; set; }
        public string ImgAlt { get; set; }
        public string ImageName { get; set; }
        public int? IdUserLastChange { get; set; }
        public DateTime? LastTimeChanged { get; set; }

    }
    public class FullProjectDb : DbItem
    {
        public ProjectDb Project { get; set; }
        public ImageDb[] Images { get; set; }
    }
    public class OpFullProject : Operacija
    {
        public KriterijumFullProject Kriterijum { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            FullProjectDb full = new FullProjectDb();

            full.Project = (from project in entiteti.Projects
                            where (Kriterijum.IdProject == null ? true : Kriterijum.IdProject == project.idProject)
                            select new ProjectDb()
                            {
                                IdProject = project.idProject,
                                IdUser = project.idUser,
                                Description = project.description,
                                MainImageLink = project.mainImageLink,
                                Title = project.title,
                                Tag = project.tag
                            }).ToArray()[0];
            IEnumerable<ImageDb> images = from img in entiteti.Images
                                          where (Kriterijum.IdProject == null ? true : Kriterijum.IdProject == img.idProject)
                                          select new ImageDb()
                                          {
                                              IdImage = img.idImage,
                                              BigPictureUrl = img.bigPictureUrl,
                                              ImageName = img.imageName,
                                              ImgAlt = img.imgAlt,
                                              SmallPictureUrl = img.smallPictureUrl
                                          };

            full.Images = images.ToArray();
            OperacijaRezultat result = new OperacijaRezultat();
            DbItem[] i = new DbItem[1];
            i[0] = full;
            result.DbItems = i;
            result.Status = true;
            result.CheckDbItems();
            return result;
        }
    }
    public class KriterijumFullProject : KriterijumZaSelekciju
    {
        public int? IdProject { get; set; }
    }
    public class KriterijumImage : KriterijumZaSelekciju
    {
        public int? IdImage { get; set; }
    }
    public class OpImageInsertOnly : Operacija
    {
        public ImageDb Image { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Image != null)
                entiteti.spInsertImage(Image.IdProject, Image.SmallPictureUrl, Image.BigPictureUrl, Image.ImgAlt, Image.ImageName);
            return new OperacijaRezultat(){ Status = true, HaveItems= false};
        }
    }

    public class OpImageDeleteOnly : Operacija
    {
        public KriterijumImage Kriterijum { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Kriterijum != null)
                entiteti.spDeleteImage(Kriterijum.IdImage);
            return new OperacijaRezultat() { Status = true, HaveItems = false };
        }
    }
    public class OpImageSelect : Operacija
    {
        public KriterijumFullProject Kriterijum { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            IEnumerable<ImageDb> ieImages;
            if (Kriterijum != null)
            {
                ieImages = from img in entiteti.Images
                           where (Kriterijum.IdProject == null ? true : Kriterijum.IdProject == img.idProject)
                           select new ImageDb()
                           {
                               BigPictureUrl = img.bigPictureUrl,
                               IdImage = img.idImage,
                               ImageName = img.imageName,
                               ImgAlt = img.imgAlt,
                               SmallPictureUrl = img.smallPictureUrl
                           };
            }
            else
            {
                ieImages = from img in entiteti.Images
                           select new ImageDb()
                           {
                               BigPictureUrl = img.bigPictureUrl,
                               IdImage = img.idImage,
                               ImageName = img.imageName,
                               ImgAlt = img.imgAlt,
                               SmallPictureUrl = img.smallPictureUrl
                           };
            }
            OperacijaRezultat result = new OperacijaRezultat();
            result.DbItems = ieImages.ToArray();
            result.Status = true;
            result.CheckDbItems();
            return result;
        }
    }
    public class OpImageInsert : OpImageSelect
    {
        public ImageDb Image { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Image != null)
                entiteti.spInsertImage(Image.IdProject, Image.SmallPictureUrl, Image.BigPictureUrl, Image.ImgAlt, Image.ImageName);
            return base.izvrsi(entiteti);
        }
    }

    public class OpImageDelete : OpImageSelect
    {
        public ImageDb Image { get; set; }

        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Image != null)
                entiteti.spDeleteImage(Image.IdImage);
            return base.izvrsi(entiteti);
        }
    }
    public class OpImageUpdate : OpImageSelect
    {
        public ImageDb Image { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Image != null)
                entiteti.spUpdateImage(Image.IdImage, Image.SmallPictureUrl, Image.BigPictureUrl, Image.ImgAlt, Image.ImageName,Image.IdUserLastChange);
            return base.izvrsi(entiteti);
        }
    }
    public class OpImageUpdateWithoutImg : OpImageSelect
    {
        public ImageDb Image { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Image != null)
                entiteti.spUpdateImageWithoutImage(Image.IdImage, Image.ImgAlt, Image.ImageName, Image.IdUserLastChange);
            return base.izvrsi(entiteti);
        }
    }
}