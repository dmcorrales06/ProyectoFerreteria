using AplicacionWeb.Interfaces;
using Datos.Interfaces;
using Datos.Repositorios;
using Entidades;

namespace AplicacionWeb.Servicios
{
    public class DetalleFacturaServicio : IDetalleFacturaServicio
    {
        private readonly Config _configuracion;
        private IDetalleFacturaRepositorio detalleFacturaRepositorio;

        public DetalleFacturaServicio(Config config)
        {
            _configuracion = config;
            detalleFacturaRepositorio = new DetalleFacturaRepositorio(config.CadenaConexion);
        }
        public async Task<bool> NuevoDetalle(DetalleFactura detalleFactura)
        {
            return await detalleFacturaRepositorio.NuevoDetalle(detalleFactura);
        }
    }
}
