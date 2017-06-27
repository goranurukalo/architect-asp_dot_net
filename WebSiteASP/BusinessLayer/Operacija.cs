using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteASP.DataLayer;

namespace WebSiteASP.BusinessLayer
{
    public abstract class Operacija
    {
        public abstract OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti);
    }
        
    public class OperacijaRezultat
    {
        public string Poruka { get; set; }
        public bool Status { get; set; }
        public bool HaveItems { get; set; }

        public DbItem[] DbItems { get; set; }

        public void CheckDbItems()
        {
            if (this.DbItems != null && this.DbItems.Length > 0)
                this.HaveItems = true;
            else
                this.HaveItems = false;
        }
    }

    public abstract class DbItem
    {
    }

    public abstract class KriterijumZaSelekciju
    {
    }

}
