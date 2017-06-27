<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebSiteASP.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Architect | Contact</title>
    <style>
        #pitanje {
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUserForm" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMenu" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphSiteBody" runat="server">
    <form id="contact" class="form-signin" runat="server">
        <div id="fh5co-contact">
			<div class="row">
				<div class="col-md-4 animate-box">
					<h3>Contact Information</h3>
					<ul class="contact-info">
						<li><i class="icon-location4"></i>198 West 21th Street, Suite 721 New York NY 10016</li>
						<li><i class="icon-phone3"></i>+ 1235 2355 98</li>
						<li><i class="icon-location3"></i><a href="#">info@yoursite.com</a></li>
						<li><i class="icon-globe2"></i><a href="#">www.yoursite.com</a></li>
					</ul>
				</div>
				<div class="col-md-8 animate-box">
					<div class="form-wrap">
						<div class="row">
							<div class="col-md-12">
								<div class="form-group">
									<input type="text" id="tbFullName" runat="server" class="form-control" placeholder="Full name">
                                    <div class="regexerror-parent">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="full name is required" ControlToValidate="tbFullName" CssClass="regexposition" ForeColor="#FF5050"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="invalid full name field" ControlToValidate="tbFullName" CssClass="regexposition" ForeColor="#FF5050" ValidationExpression="[\w\s]{2,90}"></asp:RegularExpressionValidator>
                                    </div>
								</div>
							</div>
							<div class="col-md-12">
								<div class="form-group">
									<input type="text" id="tbEmail" runat="server" class="form-control" placeholder="Email">
								    <div class="regexerror-parent">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="email is required" ControlToValidate="tbEmail" CssClass="regexposition" ForeColor="#FF5050"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="invalid email field" ControlToValidate="tbEmail" CssClass="regexposition" ForeColor="#FF5050" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
							</div>
							<div class="col-md-12">
								<div class="form-group">
									<textarea name="message" runat="server" class="form-control" id="tamessage" cols="30" rows="15" placeholder="Message"></textarea>
								    <div class="regexerror-parent">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="message is required" ControlToValidate="tamessage" CssClass="regexposition" ForeColor="#FF5050"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="invalid message field" ControlToValidate="tamessage" CssClass="regexposition" ForeColor="#FF5050" ValidationExpression="[\S\s]{2,255}"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
							</div>
							<div class="col-md-12">
								<div class="form-group">
									<asp:Button ID="Button1" runat="server" Text="Send Message" class="btn btn-primary btn-modify" OnClick="Button1_Click" />
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>







            <div class="row">
                <div class="col-md-5 col-md-push-1 animate-box fadeInUp animated-fast">
			        <div class="gtco-contact-info">
                        <h2>Poll</h2>
							<div id="votepollcont">
								
                                <asp:Panel ID="PanelPoll" runat="server">

                                </asp:Panel>

                            </div>
					    </div>
					</div>
                </div>





		</div>
    </form>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphJavascript" runat="server">
    <script>
        function ajaxVotePoll() {
            var checkedRadioButton = $("input[name=poll]:checked").val();
            var questionid = $("#questionid").val();
            $.ajax({
                url: 'AjaxPollVote.aspx',
                type: 'POST',
                data: { vote: checkedRadioButton, question: questionid },
                success: function (c) {
                    var text = "";
                    c = c.substring(0, 5);
                    if (c != "Error")
                    {
                        text = "Thank you for voting!";
                    }
                    else
                    {
                        text = "You have already voted for this poll!";
                    }
                    $("#votepollcont").html(text);
                }
            });
        }
        $(document).ready(function ()
        {
            $("#pitanje").click(function () {
                $("#odgovori").slideToggle("slow");
            });
        });
    </script>
</asp:Content>
