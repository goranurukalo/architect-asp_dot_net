using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSiteASP.BusinessLayer;

namespace WebSiteASP
{
    public partial class AjaxImageDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idUser"] == null)
                return;
            else
            {
                string json;
                using (var reader = new StreamReader(Request.InputStream))
                {
                    json = reader.ReadToEnd();
                }
                int imgid = Convert.ToInt32(json.Split('=')[1]);

                OperacijaRezultat res = OperationManager.Singleton.izvrsiOperaciju(new OpImageDeleteOnly() { Kriterijum = new KriterijumImage() { IdImage = imgid } });
                if (res.Status)
                    Response.Write("Success");
                else
                    Response.Write("Error");
            }
        }

        [WebMethod]
        public string ImageDelete(string id)
        {
            int imgid = Convert.ToInt32(id);
            OperacijaRezultat res = OperationManager.Singleton.izvrsiOperaciju(new OpImageDeleteOnly() { Kriterijum = new KriterijumImage() { IdImage = imgid } });
            if (res.Status)
                return "Success";
            else
                return "Error";

        }
    }
}