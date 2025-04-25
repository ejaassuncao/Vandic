using System.ComponentModel.DataAnnotations;

namespace Vandic.MudBlazorServer.Components.Services
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
    }
}
