using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSiteASP.BusinessLayer;

namespace WebSiteASP
{
    public partial class Contact : WebSiteASP.Base
    {
        protected override void DoBeforePageLoad()
        {
            this.ThisPageName = "Contact.aspx";
        }
        
        protected override void DoAfterPageLoad()
        {
            //generisi anketu
            LiteralControl poll = new LiteralControl();
            PollDb[] res = OperationManager.Singleton.izvrsiOperaciju(new OpPollSelect()).DbItems.Cast<PollDb>().ToArray();
            
            poll.Text = @"<h3 id='pitanje'>"+res[0].PollQuestion+"</h3><div id='odgovori'>" +
                "<input type='hidden' id='questionid' value='"+res[0].IdPollQuestion+"'/>";
            foreach (PollAnswersDb a in res[0].answers)
            {
                poll.Text += @"<div class='radio'><label><input type='radio' name='poll' value='" + a.IdPollAnswer+"'>"+a.PollAnswer+"</label></div>";
            }
            poll.Text += @"<button name='button' type='button' id='button' value='true' class='btn btn-primary' onclick='ajaxVotePoll();'>Vote</button></div>";

            this.PanelPoll.Controls.Add(poll);
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.Page.IsValid)
            {
                //
                // posto ovo nije hostovano, pritom nemamo email server, bacilo bi gresku
                //

                //this.sendEmail();
            }
        }

        private void sendEmail()
        {
            //send email
            SmtpClient smtpClient = new SmtpClient("mail.goranurukalo.com", 25);

            smtpClient.Credentials = new System.Net.NetworkCredential("info@goranurukalo.com", "123");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("info@goranurukalo");
            mail.To.Add(new MailAddress("admin@goranurukalo"));
            mail.CC.Add(new MailAddress(this.tbEmail.Value.Trim()));
            mail.Subject = "Contact form";
            mail.Body = "New message\n" +
                "From: " + this.tbEmail.Value + "\n" +
                "Name: " + this.tbFullName.Value + "\n" +
                "Message: " + this.tamessage.Value;

            smtpClient.Send(mail);
        }
    }
}