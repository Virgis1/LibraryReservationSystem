<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibraryReservationSystem._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Visos prieinamos knygos</h2>

    <asp:DataGrid 
        ID="dgBooks" 
        runat="server" 
        AutoGenerateColumns="false" 
        CssClass="datagrid-custom" 
        AllowPaging="true" 
        PageSize="5" 
        OnPageIndexChanged="dgBooks_PageIndexChanged">
        
        <HeaderStyle BackColor="#004080" ForeColor="White" Font-Bold="True" />

        <Columns>
            <asp:TemplateColumn HeaderText="Pavadinimas">
                <ItemTemplate>
                    <%# Eval("Title") %>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Autorius">
                <ItemTemplate>
                    <%# Eval("Author") %>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Metai">
                <ItemTemplate>
                    <%# Eval("Year") %>
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid>
</asp:Content>
