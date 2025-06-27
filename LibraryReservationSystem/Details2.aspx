<%@ Page Title="Author Details" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Details2.aspx.cs" Inherits="LibraryReservationSystem.Details2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="page-title">Informacija apie autorių</h2>

    <div class="book-details">
        
        <p><strong>Autorius:</strong> <asp:Label ID="lblAuthor" runat="server" CssClass="book-label" /></p>

        <a href="Default.aspx" class="back-link">← Grįžti atgal</a>
    </div>
</asp:Content>


