using AplicacionWeb.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Entidades;
using Microsoft.AspNetCore.Components;

namespace AplicacionWeb.Pages.MisClientes
{
	public partial class EditarClientes
	{
		[Inject] private IClienteServicio clienteServicio { get; set; }
		[Inject] private NavigationManager navigationManager { get; set; }
		private Cliente cliente = new Cliente();

		[Inject] SweetAlertService Swal { get; set; }

		[Parameter] public string Identidad { get; set; }

		protected override async Task OnInitializedAsync()
		{
			if (!string.IsNullOrEmpty(Identidad))
			{
				cliente = await clienteServicio.GetPorCodigo(Identidad);
			}
		}

		protected async void Guardar()
		{
			if (string.IsNullOrEmpty(cliente.Identidad) || string.IsNullOrEmpty(cliente.NombreCliente))
				//|| string.IsNullOrEmpty(cliente.Direccion) || string.IsNullOrEmpty(cliente.Email) || cliente.Telefono == "Seleccionar")
			{
				return;
			}

			bool edito = await clienteServicio.Actualizar(cliente);

			if (edito)
			{
				await Swal.FireAsync("Correcto", "Cliente Actualizado", SweetAlertIcon.Success);
			}
			else
			{
				await Swal.FireAsync("Error", "No se pudo Actualizar el cliente", SweetAlertIcon.Error);
			}

			navigationManager.NavigateTo("/Clientes");
		}

		protected void Cancelar()
		{
			navigationManager.NavigateTo("/Clientes");
		}

		protected async void Eliminar()
		{
			bool elimino = false;

			SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
			{
				Title = "¿Seguro que desea eliminar el Cliente?",
				Icon = SweetAlertIcon.Question,
				ShowCancelButton = true,
				ConfirmButtonText = "Aceptar",
				CancelButtonText = "Cancelar"
			});

			if (!string.IsNullOrEmpty(result.Value))
			{
				elimino = await clienteServicio.Eliminar(Identidad);

				if (elimino)
				{
					await Swal.FireAsync("Correcto", "Cliente Eliminado", SweetAlertIcon.Success);
					navigationManager.NavigateTo("/Clientes");
				}
				else
				{
					await Swal.FireAsync("Error", "No se pudo Eliminar el cliente", SweetAlertIcon.Error);
				}
			}
		}







	}
}
