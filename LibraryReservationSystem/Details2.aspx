<%@ Page Title="Author Details" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="Details2.aspx.cs" Inherits="LibraryReservationSystem.Details2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="page-title">Informacija apie autorių</h2>

    <asp:DetailsView 
    ID="dvBook" 
    runat="server" 
    AutoGenerateRows="false" 
    DefaultMode="ReadOnly"
    CssClass="details-view" 
    OnModeChanging="dvBook_ModeChanging">

    <Fields>
        <asp:TemplateField HeaderText="Autorius">
            <ItemTemplate>
                <%# Eval("Author") %>
            </ItemTemplate>
            <EditItemTemplate>
                <%# Eval("Author") %>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Pavadinimas">
            <ItemTemplate>
                <%# Eval("Title") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtTitle" runat="server" Text='<%# Bind("Title") %>' />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Aprašymas">
            <ItemTemplate>
                <%# Eval("Description") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtDescription" runat="server" Text='<%# Bind("Description") %>' TextMode="MultiLine" Rows="3" />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Yra sandėlyje">
            <ItemTemplate>
                <%# (bool)Eval("IsInStock") ? "Taip" : "Ne" %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:CheckBox ID="chkIsInStock" runat="server" Checked='<%# Bind("IsInStock") %>' />
            </EditItemTemplate>
        </asp:TemplateField>
    </Fields>
</asp:DetailsView>


        <asp:Button ID="btnEdit" runat="server" Text="Redaguoti" OnClick="btnEdit_Click" CssClass="edit-button" />
        <asp:Button ID="btnSave" runat="server" Text="Išsaugoti" OnClick="btnSave_Click" CssClass="save-button" Visible="false" />



        <br />
        <a href="Default.aspx" class="back-link">← Grįžti atgal</a>
    </div>
</asp:Content>
