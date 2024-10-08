﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                lblNombre.Text = articulo.Nombre;
                lblDescripcion.Text = articulo.Descripcion;
                lblPrecio.Text = articulo.Precio.ToString("C");
                lblMarca.Text = articulo.Marca.Descripcion;
                lblCategoria.Text = articulo.Categoria.Descripcion;

                // Generar el HTML dinámico para las imágenes del slider
                StringBuilder sb = new StringBuilder();
                foreach (var img in articulo.Imagenes)
                {
                    sb.AppendLine($"<img src='{img.imgUrl}' alt='Imagen del artículo' class='slider-image' />");
                }

                sliderWrapper.Text = sb.ToString();
            }
        }

        protected void btnBtnAddToCart_Click(object sender, EventArgs e)
        {
            // Verifica si esta el ID en la URL
            if (Request.QueryString["Id"] != null)
            {
                // Me llevo el ID de la URL en SESSION
                int articuloID = int.Parse(Request.QueryString["Id"].ToString());
                Session["ArticuloSeleccionado"] = articuloID;

                // Redirigo 
                Response.Redirect("Registro.aspx");
            }
            else
            {
                // Se podria agregar un lbl para manejo de errores
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaProductos.aspx");
        }

    }
}