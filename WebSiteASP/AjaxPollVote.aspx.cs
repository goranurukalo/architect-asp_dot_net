using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSiteASP.BusinessLayer;
using System.Web.Services;

namespace WebSiteASP
{
    public partial class AjaxPollVote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string json;
            using (var reader = new StreamReader(Request.InputStream))
            {
                json = reader.ReadToEnd();
            }
            string[] items = json.Split('&');
            int id = Convert.ToInt32(items[0].Split('=')[1]);
            int qid = Convert.ToInt32(items[1].Split('=')[1]);

            OperacijaRezultat res = OperationManager.Singleton.izvrsiOperaciju(new OpPollVoteInsert() { Vote = new PollVoteDb() { IdAnswer = id, IpAddress = Request.UserHostAddress, IdQuestion = qid } });
            if (res.Status)
                Response.Write("Success");
            else
                Response.Write("Error");
        }

        [WebMethod]
        public string Vote(string _id ,string _qid)
        {
            int id = Convert.ToInt32(_id);
            int qid = Convert.ToInt32(_qid);
            OperacijaRezultat res = OperationManager.Singleton.izvrsiOperaciju(new OpPollVoteInsert() { Vote = new PollVoteDb() { IdAnswer = id, IpAddress = Request.UserHostAddress, IdQuestion = qid } });
            if (res.Status)
                return "Success";
            else
                return "Error";
            
        }
    }
}