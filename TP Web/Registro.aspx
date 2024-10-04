<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TP_Web.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Registro
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-container">
        <div class="input-group">
            <label for="txtDocumento">Documento</label>
            <asp:TextBox ID="txtDocumento" runat="server" placeholder="Documento" CssClass="form-control" />
            <asp:Button ID="btnBuscarDocumento" runat="server" CssClass="search-btn" Text="Buscar" OnClick="btnBuscarDocumento_Click" />
        </div>

        <div class="input-group">
            <label for="txtNombre">Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre" CssClass="form-control" />
            <asp:TextBox ID="txtApellido" runat="server" placeholder="Apellido" CssClass="form-control" />
        </div>

        <div class="input-group">
            <label for="txtEmail">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" placeholder="Email" CssClass="form-control" />
        </div>

        <div class="input-group">
            <label for="txtDireccion">Dirección</label>
            <asp:TextBox ID="txtDireccion" runat="server" placeholder="Dirección" CssClass="form-control" />
        </div>

        <div class="input-group">
            <label for="txtCiudad">Ciudad</label>
            <asp:TextBox ID="txtCiudad" runat="server" placeholder="Ciudad" CssClass="form-control" />
            <asp:TextBox ID="txtCP" runat="server" placeholder="CP" CssClass="form-control" />
        </div>

        <div class="button-group">
            <asp:Button ID="btnParticipar" runat="server" Text="Participar" CssClass="btn btn-primary" OnClick="btnParticipar_Click" Enabled="false" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" />
            <asp:Button ID="btnRegistrateParticipa" runat="server" Text="Regístrate y Participa" CssClass="btn btn-register" OnClick="btnRegistrateParticipa_Click" />
        </div>

        <!-- Label para mostrar mensajes de error o éxito -->
        <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-info" Visible="false" />
    </div>
</asp:Content>