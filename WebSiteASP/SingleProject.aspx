<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="SingleProject.aspx.cs" Inherits="WebSiteASP.SingleProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Architect | Single Project</title>
    <style type="text/css">
        .auto-style1 {
            width: 254px;
        }
        .auto-style2 {
            width: 50px;
        }
        .auto-style3 {
            width: 254px;
            height: 22px;
        }
        .auto-style4 {
            width: 50px;
            height: 22px;
        }
        .auto-style5 {
            height: 22px;
        }
        .img-single-small {
            width: 250px;
        }
    </style>
    <link href="/Assets/css/lightbox/lightbox.css" rel="stylesheet" />
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
					<h2 id="singleprojectTitle" runat="server">Architecture Building</h2>
				</div>
			</div>
		</div>
		<div id="fh5co-portfolio">
			
            <asp:Panel ID="PanelSingleProject" CssClass="row" runat="server">

            </asp:Panel>
            
		</div>
        <asp:Panel ID="PanelAddImage" CssClass="row top-buffer" Visible="false" runat="server">
            <h3>Add image to project</h3>
            <table style="width:100%;">
                <tr>
                    <td colspan="2">
                        <asp:Label ID="LabelMessage" runat="server" Visible="false" Text="Label"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr class="top-buffer">
                    <td class="auto-style1">Image Name</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="tbImageName" runat="server" CssClass="form-control top-buffer" Width="320px"></asp:TextBox>
                    </td>
                    <td class="td-validators">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="tbImageName" CssClass="regexposition" ErrorMessage="invalid image name field" ForeColor="#FF5050" ValidationExpression="[\w\s\,\.\!\?]{2,50}"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbImageName" CssClass="regexposition" ErrorMessage="image name is required" ForeColor="#FF5050"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Image Alt</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="tbImageAlt" runat="server" CssClass="form-control top-buffer" Width="320px"></asp:TextBox>
                    </td>
                    <td class="td-validators">
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbImageAlt" CssClass="regexposition" ErrorMessage="invalid image alt field" ForeColor="#FF5050" ValidationExpression="[\w\s\,\.\!\?]{2,50}"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbImageAlt" CssClass="regexposition" ErrorMessage="image alt is required" ForeColor="#FF5050"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Image</td>
                    <td class="auto-style2">
                        <asp:FileUpload ID="FileUploadImage" runat="server" Width="320px" CssClass="top-buffer" />
                    </td>
                    <td class="td-validators">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FileUploadImage" ErrorMessage="image is required" ForeColor="#FF5050"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style4"></td>
                    <td class="auto-style5"></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-lg btn-primary btn-block top-buffer" Text="Add image" OnClick="Button1_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:Panel>

    </form>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cphJavascript" runat="server">
    <script src="/Assets/js/lightbox/lightbox.js"></script>
    <script>
        function ajax_imgDelete(obj, imgid)
        {
            if ((/^\d+$/).test(imgid))
            {
                $.ajax({
                    url: 'AjaxImageDelete.aspx',
                    type: 'POST',
                    data: { id: imgid },
                    success: function (c) {
                        var text = "";
                        c = c.substring(0, 5);
                        if (c != "Error") {
                            text = "Deleted!";
                        }
                        else {
                            text = "Something went wrong!";
                        }
                        obj.parentElement.innerHTML = text;
                    }
                });
            }
        }
    </script>
</asp:Content>
