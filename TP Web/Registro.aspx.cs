using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Configuration;

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

            if (ValidarCampos())
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

                           
                            EnviarCorreo(cliente.Email);

                            
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
            else
            {
                string alertScript = "Swal.fire({ icon: 'error', title: 'Oops...', text: 'Por favor, complete todos los campos correctamente.'});";
                ClientScript.RegisterStartupScript(this.GetType(), "voucherError", alertScript, true);
            }
        }

        // Clientes nuevos
        protected void btnRegistrateParticipa_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    string voucherCode = Session["VoucherCode"] as string;

                    // Verificar si el cliente ya existe usando ClientePorDni
                    RegistrarCliente clienteRegistro = new RegistrarCliente();
                    ClientePorDni clientePorDni = new ClientePorDni();
                    Cliente clienteExistente = clientePorDni.ObtenerClientePorDocumento(txtDocumento.Text);

                    if (clienteExistente != null) // Verifica si el cliente ya existe
                    {
                        string alertScript = "Swal.fire({ icon: 'error', title: 'Usuario existente', text: 'El usuario ya está registrado.' });";
                        ClientScript.RegisterStartupScript(this.GetType(), "usuarioExistente", alertScript, true);
                        return; // Salir del método para evitar registrar de nuevo
                    }

                    // Si el cliente no existe, procede a registrarlo
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

                    int clienteId = clienteRegistro.RegistrarClienteNuevo(cliente); // Obtiene el Id del cliente recién registrado

                    if (clienteId > 0)
                    {
                        ParticipacionCliente participacion = new ParticipacionCliente();
                        bool exito = participacion.GuardarParticipacion(clienteId, ObtenerArticuloId(), voucherCode);

                        if (exito)
                        {
                            // Llamar al método para enviar el correo
                            EnviarCorreo(cliente.Email);

                            // Redirigir a la página de éxito
                            Response.Redirect("Exito.aspx");
                        }
                        else
                        {
                            string alertScript = "Swal.fire({ icon: 'error', title: 'Oops...', text: 'Ocurrió un error al registrar su participación.' });";
                            ClientScript.RegisterStartupScript(this.GetType(), "voucherError", alertScript, true);
                            
                        }
                    }
                    else
                    {
                        string alertScript = "Swal.fire({ icon: 'error', title: 'Oops...', text: 'Error al registrar el cliente.' });";
                        ClientScript.RegisterStartupScript(this.GetType(), "voucherError", alertScript, true);
                        
                    }
                }
                catch (Exception ex)
                {
                    string alertScript = "Swal.fire({ icon: 'error', title: 'Oops...', text: 'Error + ex.Message' });";
                    ClientScript.RegisterStartupScript(this.GetType(), "voucherError", alertScript, true);
                    lblMensaje.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                string alertScript = "Swal.fire({ icon: 'error', title: 'Oops...', text: 'Por favor, complete todos los campos correctamente.' });";
                ClientScript.RegisterStartupScript(this.GetType(), "voucherError", alertScript, true);
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
        // Método para enviar el correo
        private void EnviarCorreo(string destinatario)
        {
            string emailRemitente = "sorteosutnfrgp@gmail.com";
            string passwordRemitente = "vndz ynfs siso lsrq";

            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(emailRemitente);
                correo.To.Add(destinatario);  // Correo del destinatario
                correo.Subject = "Registro Exitoso";
                correo.Body = "Gracias por registrarte en nuestro sorteo. Tu participación ha sido exitosa.";
                correo.IsBodyHtml = false;  // Cambia a true si deseas enviar HTML

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(emailRemitente, passwordRemitente);
                smtp.EnableSsl = true;

                smtp.Send(correo);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al enviar correo: " + ex.Message;
            }
        }
    }
}

