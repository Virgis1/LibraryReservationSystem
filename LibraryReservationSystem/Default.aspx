<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibraryReservationSystem._Default" %>

<%@ Register TagPrefix="uc" TagName="BookCount" Src="~/Controls/BookCount.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Visos prieinamos knygos</h2>

    <div class="book-count">
        <uc:BookCount ID="BookCount1" runat="server" />
    </div>

    <asp:Button ID="btnShowAddForm" runat="server" Text="Pridėti naują knygą"
        CssClass="btn btn-primary" OnClick="btnShowAddForm_Click" />

    <br /><br />

    <asp:Panel ID="pnlAddBookForm" runat="server" Visible="false">
        <asp:TextBox ID="txtTitle" runat="server" Placeholder="Pavadinimas" CssClass="form-control"></asp:TextBox>
        <asp:RequiredFieldValidator 
        ID="rfvTitle" 
        runat="server" 
        ControlToValidate="txtTitle" 
        ErrorMessage="Pavadinimas yra privalomas!" 
        CssClass="text-danger"
        CausesValidation="true"
        ValidationGroup="AddBookGroup" />
        <br />
        <asp:TextBox ID="txtAuthor" runat="server" Placeholder="Autorius" CssClass="form-control"></asp:TextBox><br />
        <asp:TextBox ID="txtYear" runat="server" Placeholder="Metai" CssClass="form-control"></asp:TextBox><br />
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="3" Placeholder="Aprašymas" CssClass="form-control"></asp:TextBox><br />
        <asp:CheckBox ID="chkIsInStock" runat="server" Text="Yra sandėlyje" /><br /><br />
        <asp:Button 
            ID="btnAddBook" 
            runat="server" 
            Text="Išsaugoti" 
            CssClass="btn btn-success" 
            OnClick="btnAddBook_Click"
            CausesValidation="true"
            ValidationGroup="AddBookGroup" 
         />
        <asp:Button ID="btnCancelAdd" runat="server" Text="Atšaukti" CssClass="btn btn-secondary" OnClick="btnCancelAdd_Click" />
    </asp:Panel>

    <hr />

    <asp:ListView ID="lvBooks" runat="server"
        OnPagePropertiesChanging="lvBooks_PagePropertiesChanging"
        OnSorting="lvBooks_Sorting"
        AllowSorting="true">
        <LayoutTemplate>
            <table class="datagrid-custom">
                <thead style="background-color: #004080; color: white; font-weight: bold;">
                    <tr>
                        <th><asp:LinkButton ID="lnkSortTitle" runat="server" CommandName="Sort" CommandArgument="Title">Pavadinimas</asp:LinkButton></th>
                        <th><asp:LinkButton ID="lnkSortAuthor" runat="server" CommandName="Sort" CommandArgument="Author">Autorius</asp:LinkButton></th>
                        <th><asp:LinkButton ID="lnkSortYear" runat="server" CommandName="Sort" CommandArgument="Year">Metai</asp:LinkButton></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </tbody>
            </table>
            <asp:DataPager ID="dpBooks" runat="server" PagedControlID="lvBooks" CssClass="datapager-container">
                <Fields>
                    <asp:NumericPagerField ButtonCount="5" />
                </Fields>
            </asp:DataPager>
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td><a href='<%# "BookDetails.aspx?id=" + Eval("Id") %>'><%# Eval("Title") %></a></td>
                <td><a href='<%# "Details2.aspx?id=" + Eval("Id") %>'><%# Eval("Author") %></a></td>
                <td><%# Eval("Year") %></td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
