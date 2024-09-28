using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominios;

namespace Negocios
{
    internal class ArticuloNegocio
    {
        public List<string> listarNombres()
        {
            List<string> lista = new List<string>();
            AccessoDatos datos = new AccessoDatos();
            try
            {
                datos.setearConsulta("select Nombre from ARTICULOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    string nombre;
                    nombre = (string)datos.Lector["Nombre"];
                    lista.Add(nombre);
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
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccessoDatos datos = new AccessoDatos();

            try
            {
                datos.setearConsulta("select A.Id IdArticulo, Codigo, Nombre, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, I.ImagenUrl, A.Precio, M.Id IdMarca, C.Id IdCategoria from ARTICULOS A, IMAGENES I, MARCAS M, CATEGORIAS C WHERE A.Id = I.IdArticulo AND A.IdMarca = M.Id AND A.IdCategoria = C.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    articulo.Id = (int)datos.Lector["IdArticulo"];
                    articulo.codigo = (string)datos.Lector["Codigo"];
                    articulo.nombre = (string)datos.Lector["Nombre"];
                    articulo.descripcion = (string)datos.Lector["Descripcion"];
                    articulo.marca = new Marca();
                    articulo.marca.Id = (int)datos.Lector["IdMarca"];
                    articulo.marca.Descripcion = (string)datos.Lector["Marca"];
                    articulo.categoria = new Categoria();
                    articulo.categoria.Id = (int)datos.Lector["IdCategoria"];
                    articulo.categoria.Descripcion = (string)datos.Lector["Categoria"];
                    articulo.imagen = new Imagen();
                    articulo.imagen.Url = (string)datos.Lector["ImagenUrl"];
                    articulo.precio = (decimal)datos.Lector["Precio"];

                    lista.Add(articulo);

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
