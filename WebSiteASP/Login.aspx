<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebSiteASP.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Architect | Login</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUserForm" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMenu" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphSiteBody" runat="server">
    <form id="userLogin" class="form-signin" runat="server">
        <h2 class="form-signin-heading">Please sign in</h2>

        <asp:Label ID="labelErrorDisplay" runat="server" Text="The email or password you entered is incorrect." ForeColor="#FF5050" Visible="False"></asp:Label>

        <label for="inputEmail" class="sr-only">Email address</label>
        <input type="text" runat="server" id="inputEmail"  name="tbEmail" class="form-control top-buffer" placeholder="Email address" autofocus />
        <div class="regexerror-parent">
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ErrorMessage="invalid email address" ControlToValidate="inputEmail" ForeColor="#FF5050" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="regexposition"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="inputEmail" ErrorMessage="email field is required" ForeColor="#FF5050" CssClass="regexposition"></asp:RequiredFieldValidator>
        </div>
        <label for="inputPassword" class="sr-only">Password</label>
        <input type="password" runat="server" id="inputPassword" name="tbPassword" class="form-control top-buffer" placeholder="Password" />
        <div class="regexerror-parent">
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPassword" runat="server" ErrorMessage="invalid password field" ForeColor="#FF5050" ValidationExpression="[\S\s]+" ControlToValidate="inputPassword" CssClass="regexposition"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPassword" runat="server" ControlToValidate="inputPassword" ErrorMessage="password field is required" ForeColor="#FF5050" CssClass="regexposition"></asp:RequiredFieldValidator>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Login" class="btn btn-lg btn-primary btn-block top-buffer" OnClick="Button1_Click"/>
    </form>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphJavascript" runat="server">
</asp:Content>
