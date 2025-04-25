using Vandic.Domain.Abstracts;

namespace Vandic.Domain.Models
{
    public class Categoria: AggregateRoot
    {
        public string Nome { get; set; }
    }
}
