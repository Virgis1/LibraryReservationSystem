<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" 
    Inherits="LibraryReservationSystem._Default"
    UICulture="auto" Culture="auto" %>

<%@ Register TagPrefix="uc" TagName="BookCount" Src="~/Controls/BookCount.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        <asp:Literal ID="litPageHeader" runat="server" 
             Text="<%$ Resources: PageHeader %>"></asp:Literal>
    </h2>
    <p>Pakeisti kalbą:</p>
    <p>
        <a href="?lang=lt-LT">Lietuvių</a> | <a href="?lang=en-US">English</a> | <a href="?lang=fr-FR">France</a>
    </p>

    <div class="book-count">
        <uc:BookCount ID="BookCount1" runat="server" />
    </div>

    <asp:Button ID="btnShowAddForm" runat="server" Text="<%$ Resources:AddBook %>"
        CssClass="btn btn-primary" OnClick="btnShowAddForm_Click" /> 

    <br /><br />

    <%--<asp:Panel ID="pnlSearch" runat="server" DefaultButton="btnSearch">
    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" 
        Placeholder="Įveskite žodį"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-info"
        OnClick="btnSearch_Click" />
    <asp:Button ID="btnClearSearch" runat="server" Text="Clear" CssClass="btn btn-secondary"
        OnClick="btnClearSearch_Click" />
</asp:Panel>--%>

    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" 
    Placeholder="Įveskite paieškos žodį" 
    AutoPostBack="true" 
    OnTextChanged="txtSearch_TextChanged">
</asp:TextBox>

    <asp:Panel ID="pnlAddBookForm" runat="server" Visible="false">
        <asp:TextBox ID="txtTitle" runat="server" Placeholder="<%$ Resources:Title %>" CssClass="form-control"></asp:TextBox>
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
                        <th>
                            <asp:LinkButton ID="lnkSortTitle" runat="server" CommandName="Sort" CommandArgument="Title" meta:resourcekey="Title" />
                        </th>
                        <th><asp:LinkButton ID="LinkSortAuthor" runat="server" CommandName="Sort" CommandArgument="Author" meta:resourcekey="Author" /></th>
                        <th><asp:LinkButton ID="LinkSortYear" runat="server" CommandName="Sort" CommandArgument="Year" meta:resourcekey="Year" /></th>
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
        <EmptyDataTemplate>
        <div style="padding: 10px; font-weight: bold; color: red;">
            Knygų šiuo metu nėra
        </div>
    </EmptyDataTemplate>
    </asp:ListView>
</asp:Content>
