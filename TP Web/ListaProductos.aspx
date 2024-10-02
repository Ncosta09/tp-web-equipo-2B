<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="ListaProductos.aspx.cs" Inherits="TP_Web.ListaProductos" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>--%>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

<div class="container-fila">

    <asp:Repeater runat="server" ID="artRepeater">
        <ItemTemplate>
            <a href="" class="col-product"> 
                <img src="<%#Eval("Imagen")%>" />
                <div class="line"></div>
                <label><%#Eval("Nombre")%></label>
                <asp:Button CssClass="btnPremio" runat="server" Text="Quiero este!" />
            </a>
        </ItemTemplate>
    </asp:Repeater>
</div>

</asp:Content>