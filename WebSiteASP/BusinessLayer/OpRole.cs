using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSiteASP.DataLayer;

namespace WebSiteASP.BusinessLayer
{
    public class RoleDb : DbItem
    {
        public int IdRole { get; set; }
        public string RoleName { get; set; }
        public int? IdUserLastChange { get; set; }
        public DateTime? LastTimeChanged { get; set; }

    }
    public abstract class OpRoleBase : Operacija
    {
        public KriterijumRole Kriterijum { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            IEnumerable<RoleDb> ieRole;
            if (Kriterijum != null)
            {
                ieRole = from role in entiteti.Roles
                         where (Kriterijum.IdRole == null ? true : Kriterijum.IdRole == role.idRole)
                         select new RoleDb()
                         {
                             IdRole = role.idRole,
                             RoleName = role.roleName
                         };
            }
            else
            {
                ieRole = from role in entiteti.Roles
                         select new RoleDb()
                         {
                             IdRole = role.idRole,
                             RoleName = role.roleName
                         };
            }
            OperacijaRezultat result = new OperacijaRezultat()
            {
                Status = true,
                Poruka = "Select Roles",
                DbItems = ieRole.ToArray()
            };
            result.CheckDbItems();
            return result;
        }
    }
    public class KriterijumRole : KriterijumZaSelekciju
    {
        public int? IdRole { get; set; }
    }
    public class OpRoleSelect : OpRoleBase
    {

    }

    public class OpRoleDelete : OpRoleBase
    {
        public RoleDb Role { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Role != null)
                entiteti.spDeleteRole(Role.IdRole);
            return base.izvrsi(entiteti);
        }
    }

    public class OpRoleInsert : OpRoleBase
    {
        public RoleDb Role { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Role != null)
                entiteti.spInsertRole(Role.RoleName);
            return base.izvrsi(entiteti);
        }
    }

    public class OpRoleUpdate : OpRoleBase
    {
        public RoleDb Role { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Role != null)
                entiteti.spUpdateRole(Role.IdRole, Role.RoleName, Role.IdUserLastChange);
            return base.izvrsi(entiteti);
        }
    }
}