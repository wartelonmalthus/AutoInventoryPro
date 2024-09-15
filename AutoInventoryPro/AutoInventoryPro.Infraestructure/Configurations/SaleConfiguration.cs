using AutoInventoryPro.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoInventoryPro.Infraestructure.Configurations;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {

        builder.ToTable("Vendas");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("VendaID").IsRequired().ValueGeneratedOnAdd();
        builder.Property(d => d.DataSale).HasColumnName("DataVenda").IsRequired();
        builder.Property(d => d.SalePrice).HasColumnName("PrecoVenda").IsRequired();
        builder.Property(d => d.SaleProtocol).HasColumnName("ProtocoloVenda").IsRequired();
        builder.Property(d => d.IdVehicle).HasColumnName("VeiculoID").IsRequired();
        builder.Property(d => d.IdDealersh).HasColumnName("ConcessionariaID").IsRequired();
        builder.Property(d => d.IdClient).HasColumnName("ClienteID").IsRequired();
        builder.Property(c => c.CreateAt).HasColumnName("CriadoEm").IsRequired();
        builder.Property(c => c.UpdatedAt).HasColumnName("AlteradoEm");
        builder.Property(c => c.SoftDelete).HasColumnName("Delecao_Logica");

    }
}
