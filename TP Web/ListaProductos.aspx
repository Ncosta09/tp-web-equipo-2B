<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="ListaProductos.aspx.cs" Inherits="TP_Web.ListaProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

<div class="container-fila">
    <%
        foreach (Dominio.Articulo art in ListaArticulo)
        {
            %>
            <div class="col-product">
                <img src="<%= art.Imagen.imgUrl %>" />
                <div class="line"></div>
                <label><%= art.Nombre %></label>
                <asp:Button CssClass="btnPremio" runat="server" Text="Quiero este!" />
            </div>
            <%
        }
    %>
</div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="FooterContent" runat="server">
</asp:Content>
