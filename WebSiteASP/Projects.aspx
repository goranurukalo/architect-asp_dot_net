<%@ Page Title="" Language="C#" MasterPageFile="~/Template.Master" AutoEventWireup="true" CodeBehind="Projects.aspx.cs" Inherits="WebSiteASP.Projects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="server">
    <title>Architect | Projects</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            float: left;
            overflow: hidden;
            position: relative;
            z-index: 1;
            margin-bottom: 20px;
            left: 0px;
            top: 0px;
        }
        .fake-h3 {
            font-size: 24px;
            font-family: "Playfair Display", serif;
            margin: 0 0 10px 0;
            color: #fff;
            font-weight: 400;
        }
        .fake-span {
            color: rgba(255, 255, 255, 0.8);
            font-family: "Playfair Display", serif;
        }
        .img-width-max {
            width: 500px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphUserForm" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMenu" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphSiteBody" runat="server">
    <div id="fh5co-portfolio">
        <form id="form1" runat="server">
            <asp:GridView ID="GridView1" PageSize="5" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="idProject" DataSourceID="SqlDataSourceProjectImage" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
           

                    <asp:TemplateField HeaderText="Projects">
                        <ItemTemplate>
                            <div class="col-md-12 animate-box top-buffer">
							    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/SingleProject.aspx?projectid="+Eval("idProject") %>' CssClass="portfolio-grid">
								    <asp:Image ID="Image2" runat="server" CssClass="img-responsive img-width-max" ImageUrl='<%#Eval("mainImageLink") %>'/>
                                    <asp:Panel ID="Panel3" runat="server" CssClass="desc">
                                        <asp:Label ID="Label3" CssClass="fake-h3" runat="server" Text='<%# Eval("title") %>'></asp:Label>
                                        <div></div>
                                        <asp:Label ID="Label2" CssClass="fake-span" runat="server" Text='<%# Eval("tag") %>'></asp:Label>
                                    </asp:Panel>
							    </asp:HyperLink>
						    </div>
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
        </form>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphJavascript" runat="server">
</asp:Content>
