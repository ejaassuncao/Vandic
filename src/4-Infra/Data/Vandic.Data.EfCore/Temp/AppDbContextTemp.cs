using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Vandic.Data.EfCore.Temp;

public partial class AppDbContextTemp : DbContext
{
    public AppDbContextTemp()
    {
    }

    public AppDbContextTemp(DbContextOptions<AppDbContextTemp> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
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

            entity.HasOne(d => d.CategoryRoot).WithMany(p => p.InverseCategoryRoot)
                .HasForeignKey(d => d.CategoryRootId)
                .HasConstraintName("category_category_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
