using AplicacionWeb.Interfaces;
using AplicacionWeb.Pages.MisProductos;
using AplicacionWeb.Servicios;
using CurrieTechnologies.Razor.SweetAlert2;
using Entidades;
using Microsoft.AspNetCore.Components;

namespace AplicacionWeb.Pages.MisClientes
{
    public partial class NuevoCliente
    {
        [Inject] private IClienteServicio clienteServicio { get; set; }
        [Inject] private NavigationManager navigationManager { get; set; }

        [Inject] SweetAlertService Swal { get; set; }

        private Cliente cliente = new Cliente();

        protected async void Guardar()
        {
            if (string.IsNullOrEmpty(cliente.Identidad) || string.IsNullOrEmpty(cliente.NombreCliente))
            {
                return;
            }
            Cliente clienteExistente = new Cliente();

            clienteExistente = await clienteServicio.GetPorCodigo(cliente.Identidad);

            // Validar que el 'Codigo' de un producto no sea el mismo para varios productos
            if (clienteExistente != null)
            {
                // Si extiste un producto con el mismo 'Codigo', mostrara una advertencia
                if (clienteExistente.Identidad == cliente.Identidad)
                {
                    await Swal.FireAsync("Advertencia", "Ya existe un cliente con esta identidad", SweetAlertIcon.Warning);
                    return;
                }
            }


            bool inserto = await clienteServicio.Nuevo(cliente);

            if (inserto)
            {
                await Swal.FireAsync("Correcto", "Cliente Guardado", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo guardar el cliente", SweetAlertIcon.Error);
            }

            navigationManager.NavigateTo("/Clientes");

        }

        protected void Cancelar()
        {
            navigationManager.NavigateTo("/Clientes");


        }




    }
}
