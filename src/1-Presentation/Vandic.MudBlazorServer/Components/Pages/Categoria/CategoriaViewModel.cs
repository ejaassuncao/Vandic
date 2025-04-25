using System.ComponentModel.DataAnnotations;

namespace Vandic.MudBlazorServer.Components.Pages.Categoria
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
