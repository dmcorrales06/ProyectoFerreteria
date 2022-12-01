using AplicacionWeb.Interfaces;
using Entidades;
using Microsoft.AspNetCore.Components;

namespace AplicacionWeb.Pages.MisProductos
{
    public partial class Productos
    {

        [Inject] IProductoServicio productoServicio { get; set; }

        IEnumerable<Producto> listaProductos { get; set; }

        protected override async Task OnInitializedAsync()
        {
            listaProductos = await productoServicio.GetLista();
        }

    }
}
