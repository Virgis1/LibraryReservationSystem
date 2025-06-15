<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibraryReservationSystem._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="section-title">Visos turimos knygos</h2>

    <div class="container">
        <asp:DataGrid ID="dgBooks" runat="server" AutoGenerateColumns="false" CssClass="datagrid-custom">
            <Columns>
                <asp:TemplateColumn>
                    <ItemTemplate>
                        <div class="book-card">
                            <img src="/Images/book.png" alt="Book Image" class="book-img" />
                            <div class="book-info">
                                <h3 class="book-title"><%# DataBinder.Eval(Container.DataItem, "Title") %></h3>
                                <p class="book-author">Author: <%# DataBinder.Eval(Container.DataItem, "Author") %></p>
                                <p class="book-year">Year: <%# DataBinder.Eval(Container.DataItem, "Year") %></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:TemplateColumn>
            </Columns>
        </asp:DataGrid>
    </div>
</asp:Content>
