<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibraryReservationSystem._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="section-title">Visos turimos knygos</h2>

    <div class="container">
        <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="false" CssClass="gridview-custom" AllowPaging="true" PageSize="6" OnPageIndexChanging="gvBooks_PageIndexChanging">
            <Columns>
                <asp:TemplateField >
                    <ItemTemplate>
                        <div class="book-card">
                            <img src="/Images/book.png" alt="Book Image" class="book-img" />
                            <div class="book-info">
                                <h3 class="book-title"><%# Eval("Title") %></h3>
                                <p class="book-author">Author: <%# Eval("Author") %></p>
                                <p class="book-year">Year: <%# Eval("Year") %></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>





