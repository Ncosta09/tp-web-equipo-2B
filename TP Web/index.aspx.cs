using System;
using System.Web.UI;
using Dominio;
using Negocio;

namespace TP_Web
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            Session["VoucherValido"] = null;
          
        }

        protected void btnVoucher_Click(object sender, ImageClickEventArgs e)
        {
            string voucherCode = tbxVoucher.Text;
            BuscarVoucher buscador = new BuscarVoucher();

            try
            {
                Voucher voucherEncontrado = buscador.encontrarVoucher(voucherCode); //BUSCO VOUCHER

                if (voucherEncontrado != null)
                {
                    if (!string.IsNullOrEmpty(voucherEncontrado.CodigoVoucher.ToString()) && voucherEncontrado.FechaCanje == DateTime.MinValue) //COMPRUEBO VOUCHER -> REDIRECCIONO
                    {
                        Session["VoucherValido"] = true;
                        ClientScript.RegisterStartupScript(this.GetType(), "confetti", "lanzarConfetti();", true);
                        string redirectScript = "setTimeout(function() { window.location.href = 'ListaProductos.aspx'; }, 1500);";
                        ClientScript.RegisterStartupScript(this.GetType(), "redirect", redirectScript, true);
                    }
                    else if (voucherEncontrado.FechaCanje != DateTime.MinValue)
                    {
                        Session["VoucherValido"] = false;
                        string alertScript = "Swal.fire({ icon: 'error', title: 'Oops...', text: 'El voucher ya fue usado!'});";
                        ClientScript.RegisterStartupScript(this.GetType(), "voucherError", alertScript, true);
                    }
                }
                else
                {
                    Session["VoucherValido"] = false;
                    string alertScript = "Swal.fire({ icon: 'error', title: 'Oops...', text: 'El voucher no existe!'});";
                    ClientScript.RegisterStartupScript(this.GetType(), "voucherError", alertScript, true);
                }

            }

            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
