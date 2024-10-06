<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Web.Default" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <section class="section-voucher">
          <div class="col-lbl">
                <asp:Label CssClass="lblVoucher" ID="lblVoucher" runat="server" Text="Ingresa el código de to voucher: "></asp:Label>
          </div>
          <div class="col-voucher">
                <asp:TextBox CssClass="tbxVoucher" ID="tbxVoucher" runat="server" placeholder="XXXXXXXX"></asp:TextBox>
                <asp:ImageButton CssClass="btnVoucher" ID="btnVoucher" runat="server" ImageUrl="~/Resources/search_icon.png" OnClick="btnVoucher_Click"  />
            
          </div>
  </section>
</asp:Content>