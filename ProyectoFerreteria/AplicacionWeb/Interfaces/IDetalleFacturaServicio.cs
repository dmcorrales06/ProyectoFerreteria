using Entidades;

namespace AplicacionWeb.Interfaces
{
    public interface IDetalleFacturaServicio
    {
        Task<bool> NuevoDetalle(DetalleFactura detalleFactura);
    }
}
