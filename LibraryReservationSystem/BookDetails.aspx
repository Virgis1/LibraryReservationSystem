<%@ Page Title="Book Details" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="LibraryReservationSystem.BookDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Knygos informacija</h2>
    <p><strong>Pavadinimas:</strong> <asp:Label ID="lblTitle" runat="server" /></p>
    <p><strong>Autorius:</strong> <asp:Label ID="lblAuthor" runat="server" /></p>
    <p><strong>Metai:</strong> <asp:Label ID="lblYear" runat="server" /></p>
    <p><strong>Aprašymas:</strong><br /><asp:Label ID="lblDescription" runat="server" /></p>
</asp:Content>

