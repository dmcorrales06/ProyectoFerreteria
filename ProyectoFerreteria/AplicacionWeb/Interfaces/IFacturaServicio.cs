using Entidades;

namespace AplicacionWeb.Interfaces
{
    public interface IFacturaServicio
    {
        Task<int> NuevaFactura(Factura factura);
    }
}
