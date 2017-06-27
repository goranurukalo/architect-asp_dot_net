<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebSiteASP.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Architect | Profile</title>
    <style type="text/css">
        .auto-style1 {
            width: 99px;
        }
        .auto-style2 {
            width: 220px;
        }
        .auto-style3 {
            width: 99px;
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
        }
        .auto-style5 {
            width: 282px;
        }
        .auto-style6 {
            height: 23px;
            width: 282px;
        }
        .td-validators {
            position: relative;
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
        <h3>Add new Project</h3>
        <div class="row top-buffer">
        </div>
        <table style="width: 100%;" class="top-buffer">
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style5">
            <asp:Label ID="LabelMessage" runat="server" Text="" Visible="false"></asp:Label>
                </td>
                <td class="td-validators">
                    <asp:CheckBox ID="CheckBoxEditing" runat="server" Visible="False" />
                    <asp:Label ID="LabelEditingId" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Title:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="tbTitle" runat="server" Width="320px" CssClass="form-control top-buffer"></asp:TextBox>
                </td>
                <td class="td-validators">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbTitle" CssClass="regexposition top-buffer" ErrorMessage="title field is required" ForeColor="#FF5050"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="tbTitle" CssClass="regexposition" ErrorMessage="invalid title field" ForeColor="#FF5050" ValidationExpression="[\w\s\,\.\!\?]{2,50}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Tag:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="tbTag" runat="server" Width="320px" CssClass="form-control top-buffer"></asp:TextBox>
                </td>
                <td class="td-validators">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbTag" CssClass="regexposition" ErrorMessage="tag field is required" ForeColor="#FF5050"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="tbTag" CssClass="regexposition" ErrorMessage="invalid tag field" ForeColor="#FF5050" ValidationExpression="[\w\s\,\.\!\?]{2,50}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Description:</td>
                <td class="auto-style5">
                    <textarea id="taDescription" runat="server" class="auto-style2 form-control top-buffer" name="S1" rows="2" style="width: 320px"></textarea></td>
                <td class="td-validators">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="taDescription" CssClass="regexposition" ErrorMessage="description field is required" ForeColor="#FF5050"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="taDescription" CssClass="regexposition" ErrorMessage="invalid description field" ForeColor="#FF5050" ValidationExpression="[\w\s\,\.\!\?]{2,255}"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style6">
                    <asp:CheckBox ID="CheckBoxEditImage" Visible="false" runat="server" Text="New Image" />
                </td>
                <td class="auto-style4 td-validators">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">Main image:</td>
                <td class="auto-style6">
                    <asp:FileUpload ID="FileUploadMainImage" runat="server" Width="320px" CssClass="top-buffer" />
                </td>
                <td class="auto-style4 td-validators">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4" colspan="2">
                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-lg btn-primary btn-block top-buffer" OnClick="btnSubmit_Click" Text="Submit" />
                </td>
                <td>

                </td>
            </tr>
        </table>
    </div>
    <div class="row top-buffer">
        <asp:Label ID="LabelDelete" runat="server" Text="" Visible="false"></asp:Label>
    </div>
    <div class="row top-buffer">
        <div id="fh5co-portfolio">
        
            <asp:GridView ID="GridView1" PageSize="5" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="idProject" DataSourceID="SqlDataSourceProjectImage" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
           

                    <asp:TemplateField HeaderText="Projects">
                        <ItemTemplate>
                            <div class="col-md-12 animate-box top-buffer">
							    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/SingleProject.aspx?projectid="+Eval("idProject") %>' CssClass="portfolio-grid">
								    <asp:Image ID="Image2" runat="server" CssClass="img-responsive img-width-max" Width="250" ImageUrl='<%#Eval("mainImageLink") %>'/>
                                    <asp:Panel ID="Panel3" runat="server" CssClass="desc">
                                        <asp:Label ID="Label3" CssClass="fake-h3" runat="server" Text='<%# Eval("title") %>'></asp:Label>
                                        <div></div>
                                        <asp:Label ID="Label2" CssClass="fake-span" runat="server" Text='<%# Eval("tag") %>'></asp:Label>
                                    </asp:Panel>
							    </asp:HyperLink>
						    </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                

                    <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                            <asp:Button Text="Edit" runat="server" CausesValidation="false" CssClass="btn btn-primary btn-block" CommandName="EditProject" CommandArgument='<%# Eval("idProject")+";"+ Eval("title")+";"+Eval("tag")+";"+Eval("description") %>' ID="editing" OnClick="editing_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button Text="Delete" runat="server" CausesValidation="false" CssClass="btn btn-primary btn-block" CommandName="DeleteProject" CommandArgument='<%# Eval("idProject") %>' ID="deliting" OnClick="deliting_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                

                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSourceProjectImage" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringProjectImage %>" SelectCommand="SELECT [idProject], [title], [mainImageLink], [numberOfLikes], [tag], [description] FROM [Projects]"></asp:SqlDataSource>
        
    </div>
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphJavascript" runat="server">
</asp:Content>
