using AplicacionWeb.Interfaces;
using Entidades;
using Microsoft.AspNetCore.Components;

namespace AplicacionWeb.Pages.MisClientes
{
    public partial class NuevoCliente
    {
        [Inject] private IClienteServicio clienteServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }

        private Cliente cliente = new Cliente();

        protected async void Guardar()
        {
            if (string.IsNullOrEmpty(cliente.Identidad) || string.IsNullOrEmpty(cliente.NombreCliente))
            {
                return;
            }

            bool inserto = await clienteServicio.Nuevo(cliente);

            navigationManager.NavigateTo("/Clientes");

        }

        protected void Cancelar()
        {
            navigationManager.NavigateTo("/Clientes");


        }




    }
}
