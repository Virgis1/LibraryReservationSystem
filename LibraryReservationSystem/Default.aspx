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
                   <a href='<%# "BookDetails.aspx?id=" + Eval("Id") %>'>
                        <%# Eval("Title") %>
                    </a>
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Autorius">
                <ItemTemplate>
                    <a href='<%# "Details2.aspx?id=" + Eval("Id") %>'>
                        <%# Eval("Author") %>
                    </a>                 
                </ItemTemplate>
            </asp:TemplateColumn>
            <asp:TemplateColumn HeaderText="Metai">
                <ItemTemplate>
                    <a href='<%# "BookDetails.aspx?id=" + Eval("Id") %>'>
                        <%# Eval("Year") %>
                    </a>                 
                </ItemTemplate>
            </asp:TemplateColumn>
        </Columns>
    </asp:DataGrid>
</asp:Content>
