using Dominio;
using System;

namespace Negocio
{
    public class BuscarVoucher
    {
        public Voucher encontrarVoucher(string codigoVoucher)
        {
            AccesoDatos datos = new AccesoDatos();
            Voucher voucher = null;

            try
            {
                // Consulta a la DB
                datos.setConsulta("SELECT v.CodigoVoucher, v.FechaCanje, v.IdArticulo, v.IdCliente FROM Vouchers AS v WHERE v.CodigoVoucher = @CodigoVoucher;");
                datos.setParametro("@CodigoVoucher", codigoVoucher);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    voucher = new Voucher();
                    {

                        voucher.CodigoVoucher = datos.Lector["CodigoVoucher"] is DBNull ? string.Empty : (string)datos.Lector["CodigoVoucher"];
                        voucher.FechaCanje = datos.Lector["FechaCanje"] is DBNull ? DateTime.MinValue : (DateTime)datos.Lector["FechaCanje"];
                        voucher.IdArticulo = datos.Lector["IdArticulo"] is DBNull ? 0 : (int)datos.Lector["IdArticulo"];
                        voucher.IdCliente = datos.Lector["IdCliente"] is DBNull ? 0 : (int)datos.Lector["IdCliente"];
                    };
                }

                return voucher;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al encontrar el voucher: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
