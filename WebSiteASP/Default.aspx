<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebSiteASP.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Architect | Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUserForm" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMenu" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphSiteBody" runat="server">
    <form id="form1" runat="server">
        <div id="fh5co-intro">
			<div class="row animate-box">
				<div class="col-md-8 col-md-offset-2 col-md-pull-2">
					<h2>Best showcase for architecture &amp; interior.</h2>
				</div>
			</div>
		</div>

		<aside id="fh5co-hero">
			<div class="flexslider">
                <asp:Panel ID="PanelSlider" runat="server">

                </asp:Panel>
            </div>
		</aside>

        <div id="fh5co-portfolio">
			<div class="row nopadding">
                <asp:Panel ID="showcase" CssClass="row" runat="server">

                </asp:Panel>
			</div>
		</div>

    </form>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphJavascript" runat="server">
</asp:Content>
