using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class RegistrarCliente
    {
        // Registra un cliente nuevo
        public bool RegistrarClienteNuevo(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) " +
                                 "VALUES (@Documento, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP)";
                datos.setConsulta(consulta);

                datos.setParametro("@Documento", cliente.Documento);
                datos.setParametro("@Nombre", cliente.Nombre);
                datos.setParametro("@Apellido", cliente.Apellido);
                datos.setParametro("@Email", cliente.Email);
                datos.setParametro("@Direccion", cliente.Direccion);
                datos.setParametro("@Ciudad", cliente.Ciudad);
                datos.setParametro("@CP", cliente.CP);
                datos.ejecutarAccion();

                return true; 
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
