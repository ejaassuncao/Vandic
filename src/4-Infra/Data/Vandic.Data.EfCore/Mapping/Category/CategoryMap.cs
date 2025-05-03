using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vandic.Domain.Models;

namespace Vandic.Data.EfCore.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(e => e.Id).HasName("category_id_pk");

            entity.ToTable("category");

            entity.HasIndex(e => e.CategoryRootId, "category_category_root_id_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasComment("Chave primária")
                .HasColumnName("id");
            entity.Property(e => e.AlternativeId)
                .ValueGeneratedOnAddOrUpdate()
                .HasComment("Auto Incremento")
                .HasColumnName("alternative_id");
            entity.Property(e => e.CategoryRootId).HasColumnName("category_root_id");
            entity.Property(e => e.CreatedAt)
                .HasComment("data de criação do registro (criado em)")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Nome do Usuario que criou o registro")
                .HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasComment("data da exclusao")
                .HasColumnType("datetime")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DeletedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("nome do usuário que excluiu o registro")
                .HasColumnName("deleted_by");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ModifiedAt)
                .HasComment("data da modificação")
                .HasColumnType("datetime")
                .HasColumnName("modified_at");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Nome do ultimo usuário que modificou registro")
                .HasColumnName("modified_by");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.NameMenu)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name_menu");

            entity.HasOne(d => d.CategoryRoot).WithMany(p=>p.InverseCategoryRoot)
                .HasForeignKey(d => d.CategoryRootId)
                .HasConstraintName("category_category_fk");

        }
    }
}
