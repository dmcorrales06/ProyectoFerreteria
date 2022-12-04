using AplicacionWeb.Interfaces;
using Datos.Interfaces;
using Datos.Repositorios;
using Entidades;

namespace AplicacionWeb.Servicios
{
    public class FacturaServicio: IFacturaServicio
    {
        private readonly Config _configuracion;
        private IFacturaRepositorio facturaRepositorio;

        public FacturaServicio(Config config)
        {
            _configuracion = config;
            facturaRepositorio = new FacturaRepositorio(config.CadenaConexion);
        }
        public async Task<int> NuevaFactura(Factura factura)
        {
            return await facturaRepositorio.NuevaFactura(factura);
        }
    }
}
