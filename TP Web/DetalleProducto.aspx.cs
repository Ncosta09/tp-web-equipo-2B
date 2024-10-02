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
    public partial class DetalleProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                string id = Request.QueryString["Id"].ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    mostrarDetalle(id);
                }
            }
        }

        private void mostrarDetalle(string id)
        {
            ArticuloPorId articuloId = new ArticuloPorId();
            Articulo articulo = articuloId.listarPorId(id);

            if (articulo != null)
            {
                image.ImageUrl = articulo.Imagen.imgUrl;
                lblNombre1.Text = articulo.Nombre;
            }

        }
    }
}