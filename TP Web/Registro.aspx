<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TP_Web.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Registro
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Registro</h2>
    <div class="form-container">
        <form>
            <div class="input-group">
                <label for="documento">Documento</label>
                <input type="text" id="documento" placeholder="Documento" />
                <button type="button" class="search-btn">
                    <i class="fa fa-search"></i>
                </button>
            </div>
            
            <div class="input-group">
                <label for="nombre">Nombre</label>
                <input type="text" id="nombre" placeholder="Nombre" />
                <input type="text" id="apellido" placeholder="Apellido" />
            </div>

            <div class="input-group">
                <label for="email">Email</label>
                <input type="email" id="email" placeholder="Email" />
            </div>

            <div class="input-group">
                <label for="direccion">Dirección</label>
                <input type="text" id="direccion" placeholder="Dirección" />
            </div>

            <div class="input-group">
                <label for="ciudad">Ciudad</label>
                <input type="text" id="ciudad" placeholder="Ciudad" />
                <input type="text" id="cp" placeholder="CP" />
            </div>

            <div class="button-group">
                <button type="submit" class="btn btn-primary">Participar</button>
                <button type="button" class="btn btn-secondary">Cancelar</button>
                <button type="submit" class="btn btn-register">Regístrate y Participa</button>
            </div>
        </form>
    </div>
</asp:Content>