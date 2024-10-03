using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ParticipacionCliente
    {
        public bool GuardarParticipacion(int clienteId, int articuloId)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "INSERT INTO Vouchers (IdCliente, IdArticulo, FechaCanje) " +
                                  "VALUES (@IdCliente, @IdArticulo, @FechaCanje)";
                datos.setConsulta(consulta);
                datos.setParametro("@IdCliente", clienteId);
                datos.setParametro("@IdArticulo", articuloId);
                datos.setParametro("@FechaCanje", DateTime.Now); // Fecha de la participación d ahora

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