using Dapper;
using Datos.Interfaces;
using Entidades;
using MySql.Data.MySqlClient;

namespace Datos.Repositorios
{
    public class FacturaRepositorio : IFacturaRepositorio
    {
        private string CadenaConexion;

        public FacturaRepositorio(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }
        public async Task<int> NuevaFactura(Factura factura)
        {
            int idFactura = 0;
            try
            {
                using MySqlConnection conexion =Conexion();
                await conexion.OpenAsync();
                string sql = @"INSERT INTO factura(IdentidadCliente,Fecha,CodigoUsuario,ISV,Descuento,SubTotal,Total)
                               VALUES (@IdentidadCliente,@Fecha,@CodigoUsuario,@ISV,@Descuento,@SubTotal,@Total); SELECT LAST_INSERT_ID()";
                idFactura = Convert.ToInt32(await conexion.ExecuteScalarAsync(sql, factura));
            }
            catch (Exception)
            {

               
            }
            return idFactura;
        }

       



    }
}
