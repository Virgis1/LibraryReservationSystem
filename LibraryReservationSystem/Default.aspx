<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibraryReservationSystem._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Visos prieinamos knygos</h2>

    <asp:DataGrid ID="dgBooks" runat="server" AutoGenerateColumns="false" CssClass="datagrid-custom">
        <Columns>
            <asp:TemplateColumn HeaderText="Title">
                <ItemTemplate>
                    <%# DataBinder.Eval(Container.DataItem, "Title") %>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Author">
                <ItemTemplate>
                    <%# DataBinder.Eval(Container.DataItem, "Author") %>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Year">
                <ItemTemplate>
                    <%# DataBinder.Eval(Container.DataItem, "Year") %>
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid>
</asp:Content>
