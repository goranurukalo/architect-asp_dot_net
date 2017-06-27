<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="WebSiteASP.Administration.Roles" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Admin Panel | Roles</title>
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
                    <li><a href="/Administration/Polls.aspx">Polls</a></li>
                    <li  class="active"><a href="/Administration/Roles.aspx">Roles</a></li>
                    <li><a href="/Administration/Status.aspx">Status</a></li>
                </ul>
            </nav>
        </div>
        <div class="row" style="margin-top: 50px">
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:GridView ID="GridViewRoles" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="RoleName" HeaderText="Role Name" SortExpression="RoleName" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:Button Text="Edit" runat="server" ID="btnEditRole" OnClick="btnEditRole_Click" CommandName="Edit" CommandArgument='<%# Eval("IdRole")+";"+Eval("RoleName") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:Button Text="Delete" runat="server" ID="btnDeleteRole" OnClick="btnDeleteRole_Click" CommandName="Delete" CommandArgument='<%# Eval("IdRole") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            
                        </asp:GridView>
                    </td>
                    <td>
                        <asp:Panel ID="PanelShowData" Visible="false" runat="server">
                            <table style="width:100%;">
                                <tr>
                                    <td>Role Name</td>
                                    <td>
                                        <asp:TextBox ID="tbRoleName" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelRoleId" runat="server" Text="Label" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="ButtonUpdateRole" runat="server" OnClick="ButtonUpdateRole_Click" Text="Update" />
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
            <h3>Add new Role</h3>
            <asp:Panel ID="PanelAddRole" CssClass="row" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>Role Name</td>
                        <td>
                            <asp:TextBox ID="add_TextBoxRoleName" runat="server"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="ButtonAddRole" runat="server" OnClick="ButtonAddRole_Click" Text="Add" />
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
