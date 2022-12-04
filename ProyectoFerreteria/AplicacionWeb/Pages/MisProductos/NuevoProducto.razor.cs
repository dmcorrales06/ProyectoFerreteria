using AplicacionWeb.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Entidades;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Google.Protobuf.WellKnownTypes;
using Datos.Interfaces;

namespace AplicacionWeb.Pages.MisProductos
{
    public partial class NuevoProducto
    {
        [Inject] private IProductoServicio productoServicio { get; set; }

        private Producto prod = new Producto();
        [Inject] private SweetAlertService Swal { get; set; }

        [Inject] NavigationManager _navigationManager { get; set; }

        string imgUrl = string.Empty;

        private async Task SeleccionarIMagen(InputFileChangeEventArgs e)
        {
            IBrowserFile imgFile = e.File;
            var buffers = new byte[imgFile.Size];
            prod.Imagen = buffers;
            await imgFile.OpenReadStream().ReadAsync(buffers);
            string imageType = imgFile.ContentType;
            imgUrl = $"data:{imageType};base64,{Convert.ToBase64String(buffers)}";
        }

        protected async Task Guardar()
        {
            if (string.IsNullOrEmpty(prod.Codigo.ToString()) || string.IsNullOrEmpty(prod.Descripcion))
            {
                return;
            }
            prod.FechaAlmacen = DateTime.Now;
            Producto productoExistente = new Producto();

            productoExistente = await productoServicio.GetPorCodigo(prod.Codigo);

            bool inserto = await productoServicio.Nuevo(prod);

            if (inserto)//true
            {

                await Swal.FireAsync("Advertencia", "Producto guardado con exito", SweetAlertIcon.Success);
                _navigationManager.NavigateTo("/Productos");


            }
            else if (productoExistente != null)
            {
                if (!string.IsNullOrEmpty(productoExistente.Codigo.ToString()))
                {
                    await Swal.FireAsync("Advertencia", "Ya existe un producto con este código", SweetAlertIcon.Warning);
                    return;
                }

            }
            else
            {
                await Swal.FireAsync("Advertencia", "No se pudo guardar el producto", SweetAlertIcon.Error);
            }

        }
        protected async Task Cancelar()
        {
            _navigationManager.NavigateTo("/Productos");
        }

    }
}
