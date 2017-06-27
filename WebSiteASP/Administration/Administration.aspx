<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Administration.aspx.cs" Inherits="WebSiteASP.Administration.Administration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Admin Panel</title>
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
                    <li><a href="/Administration/Roles.aspx">Roles</a></li>
                    <li><a href="/Administration/Status.aspx">Status</a></li>
                </ul>
            </nav>
        </div>
        <div class="row" style="margin-top: 100px">
            <h1 style="text-align: center">Welcome to Admin panel!</h1>
        </div>
    </form>
</asp:Content>



<asp:Content ID="Content5" ContentPlaceHolderID="cphJavascript" runat="server">
</asp:Content>
