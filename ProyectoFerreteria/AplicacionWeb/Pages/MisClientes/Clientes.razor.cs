using AplicacionWeb.Interfaces;
using Entidades;
using Microsoft.AspNetCore.Components;

namespace AplicacionWeb.Pages.MisClientes
{
    public partial class Clientes
    {

        [Inject] private IClienteServicio clienteServicio { get; set; }

        private IEnumerable<Cliente> lista { get; set; }

        protected override async Task OnInitializedAsync()
        {
            lista = await clienteServicio.GetLista();

        }


    }
}
