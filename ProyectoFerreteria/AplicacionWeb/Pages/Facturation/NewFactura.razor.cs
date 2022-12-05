using AplicacionWeb.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Entidades;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace AplicacionWeb.Pages.Facturation
{
	public partial class NewFactura
	{
		[Inject] private IFacturaServicio facturaServicio { get; set; }
		[Inject] private IDetalleFacturaServicio detalleFacturaServicio { get; set; }
		[Inject] private IProductoServicio productoServicio { get; set; }
		[Inject] private IClienteServicio clienteServicio { get; set; }
		[Inject] private NavigationManager navigationManager { get; set; }
		[Inject] private SweetAlertService Swal { get; set; }
		[Inject] private IHttpContextAccessor httpContextAccessor { get; set; }

		private Factura factura = new Factura();
		DetalleFactura detalleFactura;
		private List<DetalleFactura> ListaDetalleFactura = new List<DetalleFactura>();
		private Producto producto = new Producto();
		private Cliente cliente = new Cliente();

		private int cantidad { get; set; }
		private string codigoProducto { get; set; }
		private string identidadCliente { get; set; }

		protected override async Task OnInitializedAsync()
		{
			factura.Fecha = DateTime.Now;
		}

		private void LimpiarControles()
		{
			identidadCliente = string.Empty;
			cliente.NombreCliente = string.Empty;
			factura.SubTotal = 0;
			factura.Descuento = 0;
			factura.ISV = 0;
			factura.Total = 0;
			ListaDetalleFactura.Clear();
		}

		private async void BuscarCliente()
		{
			cliente = await clienteServicio.GetPorCodigo(identidadCliente);
		}

		private async void BuscarProducto()
		{
			producto = await productoServicio.GetPorCodigo(Convert.ToInt32(codigoProducto));
		}

		protected async Task AgregarProducto(MouseEventArgs args)
		{
			if (args.Detail != 0)
			{
				DetalleFactura detalleFactura = new DetalleFactura();

				if (cliente != null)
				{
					factura.IdentidadCliente = identidadCliente;
					detalleFactura.NombreCliente = cliente.NombreCliente;
				}

				if (producto != null)
				{
					detalleFactura.Producto = producto.Descripcion;
					detalleFactura.CodigoProducto = producto.Codigo;
					detalleFactura.Cantidad = Convert.ToInt32(cantidad);
					detalleFactura.Precio = producto.Precio;
					detalleFactura.Total = producto.Precio * Convert.ToInt32(cantidad);

					ListaDetalleFactura.Add(detalleFactura);

					producto.Codigo = 0;
					producto.Descripcion = string.Empty;
					producto.Precio = 0;
					producto.Existencia = 0;
					cantidad = 0;
					codigoProducto = "0";

					factura.SubTotal = factura.SubTotal + detalleFactura.Total;

					if (factura.SubTotal > 1000)
					{
						factura.Descuento = factura.SubTotal * 0.05M;
						factura.ISV = (factura.SubTotal - factura.Descuento) * 0.15M;
						factura.Total = (factura.SubTotal - factura.Descuento) + factura.ISV;
					}
					else
					{
						factura.Descuento = 0;
						factura.ISV = factura.SubTotal * 0.15M;
						factura.Total = factura.SubTotal + factura.ISV;
					}
				}
			}
		}

		protected async Task Guardar()
		{
			factura.CodigoUsuario = httpContextAccessor.HttpContext.User.Identity.Name;

			int IdFactura = await facturaServicio.NuevaFactura(factura);
			if (IdFactura != 0)
			{
				foreach (var item in ListaDetalleFactura)
				{
					item.IdFactura = IdFactura;
					await detalleFacturaServicio.NuevoDetalle(item);
				}
				await Swal.FireAsync("Correcto", "factura guardada con éxito", SweetAlertIcon.Success);
				LimpiarControles();
			}
			else
			{
				await Swal.FireAsync("Error", "No se guardó la factura", SweetAlertIcon.Error);
			}
		}
	}
}
