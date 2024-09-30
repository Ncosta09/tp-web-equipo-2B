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
    
    }
}
