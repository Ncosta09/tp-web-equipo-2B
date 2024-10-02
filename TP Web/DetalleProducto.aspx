<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TP_Web.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="imagen">
            <asp:Label ID="lblNombre1" runat="server"></asp:Label>
            <asp:Image ID="image" runat="server" />
        </div>
    </div>
</asp:Content>
