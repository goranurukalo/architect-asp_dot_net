using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSiteASP.BusinessLayer;

namespace WebSiteASP.Administration
{
    public partial class Polls : WebSiteASP.Base
    {
        protected override void DoBeforePageLoad()
        {
            this.ThisPageName = "Administration.aspx";
            this.OnlyAuthorizedUsers();
            this.OnlyAdmin();
        }
        protected override void DoAfterPageLoad()
        {
            this.GridViewPolls.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpPollQuestionSelect()).DbItems.Cast<PollQuestionDb>().ToArray();
            this.GridViewPolls.DataBind();
        }

        protected override void DoWithoutPostBack()
        {
            this.PanelShowData.Visible = false;
        }

        protected void btnEditPoll_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string[] args = btn.CommandArgument.Split(';').ToArray();
            this.PanelShowData.Visible = true;
            this.LabelPollQuestionId.Text = args[0];
            this.tbPollQuestion.Text = args[1];
            this.tbPollAnswerUpdate.Text = "";
            this.tbAddPollAnswer.Text = "";


            this.DropDownListPollAnswers.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpPollSelectOnlyAnswer() { PollQuestion = new PollQuestionDb() { IdPollQuestion = Convert.ToInt32(this.LabelPollQuestionId.Text)} }).DbItems.Cast<PollAnswersDb>().ToArray();
            this.DropDownListPollAnswers.DataTextField = "PollAnswer";
            this.DropDownListPollAnswers.DataValueField = "IdPollAnswer";
            this.DropDownListPollAnswers.DataBind();
            if(this.DropDownListPollAnswers.Items.Count>0)
                this.tbPollAnswerUpdate.Text = this.DropDownListPollAnswers.Items[0].Text;
        }

        protected void btnDeletePoll_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            PollQuestionDb pq = new PollQuestionDb()
            {
                IdPollQuestion = Convert.ToInt32(btn.CommandArgument)
            };
            this.GridViewPolls.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpPollDeleteQuestion(){ PollQuestion = pq }).DbItems.Cast<PollQuestionDb>().ToArray();
            this.GridViewPolls.DataBind();

            this.PanelShowData.Visible = false;
        }

        protected void ButtonAddPollQuestion_Click(object sender, EventArgs e)
        {
            PollQuestionDb pq = new PollQuestionDb()
            {
                PollQuestion = this.add_TextBoxPollQuestion.Text
            };
            this.GridViewPolls.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpPollInsertOnlyQuestion() {PollQuestion = pq }).DbItems.Cast<PollQuestionDb>().ToArray();
            this.GridViewPolls.DataBind();
        }

        protected void btnUpdatePollAnswer_Click(object sender, EventArgs e)
        {
            PollAnswersDb ans = new PollAnswersDb()
            {
                IdPollAnswer = Convert.ToInt32(this.DropDownListPollAnswers.SelectedValue),
                PollAnswer = this.tbPollAnswerUpdate.Text
            };
            PollQuestionDb pq = new PollQuestionDb()
            {
                IdPollQuestion = Convert.ToInt32(this.LabelPollQuestionId.Text)
            };
            this.DropDownListPollAnswers.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpPollUpdateOnlyAnswer() { Answer = ans, PollQuestion = pq }).DbItems.Cast<PollAnswersDb>().ToArray();
            this.DropDownListPollAnswers.DataTextField = "PollAnswer";
            this.DropDownListPollAnswers.DataValueField = "IdPollAnswer";
            this.DropDownListPollAnswers.DataBind();
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            PollAnswersDb ans = new PollAnswersDb()
            {
                PollAnswer = this.tbAddPollAnswer.Text
            };
            PollQuestionDb pq = new PollQuestionDb()
            {
                IdPollQuestion = Convert.ToInt32(this.LabelPollQuestionId.Text)
            };
            this.DropDownListPollAnswers.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpPollInsertOnlyAnswer() { Answer = ans, PollQuestion = pq}).DbItems.Cast<PollAnswersDb>().ToArray();
            this.DropDownListPollAnswers.DataTextField = "PollAnswer";
            this.DropDownListPollAnswers.DataValueField = "IdPollAnswer";
            this.DropDownListPollAnswers.DataBind();
        }

        protected void ButtonUpdatePollQuestion_Click(object sender, EventArgs e)
        {
            PollQuestionDb pq = new PollQuestionDb()
            {
                IdPollQuestion = Convert.ToInt32(this.LabelPollQuestionId.Text),
                PollQuestion = this.tbPollQuestion.Text
            };
            this.GridViewPolls.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpPollUpdateOnlyQuestion() { PollQuestion = pq }).DbItems.Cast<PollQuestionDb>().ToArray();
            this.GridViewPolls.DataBind();
        }

        protected void tbDeletePollAnswer_Click(object sender, EventArgs e)
        {
            PollAnswersDb ans = new PollAnswersDb()
            {
                IdPollAnswer = Convert.ToInt32(this.DropDownListPollAnswers.SelectedValue)
            };
            PollQuestionDb pq = new PollQuestionDb()
            {
                IdPollQuestion = Convert.ToInt32(this.LabelPollQuestionId.Text)
            };
            this.DropDownListPollAnswers.DataSource = OperationManager.Singleton.izvrsiOperaciju(new OpPollDeleteOnlyAnswer() { Answer = ans, PollQuestion = pq }).DbItems.Cast<PollAnswersDb>().ToArray();
            this.DropDownListPollAnswers.DataTextField = "PollAnswer";
            this.DropDownListPollAnswers.DataValueField = "IdPollAnswer";
            this.DropDownListPollAnswers.DataBind();
            if (this.DropDownListPollAnswers.Items.Count > 0)
                this.tbPollAnswerUpdate.Text = this.DropDownListPollAnswers.Items[0].Text;

        }

        protected void DropDownListPollAnswers_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tbPollAnswerUpdate.Text = this.DropDownListPollAnswers.SelectedItem.Text;
        }
    }
}