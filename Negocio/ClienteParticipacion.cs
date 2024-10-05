using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ParticipacionCliente
    {
        public bool GuardarParticipacion(int clienteId, int articuloId, string voucherCode)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "UPDATE Vouchers SET IdCliente = @IdCliente, IdArticulo = @IdArticulo, FechaCanje = @FechaCanje WHERE CodigoVoucher = @CodigoVoucher";
                datos.setConsulta(consulta);
                datos.setParametro("@IdCliente", clienteId);
                datos.setParametro("@IdArticulo", articuloId);
                datos.setParametro("@FechaCanje", DateTime.Now); // Fecha de la participación d ahora
                datos.setParametro("@CodigoVoucher", voucherCode);  // Asignar Código del Voucher

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