<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TP_Web.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="product-detail">
        <div class="product-image">
            <div class="slider-container">
                <div class="slider-wrapper" id="sliderWrapper">
                    <asp:Literal ID="sliderWrapper" runat="server" />
                </div>
                <button type="button" class="slider-btn prev-btn" onclick="prevImage()">&#9664;</button>
                <button type="button" class="slider-btn next-btn" onclick="nextImage()">&#9654;</button>
            </div>
        </div>
        <div class="product-info">
            <h1 class="product-title">
                <asp:Label ID="lblNombre" runat="server"></asp:Label>
            </h1>

            <hr class="divider" />

            <div class="product-meta">
                <p class="product-category">
                    <asp:Label ID="lblCategoria" runat="server"></asp:Label>
                </p>
                <p class="product-brand">
                    <asp:Label ID="lblMarca" runat="server"></asp:Label>
                </p>
            </div>

            <hr class="divider" />

            <div class="price-container">
                <p class="product-price">
                    <asp:Label ID="lblPrecio" runat="server"></asp:Label>
                </p>
            </div>

            <hr class="divider" />

            <p class="product-description">
                <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
            </p>
            <div class="button-container">
                <asp:Button ID="btnAddToCart" runat="server" Text="Quiero este!" CssClass="add-to-cart-btn" />
            </div>
        </div>
    </div>
</asp:Content>