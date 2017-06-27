using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using WebSiteASP.BusinessLayer;

namespace WebSiteASP.Helpers
{
    public class MenuMethods
    {
        public static LiteralControl MakeMenuLinks(MenuDb[] items, string pageName)
        {
            LiteralControl menuLinks = new LiteralControl();
            foreach (MenuDb m in items)
            {
                if (m.Link.Substring(m.Link.LastIndexOf('/')+1) == pageName)
                    menuLinks.Text += @"<li class='active'><a href='" + m.Link + "'>" + m.Title + "</a></li>";
                else
                    menuLinks.Text += @"<li><a href='" + m.Link + "'>" + m.Title + "</a></li>";
            }
            return menuLinks;
        }

        public static LiteralControl MakeUserLinks(int roleId)
        {
            LiteralControl userLinks = new LiteralControl();

            if (roleId < 3)
            {
                userLinks.Text += @"<li role='presentation'><a href='/Logout.aspx'>Logout</a></li>";
            }
            else
            {
                userLinks.Text += @"<li role='presentation'><a href='/Login.aspx'>Login</a></li>";
                userLinks.Text += @"<li role='presentation'><a href='/Register.aspx'>Register</a></li>";
            }
            return userLinks;
        }
    }
}