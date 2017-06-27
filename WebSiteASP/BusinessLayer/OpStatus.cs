using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSiteASP.DataLayer;

namespace WebSiteASP.BusinessLayer
{
    public class StatusDb : DbItem
    {
        public int IdStatus { get; set; }
        public string StatusName { get; set; }
        public int? IdUserLastChange { get; set; }
        public DateTime? LastTimeChanged { get; set; }

    }
    public class KriterijumStatus : KriterijumZaSelekciju
    {
        public int? IdStatus { get; set; }
    }
    public abstract class OpStatusBase : Operacija
    {
        public KriterijumStatus Kriterijum { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            IEnumerable<StatusDb> ieStatus;
            if (Kriterijum != null)
            {
                ieStatus = from status in entiteti.Status
                         where (Kriterijum.IdStatus == null ? true : Kriterijum.IdStatus == status.idStatus)
                         select new StatusDb()
                         {
                             IdStatus = status.idStatus,
                             StatusName = status.statusName
                         };
            }
            else
            {
                ieStatus = from status in entiteti.Status
                           select new StatusDb()
                           {
                               IdStatus = status.idStatus,
                               StatusName = status.statusName
                           };
            }
            OperacijaRezultat result = new OperacijaRezultat()
            {
                Status = true,
                Poruka = "Select Roles",
                DbItems = ieStatus.ToArray()
            };
            result.CheckDbItems();
            return result;
        }
    }

    public class OpStatusSelect : OpStatusBase
    {

    }

    public class OpStatusInsert : OpStatusBase
    {
        public StatusDb Status { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Status != null)
                entiteti.spInsertStatus(Status.StatusName);
            return base.izvrsi(entiteti);
        }
    }
    public class OpStatusUpdate : OpStatusBase
    {
        public StatusDb Status { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Status != null)
                entiteti.spUpdateStatus(Status.IdStatus, Status.StatusName, Status.IdUserLastChange);
            return base.izvrsi(entiteti);
        }
    }
    public class OpStatusDelete : OpStatusBase
    {
        public StatusDb Status { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Status != null)
                entiteti.spDeleteStatus(Status.IdStatus);    
            return base.izvrsi(entiteti);
        }
    }
}