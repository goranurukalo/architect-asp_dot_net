using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSiteASP.Helpers
{
    public class SessionMethodes
    {
        public static int RoleId(object id)
        {
            if (id == null)
                return 3;
            else
                return (int)id;
        }
    }
}