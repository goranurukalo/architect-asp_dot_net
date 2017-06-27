<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="WebSiteASP.Administration.Users"  EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Admin Panel | Users</title>
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
                    <li class="active"><a href="/Administration/Users.aspx">Users</a></li>
                    <li><a href="/Administration/Projects.aspx">Projects</a></li>
                    <li><a href="/Administration/Menus.aspx">Menus</a></li>
                    <li><a href="/Administration/Polls.aspx">Polls</a></li>
                    <li><a href="/Administration/Roles.aspx">Roles</a></li>
                    <li><a href="/Administration/Status.aspx">Status</a></li>
                </ul>
            </nav>
        </div>
        <div class="row" style="margin-top: 50px">
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="firstName" />
                                <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="lastName" />
                                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:Button Text="Edit" runat="server" ID="btnEditUser" OnClick="btnEditUser_Click" CommandName="Edit" CommandArgument='<%# Eval("IdUser")+";"+Eval("FirstName")+";"+Eval("LastName")+";"+Eval("Email")+";"+Eval("Password")+";"+Eval("IdRole")+";"+Eval("IdStatus") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:Button Text="Delete" runat="server" ID="btnDeleteUser" OnClick="btnDeleteUser_Click" CommandName="Delete" CommandArgument='<%# Eval("IdUser") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td>
                        <asp:Panel ID="PanelEditUser" Visible="false" runat="server">
                            <table style="width: 100%;">
                                <tr>
                                    <td>First Name</td>
                                    <td>
                                        <asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelUserId" runat="server" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Last Name</td>
                                    <td>
                                        <asp:TextBox ID="tbLastName" runat="server"></asp:TextBox>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>Email</td>
                                    <td>
                                        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>Password</td>
                                    <td>
                                        <asp:TextBox ID="tbPassword" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxChangePassword" runat="server" Text="Change password" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Role</td>
                                    <td>
                                        <asp:DropDownList ID="ddlRole" runat="server"></asp:DropDownList>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>Status</td>
                                    <td>
                                        <asp:DropDownList ID="ddlStatus" runat="server"></asp:DropDownList>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="btnUpdateUser" runat="server" OnClick="btnUpdateUser_Click" Text="Update" />
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
            <h3>Add new User</h3>
            <asp:Panel ID="PanelAddUser" CssClass="row" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>First Name</td>
                        <td>
                            <asp:TextBox ID="add_tbFirstName" runat="server"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Last Name</td>
                        <td>
                            <asp:TextBox ID="add_tbLastName" runat="server"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Email</td>
                        <td>
                            <asp:TextBox ID="add_tbEmail" runat="server"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Password</td>
                        <td>
                            <asp:TextBox ID="add_tbPassword" runat="server"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Role</td>
                        <td>
                            <asp:DropDownList ID="add_DropDownListRole" runat="server"></asp:DropDownList>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>Status</td>
                        <td>
                            <asp:DropDownList ID="add_DropDownListStatus" runat="server"></asp:DropDownList>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="ButtonAddUser" runat="server" OnClick="ButtonAddUser_Click" Text="Add" />
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
