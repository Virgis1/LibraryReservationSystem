<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibraryReservationSystem._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Visos prieinamos knygos</h2>

    <asp:ListView ID="lvBooks" runat="server" OnPagePropertiesChanging="lvBooks_PagePropertiesChanging">
        <LayoutTemplate>
            <table class="datagrid-custom">
                <thead style="background-color: #004080; color: white; font-weight: bold;">
                    <tr>
                        <th>Pavadinimas</th>
                        <th>Autorius</th>
                        <th>Metai</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </tbody>
            </table>

            <asp:DataPager ID="dpBooks" runat="server" PageSize="5" PagedControlID="lvBooks" CssClass="datapager-container">
                <Fields>
                    <asp:NumericPagerField ButtonCount="5" />
                </Fields>
            </asp:DataPager>
        </LayoutTemplate>

        <ItemTemplate>
            <tr>
                <td>
                    <a href='<%# "BookDetails.aspx?id=" + Eval("Id") %>'><%# Eval("Title") %></a>
                </td>
                <td>
                    <a href='<%# "Details2.aspx?id=" + Eval("Id") %>'><%# Eval("Author") %></a>
                </td>
                <td>
                    <a href='<%# "BookDetails.aspx?id=" + Eval("Id") %>'><%# Eval("Year") %></a>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
