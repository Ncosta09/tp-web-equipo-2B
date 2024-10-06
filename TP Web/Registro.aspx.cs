using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Web
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // agora sem, deshabilito los btnes para mas aestethic?
                // Deshabilitar los botones al cargar la página
                btnParticipar.Enabled = false;
                btnRegistrateParticipa.Enabled = false;
            }
        }
        protected void btnBuscarDocumento_Click(object sender, EventArgs e)
        {
            string documento = txtDocumento.Text;

            if (!string.IsNullOrEmpty(documento))
            {
                ClientePorDni clientePorDni = new ClientePorDni();
                Cliente cliente = clientePorDni.ObtenerClientePorDocumento(documento);

                if (cliente != null)
                {
                    // autocompleta campos si ya existe
                    txtNombre.Text = cliente.Nombre;
                    txtApellido.Text = cliente.Apellido;
                    txtEmail.Text = cliente.Email;
                    txtDireccion.Text = cliente.Direccion.ToString();
                    txtCiudad.Text = cliente.Ciudad;
                    txtCP.Text = cliente.CP.ToString();
                    btnParticipar.Enabled = true;
                    btnRegistrateParticipa.Enabled = false;
                }
                else
                {
                    btnParticipar.Enabled = false;
                    btnRegistrateParticipa.Enabled = true;
                }
            }
            else
            {
                lblMensaje.Text = "Por favor, ingrese un documento válido.";
            }
        }

        // clientes existentes
        protected void btnParticipar_Click(object sender, EventArgs e)
        {
            try
            {
                string documento = txtDocumento.Text;
                string voucherCode = Session["VoucherCode"].ToString();
                ClientePorDni clientePorDni = new ClientePorDni();
                Cliente cliente = clientePorDni.ObtenerClientePorDocumento(documento);

                if (cliente != null)
                {
                    ParticipacionCliente participacion = new ParticipacionCliente();
                    bool exito = participacion.GuardarParticipacion(cliente.Id, ObtenerArticuloId(), voucherCode);

                    if (exito)
                    {

                        Response.Redirect("Exito.aspx");
                    }
                    else
                    {
                        lblMensaje.Text = "Ocurrió un error al registrar su participación.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
            }
        }

        //  clientes nuevos
        protected void btnRegistrateParticipa_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    string voucherCode = Session["VoucherCode"] as string;
                    Cliente cliente = new Cliente
                    {
                        Documento = txtDocumento.Text,
                        Nombre = txtNombre.Text,
                        Apellido = txtApellido.Text,
                        Email = txtEmail.Text,
                        Direccion = txtDireccion.Text,
                        Ciudad = txtCiudad.Text,
                        CP = txtCP.Text
                    };

                    RegistrarCliente clienteRegistro = new RegistrarCliente();
                    bool clienteRegistrado = clienteRegistro.RegistrarClienteNuevo(cliente);

                    if (clienteRegistrado)
                    {

                        ParticipacionCliente participacion = new ParticipacionCliente();
                        bool exito = participacion.GuardarParticipacion(cliente.Id, ObtenerArticuloId(), voucherCode);

                        if (exito)
                        {
                            Response.Redirect("Exito.aspx");
                        }
                        else
                        {
                            lblMensaje.Text = "Ocurrió un error al registrar su participación.";
                        }
                    }
                    else
                    {
                        lblMensaje.Text = "Error al registrar el cliente.";
                    }
                }
                catch (Exception ex)
                {
                    lblMensaje.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                lblMensaje.Text = "Por favor, complete todos los campos correctamente.";
            }
        }

        // validar los campos 
        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtDocumento.Text) ||
                string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtApellido.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtDireccion.Text) ||
                string.IsNullOrEmpty(txtCiudad.Text) ||
                string.IsNullOrEmpty(txtCP.Text))
            {
                return false;
            }

            // Validar formato de email
            try
            {
                var email = new System.Net.Mail.MailAddress(txtEmail.Text);
                return email.Address == txtEmail.Text;
            }
            catch
            {
                return false;
            }
        }


        private int ObtenerArticuloId()
        {

            if (Session["ArticuloSeleccionado"] != null)
            {

                return (int)Session["ArticuloSeleccionado"];
            }
            else
            {

                lblMensaje.Text = "No se ha seleccionado un artículo.";
                return 0;
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            // Redirige a la página ListaProductos.aspx
            Response.Redirect("ListaProductos.aspx");
        }
    }
}

