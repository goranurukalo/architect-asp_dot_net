<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebSiteASP.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Architect | Registration</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUserForm" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMenu" runat="server">
</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="cphSiteBody" runat="server">
    <form id="userRegister" class="form-signin" runat="server">
        <h2 class="form-signin-heading">Please sign up</h2>

        <asp:Label ID="labelError" runat="server" Text="we are sorry but something went wrong" ForeColor="#FF5050" Visible="False"></asp:Label>
        <label for="firstName" class="sr-only">First Name</label>
        <input type="text" runat="server" id="firstName"  name="tbFirstName" class="form-control top-buffer" placeholder="First Name" autofocus>
        <div class="regexerror-parent">
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorFirstName" runat="server" ErrorMessage="invalid first name field" ControlToValidate="firstName" ForeColor="#FF5050" CssClass="regexposition" ValidationExpression="[\w\s]{2,40}"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="firstName" CssClass="regexposition" ErrorMessage="first name is required" ForeColor="#FF5050"></asp:RequiredFieldValidator>
        </div>

        <label for="lastName" class="sr-only">Last Name</label>
        <input type="text" runat="server" id="lastName"  name="tbLastName" class="form-control top-buffer" placeholder="Last Name"  >
        <div class="regexerror-parent">
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorLastName" runat="server" ErrorMessage="invalid last name field" ControlToValidate="lastName" ForeColor="#FF5050" CssClass="regexposition" ValidationExpression="[\w\s]{2,50}"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="lastName" CssClass="regexposition" ErrorMessage="last name is requierd" ForeColor="#FF5050"></asp:RequiredFieldValidator>
        </div>

        <label for="inputEmail" class="sr-only">Email address</label>
        <input type="text" runat="server" id="inputEmail"  name="tbEmail" class="form-control top-buffer" placeholder="Email address" >
        <div class="regexerror-parent">
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ErrorMessage="invalid email address" ControlToValidate="inputEmail" ForeColor="#FF5050" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="regexposition"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="inputEmail" CssClass="regexposition" ErrorMessage="email is required" ForeColor="#FF5050"></asp:RequiredFieldValidator>
        </div>

        <label for="inputPassword" class="sr-only">Enter Password</label>
        <input type="password" runat="server" id="inputPassword" name="tbPassword" class="form-control top-buffer" placeholder="Enter Password">
        <div class="regexerror-parent">
            <asp:CompareValidator ID="CompareValidatorPasswords" runat="server" ErrorMessage="password and confirm password doesn't match" ControlToCompare="rePassword" ControlToValidate="inputPassword" ForeColor="#FF5050" CssClass="regexposition"></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="inputPassword" CssClass="regexposition" ErrorMessage="password is required" ForeColor="#FF5050"></asp:RequiredFieldValidator>
        </div>

        <label for="rePassword" class="sr-only">Enter Password Again</label>
        <input type="password" runat="server" id="rePassword" name="tbRePassword" class="form-control top-buffer" placeholder="Enter Password Again">
        <div class="regexerror-parent">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="rePassword" CssClass="regexposition" ErrorMessage="confirm password is required" ForeColor="#FF5050"></asp:RequiredFieldValidator>
        </div>

        <asp:Button ID="btnRegister" runat="server" Text="Register" class="btn btn-lg btn-primary btn-block top-buffer" OnClick="btnRegister_Click" />
    </form>
</asp:Content>


<asp:Content ID="Content5" ContentPlaceHolderID="cphJavascript" runat="server">
</asp:Content>
