using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticuloPorId
    {
        public Articulo listarPorId(string id)
        {
            AccesoDatos datos = new AccesoDatos();
            Articulo art = null;

            try
            {
                //Consulta a la DB ¬
                datos.setConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca AS MarId, A.IdCategoria AS CatId, A.Precio, MIN(IMG.ImagenUrl) AS ImagenUrl FROM ARTICULOS AS A INNER JOIN IMAGENES AS IMG ON IMG.IdArticulo = A.Id WHERE A.Id = @Id GROUP BY A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, A.Precio;");
                datos.setParametro("@Id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    art = new Articulo();

                    art.ID = (int)datos.Lector["Id"];
                    art.Codigo = datos.Lector["Codigo"] is DBNull ? "Sin Codigo" : (string)datos.Lector["Codigo"];
                    art.Nombre = datos.Lector["Nombre"] is DBNull ? "Sin Nombre" : (string)datos.Lector["Nombre"];
                    art.Descripcion = datos.Lector["Descripcion"] is DBNull ? "Sin Descripcion" : (string)datos.Lector["Descripcion"];
                    art.Precio = datos.Lector["Precio"] is DBNull ? 0 : (decimal)datos.Lector["Precio"];

                    // Categoría
                    art.Categoria = new Categoria();
                    art.Categoria.Id = datos.Lector["CatId"] is DBNull ? 0 : (int)datos.Lector["CatId"];
                    art.Categoria.Descripcion = art.Categoria.Id == 0 ? "Sin Categoria" : "Categoria";

                    // Marca
                    art.Marca = new Marca();
                    art.Marca.Id = datos.Lector["MarId"] is DBNull ? 0 : (int)datos.Lector["MarId"];
                    art.Marca.Descripcion = art.Marca.Id == 0 ? "Sin Marca" : "Marca";

                    // Imagen
                    art.Imagen = new Imagen();
                    art.Imagen.imgUrl = datos.Lector["ImagenUrl"] is DBNull ? "Sin Imagen" : (string)datos.Lector["ImagenUrl"];
                
                }
                
                return art;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
    }
}