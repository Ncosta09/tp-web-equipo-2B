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
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    // Si es la primera carga de la página, no hacer nada
                }
            }

            // Evento que se dispara cuando el usuario ingresa el documento
            protected void btnBuscarDocumento_Click(object sender, EventArgs e)
            {
                string documento = txtDocumento.Text;

                if (!string.IsNullOrEmpty(documento))
                {
                    ClientePorDni clientePorDni = new ClientePorDni();
                    Cliente cliente = clientePorDni.ObtenerClientePorDocumento(documento);

                    if (cliente != null)
                    {
                        // Cliente existente: autocompletar campos
                        txtNombre.Text = cliente.Nombre;
                        txtApellido.Text = cliente.Apellido;
                        txtEmail.Text = cliente.Email;
                        txtDireccion.Text = cliente.Direccion.ToString();
                        txtCiudad.Text = cliente.Ciudad;
                        txtCP.Text = cliente.CP.ToString();

                        // Habilitar el botón "Participar" y deshabilitar "Registrar y Participar"
                        btnParticipar.Enabled = true;
                        btnRegistrateParticipa.Enabled = false;
                    }
                    else
                    {
                        // Cliente nuevo: habilitar todos los campos para completar
                        btnParticipar.Enabled = false;
                        btnRegistrateParticipa.Enabled = true;
                    }
                }
                else
                {
                    // Mostrar mensaje de error si el documento está vacío
                    lblMensaje.Text = "Por favor, ingrese un documento válido.";
                }
            }

            // Evento para el botón "Participar" (para clientes existentes)
            protected void btnParticipar_Click(object sender, EventArgs e)
            {
                try
                {
                    string documento = txtDocumento.Text;

                    ClientePorDni clientePorDni = new ClientePorDni();
                    Cliente cliente = clientePorDni.ObtenerClientePorDocumento(documento);

                    if (cliente != null)
                    {
                        ParticipacionCliente participacion = new ParticipacionCliente();
                        bool exito = participacion.GuardarParticipacion(cliente.Id, ObtenerArticuloId());

                        if (exito)
                        {
                            // Participación registrada correctamente
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

            // Evento para el botón "Registrate y Participa" (para nuevos clientes)
            protected void btnRegistrateParticipa_Click(object sender, EventArgs e)
            {
                if (ValidarCampos())
                {
                    try
                    {
                        // Crear nuevo cliente
                        Cliente cliente = new Cliente
                        {
                            Documento = txtDocumento.Text,
                            Nombre = txtNombre.Text,
                            Apellido = txtApellido.Text,
                            Email = txtEmail.Text,
                            Direccion = int.Parse(txtDireccion.Text),
                            Ciudad = txtCiudad.Text,
                            CP = txtCP.Text
                        };

                        RegistrarCliente clienteRegistro = new RegistrarCliente();
                        bool clienteRegistrado = clienteRegistro.RegistrarClienteNuevo(cliente);

                        if (clienteRegistrado)
                        {
                            // Guardar participación del nuevo cliente
                            ParticipacionCliente participacion = new ParticipacionCliente();
                            bool exito = participacion.GuardarParticipacion(cliente.Id, ObtenerArticuloId());

                            if (exito)
                            {
                                // Redirigir a la página de éxito
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

            // Función para validar los campos del formulario
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
                // Esta función debe retornar el Id del artículo que el cliente está seleccionando.
                // Se debe implementar la lógica correspondiente.
                return 1;
            }
        }
    }

