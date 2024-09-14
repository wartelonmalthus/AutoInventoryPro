using AutoInventoryPro.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoInventoryPro.Infraestructure.Configurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Veiculos");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("VeiculoID").IsRequired();
        builder.Property(d => d.VehicleModel).HasColumnName("Modelo").IsRequired();
        builder.Property(d => d.YearManufacture).HasColumnName("AnoFabricacao").IsRequired();
        builder.Property(d => d.Price).HasColumnName("Preco").IsRequired();
        builder.Property(d => d.VehicleType).HasColumnName("TipoVeiculo").IsRequired();
        builder.Property(d => d.Description).HasColumnName("Descricao").IsRequired();
        builder.Property(d => d.IdFabricator).HasColumnName("FabricanteID").IsRequired();
        builder.Property(c => c.CreateAt).HasColumnName("CriadoEm").IsRequired();
        builder.Property(c => c.UpdatedAt).HasColumnName("AlteradoEm");
        builder.Property(c => c.SoftDelete).HasColumnName("Delecao_Logica");
    }
}
