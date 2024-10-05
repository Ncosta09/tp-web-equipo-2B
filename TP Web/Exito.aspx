<%@ Page Title="Registro Exitoso" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Exito.aspx.cs" Inherits="TP_Web.Exito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Registro Exitoso
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="exito-container">
        <div class="exito-content">
            <h1>¡Registro Exitoso!</h1>
            <p>Gracias por registrarte y participar en nuestra promoción.</p>
            <p>Recibirás un correo con la confirmación de tu participación.</p>

            <div class="button-group">
                <asp:Button ID="btnVolverInicio" runat="server" Text="Volver al Inicio" CssClass="btn btn-primary" PostBackUrl="~/Index.aspx" />
            </div>
        </div>
    </div>
</asp:Content>
