<%@ Page Title="Author Details" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Details2.aspx.cs" Inherits="LibraryReservationSystem.Details2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="page-title">Informacija apie autorių</h2>

    <div class="book-details">
        <asp:DetailsView 
            ID="dvBook" 
            runat="server" 
            AutoGenerateRows="false" 
            DefaultMode="ReadOnly"
            CssClass="details-view" 
            OnModeChanging="dvBook_ModeChanging">
            
            <Fields>
                <asp:BoundField DataField="Author" HeaderText="Autorius" />
                <asp:BoundField DataField="Title" HeaderText="Pavadinimas" />
                <asp:BoundField DataField="Description" HeaderText="Aprašymas" />
                <asp:CheckBoxField DataField="IsInStock" HeaderText="Yra sandėlyje" />
            </Fields>
        </asp:DetailsView>

        <asp:Button ID="btnEdit" runat="server" Text="Redaguoti" OnClick="btnEdit_Click" CssClass="edit-button" />

        <br />
        <a href="Default.aspx" class="back-link">← Grįžti atgal</a>
    </div>
</asp:Content>
