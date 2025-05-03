using System;
using System.Collections.Generic;

namespace Vandic.Data.EfCore.Temp;

public partial class Category
{
    /// <summary>
    /// Chave primária
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Auto Incremento
    /// </summary>
    public int AlternativeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string NameMenu { get; set; } = null!;

    public Guid? CategoryRootId { get; set; }

    /// <summary>
    /// Nome do Usuario que criou o registro
    /// </summary>
    public string CreatedBy { get; set; } = null!;

    /// <summary>
    /// Nome do ultimo usuário que modificou registro
    /// </summary>
    public string? ModifiedBy { get; set; }

    /// <summary>
    /// nome do usuário que excluiu o registro
    /// </summary>
    public string? DeletedBy { get; set; }

    /// <summary>
    /// data de criação do registro (criado em)
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// data da modificação
    /// </summary>
    public DateTime? ModifiedAt { get; set; }

    /// <summary>
    /// data da exclusao
    /// </summary>
    public DateTime? DeletedAt { get; set; }

    public virtual Category? CategoryRoot { get; set; }

    public virtual ICollection<Category> InverseCategoryRoot { get; set; } = new List<Category>();
}
