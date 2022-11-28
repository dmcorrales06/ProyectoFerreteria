using AplicacionWeb.Interfaces;
using Entidades;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks.Sources;


namespace AplicacionWeb.Pages.MisUsuarios
{
    public partial class Usuarios
    {

        [Inject] private IUsuarioServicio usuarioServicio { get; set; }

        private IEnumerable<Usuario> lista { get; set; }

        protected override async Task OnInitializedAsync()
        {
            lista = await usuarioServicio.GetLista();
        }
    }
}
