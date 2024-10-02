<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="ListaProductos.aspx.cs" Inherits="TP_Web.ListaProductos" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>--%>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fila">
        <asp:Repeater runat="server" ID="artRepeater">
            <ItemTemplate>
                <div class="col-product">

                    <!-- Redirigir al detalle del producto -->
                    <asp:HyperLink runat="server" NavigateUrl='<%# Eval("ID", "DetalleProducto.aspx?id={0}") %>' class="product-link">
                        <img src="<%# Eval("Imagen") %>" alt="Producto" />
                        <div class="line"></div>
                        <label><%# Eval("Nombre") %></label>
                    </asp:HyperLink>

                    <!-- Button -->
                    <asp:Button CssClass="btnPremio" runat="server" Text="Quiero este!" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>