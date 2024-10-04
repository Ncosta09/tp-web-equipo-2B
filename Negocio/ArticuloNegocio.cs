using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using System.Security.Cryptography.X509Certificates;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //Consulta a la DB ¬
                datos.setConsulta("SELECT DISTINCT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, C.Id AS CatId, C.Descripcion AS Categoria, M.Id AS MarId, M.Descripcion AS Marca, I.ImagenUrl AS Imagen FROM ARTICULOS A LEFT JOIN IMAGENES I ON I.IdArticulo = A.Id LEFT JOIN CATEGORIAS C ON C.Id = A.IdCategoria LEFT JOIN MARCAS M ON M.Id = A.IdMarca");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo art = new Articulo();

                    art.ID = (int)datos.Lector["Id"];
                    art.Codigo = datos.Lector["Codigo"] is DBNull ? "Sin Codigo" : (string)datos.Lector["Codigo"];
                    art.Nombre = datos.Lector["Nombre"] is DBNull ? "Sin Nombre" : (string)datos.Lector["Nombre"];
                    art.Descripcion = datos.Lector["Descripcion"] is DBNull ? "Sin Descripcion" : (string)datos.Lector["Descripcion"];
                    art.Precio = datos.Lector["Precio"] is DBNull ? 0000 : (decimal)datos.Lector["Precio"];
                    //Categoria
                    art.Categoria = new Categoria();
                    //art.Categoria.Id = (int)datos.Lector["CatId"];
                    art.Categoria.Id = datos.Lector["CatId"] is DBNull ? 000 : (int)datos.Lector["CatId"];
                    art.Categoria.Descripcion = datos.Lector["Categoria"] is DBNull ? "Sin Categoria" : (string)datos.Lector["Categoria"];
                    //Marca
                    art.Marca = new Marca();
                    //art.Marca.Id = (int)datos.Lector["MarId"];
                    art.Marca.Id = datos.Lector["MarId"] is DBNull ? 000 : (int)datos.Lector["MarId"];
                    art.Marca.Descripcion = datos.Lector["Marca"] is DBNull ? "Sin Marca" : (string)datos.Lector["Marca"];
                    //Imagen
                    art.Imagen = new Imagen();
                    art.Imagen.imgUrl = datos.Lector["Imagen"] is DBNull ? "Sin Imagen" : (string)datos.Lector["Imagen"];

                    lista.Add(art);
                }

                return lista;
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

        public List<Articulo> listarConSp()
        {

            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //Consulta a la DB ¬
                datos.setConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca AS MarId, A.IdCategoria AS CatId, A.Precio, MIN(IMG.ImagenUrl) AS ImagenUrl FROM ARTICULOS AS A INNER JOIN IMAGENES AS IMG ON IMG.IdArticulo = A.Id GROUP BY A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, A.Precio;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo art = new Articulo();

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

                    lista.Add(art);
                }


                return lista;
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
    

