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
                datos.setConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.Precio, IMG.ImagenUrl AS ImagenUrl FROM ARTICULOS AS A INNER JOIN IMAGENES AS IMG ON IMG.IdArticulo = A.Id INNER JOIN MARCAS AS M ON M.Id = A.IdMarca INNER JOIN CATEGORIAS AS C ON C.Id = A.IdCategoria WHERE A.Id = @Id GROUP BY A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion, C.Descripcion, A.Precio, IMG.ImagenUrl");
                datos.setParametro("@Id", id);
                datos.ejecutarLectura();

                art = new Articulo();
                art.Imagenes = new List<Imagen>();


                while (datos.Lector.Read())
                {
                    if (art.ID == 0)
                    {
                        art.ID = (int)datos.Lector["Id"];
                        art.Codigo = datos.Lector["Codigo"] is DBNull ? "Sin Codigo" : (string)datos.Lector["Codigo"];
                        art.Nombre = datos.Lector["Nombre"] is DBNull ? "Sin Nombre" : (string)datos.Lector["Nombre"];
                        art.Descripcion = datos.Lector["Descripcion"] is DBNull ? "Sin Descripcion" : (string)datos.Lector["Descripcion"];
                        art.Precio = datos.Lector["Precio"] is DBNull ? 0 : (decimal)datos.Lector["Precio"];

                        // Categoría
                        art.Categoria = new Categoria();
                        art.Categoria.Descripcion = datos.Lector["Categoria"] is DBNull ? "Sin Categoria" : (string)datos.Lector["Categoria"];

                        // Marca
                        art.Marca = new Marca();
                        art.Marca.Descripcion = datos.Lector["Marca"] is DBNull ? "Sin Marca" : (string)datos.Lector["Marca"];
                    }

                    // Imagen
                    Imagen img = new Imagen();
                    img.imgUrl = datos.Lector["ImagenUrl"] is DBNull ? "Sin Imagen" : (string)datos.Lector["ImagenUrl"];
                    art.Imagenes.Add(img);

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