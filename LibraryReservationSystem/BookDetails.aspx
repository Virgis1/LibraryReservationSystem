<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="LibraryReservationSystem.BookDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="page-title">Knygos informacija</h2>

    <div class="book-details">
        <p><strong>Pavadinimas:</strong> <asp:Label ID="lblTitle" runat="server" CssClass="book-label" /></p>
        <p><strong>Autorius:</strong> <asp:Label ID="lblAuthor" runat="server" CssClass="book-label" /></p>
        <p><strong>Metai:</strong> <asp:Label ID="lblYear" runat="server" CssClass="book-label" /></p>
        <p><strong>Aprašymas:</strong><br />
            <asp:Label ID="lblDescription" runat="server" CssClass="book-description" />
        </p>

        <a href="Default.aspx" class="back-link">← Grįžti atgal</a>
    </div>
</asp:Content>

