using Vandic.Domain.Abstracts;

namespace Vandic.Domain.Models
{
    public class Category : AggregateRoot
    {
        public string Name { get; set; }
    }
}
