<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibraryReservationSystem._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Visos prieinamos knygos</h2>

    <asp:DataGrid ID="dgBooks" runat="server" AutoGenerateColumns="false" CssClass="datagrid-custom" AllowPaging="true" PageSize="3" OnPageIndexChanged="dgBooks_PageIndexChanged">
        <Columns>
            <asp:TemplateColumn HeaderText="Title">
                <HeaderStyle BackColor="#004080" ForeColor="White" Font-Bold="True" />
                <ItemTemplate>
                    <%# DataBinder.Eval(Container.DataItem, "Title") %>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Author">
                <HeaderStyle BackColor="#004080" ForeColor="White" Font-Bold="True" />
                <ItemTemplate>
                    <%# DataBinder.Eval(Container.DataItem, "Author") %>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Year">
                <HeaderStyle BackColor="#004080" ForeColor="White" Font-Bold="True" />
                <ItemTemplate>
                    <%# DataBinder.Eval(Container.DataItem, "Year") %>
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid>
</asp:Content>