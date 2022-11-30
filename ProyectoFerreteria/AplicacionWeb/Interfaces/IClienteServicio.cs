using Entidades;

namespace AplicacionWeb.Interfaces
{
    public interface IClienteServicio
    {
        Task<Cliente> GetPorCodigo(string Identidad);
        Task<bool> Nuevo(Cliente cliente);
        Task<bool> Actualizar(Cliente cliente);
        Task<bool> Eliminar(string Identidad);
        Task<IEnumerable<Cliente>> GetLista();




    }
}
