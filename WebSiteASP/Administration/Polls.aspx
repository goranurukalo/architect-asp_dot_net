<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Polls.aspx.cs" Inherits="WebSiteASP.Administration.Polls" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Admin Panel | Polls</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUserForm" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMenu" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphSiteBody" runat="server">
    <form id="form1" runat="server">
        <div class="row">
            <nav class="fh5co-nav">
                <ul>
                    <li><a href="/Administration/Users.aspx">Users</a></li>
                    <li><a href="/Administration/Projects.aspx">Projects</a></li>
                    <li><a href="/Administration/Menus.aspx">Menus</a></li>
                    <li class="active"><a href="/Administration/Polls.aspx">Polls</a></li>
                    <li><a href="/Administration/Roles.aspx">Roles</a></li>
                    <li><a href="/Administration/Status.aspx">Status</a></li>
                </ul>
            </nav>
        </div>
        <div class="row" style="margin-top: 50px">
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:GridView ID="GridViewPolls" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="PollQuestion" HeaderText="Poll question" SortExpression="PollQuestion" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:Button Text="Edit" runat="server" ID="btnEditPoll" OnClick="btnEditPoll_Click" CommandName="Edit" CommandArgument='<%# Eval("IdPollQuestion") + ";" + Eval("PollQuestion") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:Button Text="Delete" runat="server" ID="btnDeletePoll" OnClick="btnDeletePoll_Click" CommandName="Delete" CommandArgument='<%# Eval("IdPollQuestion") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            
                        </asp:GridView>
                    </td>
                    <td>
                        <asp:Panel ID="PanelShowData" Visible="false" runat="server">
                            <table style="width:100%;">
                                <tr>
                                    <td>Poll question</td>
                                    <td>
                                        <asp:TextBox ID="tbPollQuestion" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelPollQuestionId" runat="server" Text="Label" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="ButtonUpdatePollQuestion" runat="server" OnClick="ButtonUpdatePollQuestion_Click" Text="Update" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>Add Poll Answer</td>
                                    <td>
                                        <asp:TextBox ID="tbAddPollAnswer" runat="server"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="Add" runat="server" Text="Add" OnClick="Add_Click" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListPollAnswers" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPollAnswers_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>Poll answer</td>
                                    <td>
                                        <asp:TextBox ID="tbPollAnswerUpdate" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btnUpdatePollAnswer" runat="server" OnClick="btnUpdatePollAnswer_Click" Text="Update" />
                                        <asp:Button ID="tbDeletePollAnswer" runat="server" OnClick="tbDeletePollAnswer_Click" Text="Delete" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
        <div class="row top-buffer">
            <h3>Add new Poll Question</h3>
            <asp:Panel ID="PanelAddRole" CssClass="row" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>Poll Question</td>
                        <td>
                            <asp:TextBox ID="add_TextBoxPollQuestion" runat="server"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="ButtonAddPollQuestion" runat="server" OnClick="ButtonAddPollQuestion_Click" Text="Add" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphJavascript" runat="server">
</asp:Content>
