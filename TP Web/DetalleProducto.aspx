<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TP_Web.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div class="imagen">
            <asp:Label ID="lblNombre" runat="server"></asp:Label>
            <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
            <asp:Label ID="lblPrecio" runat="server"></asp:Label>
            <asp:Label ID="lblMarca" runat="server"></asp:Label>
            <asp:Label ID="lblCategoria" runat="server"></asp:Label>
            <%--<asp:Image ID="image" runat="server" />--%>

            <div class="slider-container">
                <div class="slider-wrapper" id="sliderWrapper">
                    <asp:Literal ID="sliderWrapper" runat="server" />
                </div>
                <button type="button" class="slider-btn prev-btn" onclick="prevImage()">&#9664;</button>
                <button type="button" class="slider-btn next-btn" onclick="nextImage()">&#9654;</button>
            </div>


        </div>
    </div>
</asp:Content>
