using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;


namespace TP_Web
{
    public partial class ListaProductos : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulo = negocio.listarConSp();

            if (!IsPostBack)
            {
                artRepeater.DataSource = ListaArticulo;
                artRepeater.DataBind();
            }
        }

        protected void btnSeleccionarProducto_Click(object sender, EventArgs e)
        {
          
            Button btn = (Button)sender;

            // Obtengo el ID del artículo desde el CommandArgument
            int articuloId = int.Parse(btn.CommandArgument);

            // Almacenonel ID del artículo seleccionado en la sesión
            Session["ArticuloSeleccionado"] = articuloId;

        }

    }
}