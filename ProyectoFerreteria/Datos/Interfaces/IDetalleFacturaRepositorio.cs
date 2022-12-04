using Entidades;

namespace Datos.Interfaces
{
    public interface IDetalleFacturaRepositorio
    {
        Task<bool> NuevoDetalle(DetalleFactura detalle);
    }
}
