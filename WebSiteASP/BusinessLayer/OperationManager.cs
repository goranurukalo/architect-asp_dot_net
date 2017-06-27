using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteASP.DataLayer;

namespace WebSiteASP.BusinessLayer
{
    public class OperationManager
    {
        
        #region Singleton
        private OperationManager() { }
        private static volatile OperationManager singleton;
        private static object syncRoot = new object();

        public static OperationManager Singleton
        {
            get
            {
                if (OperationManager.singleton == null)
                {
                    lock (OperationManager.syncRoot)
                    {
                        if (OperationManager.singleton == null)
                            OperationManager.singleton = new OperationManager();
                    }
                }
                return OperationManager.singleton;
            }
        }
        #endregion

        private ArchitectDatabaseEntities entiteti = new ArchitectDatabaseEntities();

        public OperacijaRezultat izvrsiOperaciju(Operacija op)
        {
            try
            {
                return op.izvrsi(this.entiteti);
            }
            catch(Exception e)
            {
                OperacijaRezultat obj = new OperacijaRezultat();
                obj.Status = false;
        #if DEBUG
                obj.Poruka = e.Message;
        #endif
                return obj;
            }
        }
    }
}
