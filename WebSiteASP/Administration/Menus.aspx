<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Menus.aspx.cs" Inherits="WebSiteASP.Administration.Menus" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Admin Panel | Menus</title>
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
                    <li class="active"><a href="/Administration/Menus.aspx">Menus</a></li>
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
                        <asp:GridView ID="GridViewMenus" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="Title" HeaderText="Menu Title" SortExpression="Title" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:Button Text="Edit" runat="server" ID="btnEditMenu" OnClick="btnEditMenu_Click" CommandName="Edit" CommandArgument='<%# Eval("IdMenu")+";"+Eval("Title")+";"+Eval("Link")+";"+Eval("IdRole") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:Button Text="Delete" runat="server" ID="btnDeleteMenu" OnClick="btnDeleteMenu_Click" CommandName="Delete" CommandArgument='<%# Eval("IdMenu") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            
                        </asp:GridView>
                    </td>
                    <td>
                        <asp:Panel ID="PanelShowData" Visible="false" runat="server">
                            <table style="width:100%;">
                                <tr>
                                    <td>Menu Title</td>
                                    <td>
                                        <asp:TextBox ID="tbMenuTitle" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelMenuId" runat="server" Text="Label" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Menu Link</td>
                                    <td>
                                        <asp:TextBox ID="tbMenuLink" runat="server"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>Role</td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListRole" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Button ID="ButtonUpdateMenu" runat="server" OnClick="ButtonUpdateMenu_Click" Text="Update" />
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
            <h3>Add new Menu</h3>
            <asp:Panel ID="PanelAddRole" CssClass="row" runat="server">
                <table style="width: 100%;">
                    <tr>
                        <td>Menu Title</td>
                        <td>
                            <asp:TextBox ID="add_tbMenuTitle" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>Menu Link</td>
                        <td>
                            <asp:TextBox ID="add_tbMenuLink" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>Role</td>
                        <td>
                            <asp:DropDownList ID="add_DropDownListMenuRole" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="btnAddMenu" runat="server" OnClick="btnAddMenu_Click" Text="Add" />
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
