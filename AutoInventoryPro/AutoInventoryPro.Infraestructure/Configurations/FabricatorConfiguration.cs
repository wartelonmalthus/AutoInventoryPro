using AutoInventoryPro.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoInventoryPro.Infraestructure.Configurations;

public class FabricatorConfiguration : IEntityTypeConfiguration<Fabricator>
{
    public void Configure(EntityTypeBuilder<Fabricator> builder)
    {
        builder.ToTable("Fabricantes");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("FabricanteID").IsRequired().ValueGeneratedOnAdd();
        builder.Property(d => d.Name).HasColumnName("Nome").IsRequired();
        builder.Property(d => d.Country).HasColumnName("PaisOrigem").IsRequired();
        builder.Property(d => d.YearFoundation).HasColumnName("AnoFundacao").IsRequired();
        builder.Property(d => d.WebSite).HasColumnName("Website").IsRequired();
        builder.Property(c => c.CreateAt).HasColumnName("CriadoEm").IsRequired();
        builder.Property(c => c.UpdatedAt).HasColumnName("AlteradoEm");
        builder.Property(c => c.SoftDelete).HasColumnName("Delecao_Logica");

        builder.HasMany(f => f.Vehicles).WithOne(v => v.Fabricator).HasForeignKey(v => v.IdFabricator).OnDelete(DeleteBehavior.Restrict);

    }
}
