<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="WebSiteASP.Administration.Projects" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Admin Panel | Projects</title>
    <style type="text/css">
        .auto-style1 {
            height: 36px;
        }
    </style>
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
                    <li class="active"><a href="/Administration/Projects.aspx">Projects</a></li>
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
                        <!--
                        <asp:GridView ID="GridViewProjects" runat="server" OnRowEditing="GridViewEmpty_RowEditing" OnRowDeleting="GridViewEmpty_RowDeleting" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="Title" HeaderText="Project title" SortExpression="PollQuestion" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:Button Text="Edit" runat="server" ID="btnEditProject" OnClick="btnEditProject_Click" CommandName="Edit" CommandArgument='<%# Eval("IdProject") + ";" + Eval("Title")+ ";" + Eval("Tag")+ ";" + Eval("Description")+ ";" + Eval("MainImageLink") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:Button Text="Delete" runat="server" ID="btnDeleteProject" OnClick="btnDeleteProject_Click" CommandName="Delete" CommandArgument='<%# Eval("IdProject") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            
                        </asp:GridView>

                        -->
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Title" HeaderText="Project title" SortExpression="PollQuestion" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:Button Text="Edit" runat="server" ID="btnEditStatus" OnClick="btnEditProject_Click" CommandName="Edit" CommandArgument='<%# Eval("IdProject") + ";" + Eval("Title")+ ";" + Eval("Tag")+ ";" + Eval("Description")+ ";" + Eval("MainImageLink") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:Button Text="Delete" runat="server" ID="btnDeleteStatus" OnClick="btnDeleteProject_Click" CommandName="Delete" CommandArgument='<%# Eval("IdProject") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td>
                        <asp:Panel ID="PanelShowData" Visible="false" runat="server">
                            <table style="width:100%;">
                                <tr>
                                    <td>Project Title</td>
                                    <td>
                                        <asp:TextBox ID="tbProjectTitle" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="LabelProjectId" runat="server" Text="Label" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Project Tag</td>
                                    <td>
                                        <asp:TextBox ID="tbProjectTag" runat="server"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style1">Description</td>
                                    <td class="auto-style1">
                                        <textarea id="TextAreaDescription" runat="server" cols="20" name="S1" rows="2"></textarea></td>
                                    <td class="auto-style1"></td>
                                </tr>
                                <tr>
                                    <td>Main Image</td>
                                    <td>
                                        <asp:Image ID="MainImageProject" runat="server" Width="200px" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:CheckBox ID="CheckBoxUploadNewMainImage" runat="server" Text="Upload new Main Image" />
                                        <asp:FileUpload ID="FileUploadMainImage" runat="server" />
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
                                        <asp:Button ID="btnUpdateProject" runat="server" OnClick="btnUpdateProject_Click" Text="Update" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <!--
                                        <asp:GridView ID="GridViewImages" AutoGenerateColumns="False" OnRowEditing="GridViewEmpty_RowEditing" OnRowDeleting="GridViewEmpty_RowDeleting" runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="ImageName" HeaderText="Image name" SortExpression="ImageName" />
                                                <asp:BoundField DataField="ImgAlt" HeaderText="Image alt" SortExpression="ImageAlt" />
                                                <asp:TemplateField HeaderText="Images">
                                                    <ItemTemplate>
                                                        <asp:Image ID="ProjectImages" runat="server" AlternateText='<%# Eval("ImgAlt") %>' ImageUrl='<%# Eval("SmallPictureUrl") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:Button Text="Edit" runat="server" ID="btnEditProjectImage" OnClick="btnEditProjectImage_Click" CommandName="Edit" CommandArgument='<%# Eval("IdImage") + ";" + Eval("SmallPictureUrl")+ ";" + Eval("BigPictureUrl")+ ";" + Eval("ImgAlt")+ ";" + Eval("ImageName") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:Button Text="Delete" runat="server" ID="btnDeleteProjectImage" OnClick="btnDeleteProjectImage_Click" CommandName="Delete" CommandArgument='<%# Eval("IdImage") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        -->

                                        <asp:GridView ID="GridView2" runat="server" OnRowEditing="GridViewEmpty_RowEditing" OnRowDeleting="GridViewEmpty_RowDeleting" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:BoundField DataField="ImageName" HeaderText="Image name" SortExpression="ImageName" />
                                                <asp:BoundField DataField="ImgAlt" HeaderText="Image alt" SortExpression="ImageAlt" />
                                                <asp:TemplateField HeaderText="Images">
                                                    <ItemTemplate>
                                                        <asp:Image ID="ProjectImages" runat="server" AlternateText='<%# Eval("ImgAlt") %>' ImageUrl='<%# Eval("SmallPictureUrl") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:Button Text="Edit" runat="server" ID="btnEditStatus1" OnClick="btnEditProjectImage_Click" CommandName="EEdit" CommandArgument='<%# Eval("IdImage") + ";" + Eval("SmallPictureUrl")+ ";" + Eval("BigPictureUrl")+ ";" + Eval("ImgAlt")+ ";" + Eval("ImageName") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:Button Text="Delete" runat="server" ID="btnDeleteStatus1" OnClick="btnDeleteProjectImage_Click" CommandName="DDelete" CommandArgument='<%# Eval("IdImage") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Panel ID="PanelShowEditImage" Visible="false" runat="server">
                                            <table style="width:100%;">
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>Image name</td>
                                                    <td>
                                                        <asp:TextBox ID="tbEditImageName" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LabelImageId" runat="server" Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>Image alt</td>
                                                    <td>
                                                        <asp:TextBox ID="tbEditImageAlt" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>Image</td>
                                                    <td>
                                                        <asp:CheckBox ID="CheckBoxNewImage" runat="server" Text="Upload new Image" />
                                                        <asp:FileUpload ID="FileUploadEditImage" runat="server" />
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
                                                        <asp:Button ID="UpdateImage" runat="server" OnClick="UpdateImage_Click" Text="Update" />
                                                    </td>
                                                    <td>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphJavascript" runat="server">
</asp:Content>
