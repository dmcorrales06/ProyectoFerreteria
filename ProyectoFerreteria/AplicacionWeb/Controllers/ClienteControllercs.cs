using Datos.Interfaces;
using Datos.Repositorios;

namespace AplicacionWeb.Controllers
{
    public class ClienteControllercs
    {
        private readonly Config _configuracion;
        private IClienteRepositorio _clienteRepositorio;

        public ClienteControllercs(Config config)
        {
            _configuracion = config;
            _clienteRepositorio = new ClienteRepositorio(config.CadenaConexion);
        }





    }
}
