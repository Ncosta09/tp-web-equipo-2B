using Dominio;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Negocio
{
    public class ClientePorDni
    {
        public Cliente ObtenerClientePorDocumento(string documento)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("SELECT * FROM Clientes WHERE Documento = @Documento");
                datos.setParametro("@Documento", documento);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Cliente cliente = new Cliente
                    {
                        Id = (int)datos.Lector["Id"],
                        Documento = (string)datos.Lector["Documento"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Apellido = (string)datos.Lector["Apellido"],
                        Email = (string)datos.Lector["Email"],
                        Direccion = (string)datos.Lector["Direccion"],
                        Ciudad = (string)datos.Lector["Ciudad"],
                        CP = datos.Lector["CP"].ToString() 
                    };

                    return cliente;
                }

                return null; 
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