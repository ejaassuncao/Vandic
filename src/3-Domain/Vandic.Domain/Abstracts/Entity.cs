namespace Vandic.Domain.Abstracts
{
    public class Entity
    {
        public Guid Id { get; set; }

        public int InternalId { get; set; }

        public bool Excluido { get; set; }

        public string CriadoPor { get; set; } = string.Empty;

        public string AlteradoPor { get; set; } = string.Empty;

        public string ExcluidoPor { get; set; } = string.Empty;
         
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime DataExclusao { get; set; }

    }
}
