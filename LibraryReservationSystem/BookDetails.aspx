<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="LibraryReservationSystem.BookDetails" %>
<%@ Register TagPrefix="uc" TagName="BookCount" Src="~/Controls/BookCount.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="page-title">Knygos informacija</h2>

    <div class="book-details">
        <p><strong>Pavadinimas:</strong> <asp:Label ID="lblTitle" runat="server" CssClass="book-label" /></p>
        <p><strong>Autorius:</strong> <asp:Label ID="lblAuthor" runat="server" CssClass="book-label" /></p>
        <p><strong>Metai:</strong> <asp:Label ID="lblYear" runat="server" CssClass="book-label" /></p>
        <p><strong>Aprašymas:</strong><br />
            <asp:Label ID="lblDescription" runat="server" CssClass="book-description" />
        </p>
        <p><strong>Yra sandėlyje:</strong> <asp:Label ID="lblIsInStock" runat="server" CssClass="book-label" /></p>

        <a href="Default.aspx" class="back-link">← Grįžti atgal</a>
    </div>

    <div class="book-count">
        <uc:BookCount ID="BookCount1" runat="server" />
    </div>


</asp:Content>

