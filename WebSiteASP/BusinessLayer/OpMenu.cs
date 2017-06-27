using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSiteASP.DataLayer;

namespace WebSiteASP.BusinessLayer
{
    public class MenuDb : DbItem
    {
        public int IdMenu { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public int? IdRole { get; set; }
        public int? IdUserLastChange { get; set; }
        public DateTime? LastTimeChanged { get; set; }

    }
    public class KriterijumMenu : KriterijumZaSelekciju
    {
        public int? IdMenu { get; set; }
        public int? idRole { get; set; }
    }
    public class OpMenuBase : Operacija
    {
        public KriterijumMenu Kriterijum { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            IEnumerable<MenuDb> ieMenu;

            if (Kriterijum != null)
            {
                ieMenu = from menu in entiteti.Menus
                         where ((Kriterijum.IdMenu == null ? true : Kriterijum.IdMenu == menu.idMenu) && (Kriterijum.idRole == null ? true : Kriterijum.idRole <= menu.idRole))
                         select new MenuDb()
                         {
                             IdMenu = menu.idMenu,
                             Link = menu.link,
                             Title = menu.title
                         };
            }
            else
            {
                ieMenu = from menu in entiteti.Menus
                         select new MenuDb()
                         {
                             IdMenu = menu.idMenu,
                             Link = menu.link,
                             Title = menu.title,
                             IdRole = menu.idRole
                         };
            }

            OperacijaRezultat rez = new OperacijaRezultat();
            rez.Status = true;
            rez.Poruka = "Select Menu";
            rez.DbItems = ieMenu.ToArray();
            rez.CheckDbItems();

            return rez;
        }
    }
    public class OpMenuSelect : OpMenuBase
    {
        public static OperacijaRezultat SelectMenuByRole(int idRole = 3)
        {
            KriterijumMenu kriterijum = new KriterijumMenu() { idRole = idRole };
            return OperationManager.Singleton.izvrsiOperaciju(new OpMenuSelect() { Kriterijum = kriterijum });
        }
    }

    public class OpMenuInsert : OpMenuBase
    {
        public MenuDb Menu { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Menu != null)
                entiteti.spInserteMenu(Menu.Title, Menu.Link, Menu.IdRole);
            return base.izvrsi(entiteti);
        }
    }

    public class OpMenuUpdate : OpMenuBase
    {
        public MenuDb Menu { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Menu != null)
                entiteti.spUpdateMenu(Menu.IdMenu, Menu.Title, Menu.Link, Menu.IdRole, Menu.IdUserLastChange);
            return base.izvrsi(entiteti);
        }
    }
    public class OpMenuDelete : OpMenuBase
    {
        public MenuDb Menu { get; set; }
        public override OperacijaRezultat izvrsi(ArchitectDatabaseEntities entiteti)
        {
            if (Menu != null)
                entiteti.spDeleteMenu(Menu.IdMenu);
            return base.izvrsi(entiteti);
        }
    }
}