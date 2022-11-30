using AplicacionWeb.Interfaces;
using Datos.Interfaces;
using Datos.Repositorios;
using Entidades;

namespace AplicacionWeb.Servicios
{
    public class ClienteServicio : IClienteServicio
    {

        private readonly Config _configuracion;
        private IClienteRepositorio clienteRepositorio;

        public ClienteServicio(Config config)
        {
            _configuracion = config;
            clienteRepositorio = new ClienteRepositorio(config.CadenaConexion);
        }


        public async Task<bool> Actualizar(Cliente cliente)
        {
            return await clienteRepositorio.Actualizar(cliente);
        }

        public async Task<bool> Eliminar(string Identidad)
        {
            return await clienteRepositorio.Eliminar(Identidad);
        }

        public async Task<IEnumerable<Cliente>> GetLista()
        {
            return await clienteRepositorio.GetLista();
        }

        public async Task<Cliente> GetPorCodigo(string Identidad)
        {
            return await clienteRepositorio.GetPorCodigo(Identidad);
        }

        public async Task<bool> Nuevo(Cliente cliente)
        {
            return await clienteRepositorio.Nuevo(cliente);
        }



    }
}
