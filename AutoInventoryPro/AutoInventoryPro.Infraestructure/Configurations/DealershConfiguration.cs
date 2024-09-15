using AutoInventoryPro.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoInventoryPro.Infraestructure.Configurations;

public class DealershConfiguration : IEntityTypeConfiguration<Dealersh>
{
    public void Configure(EntityTypeBuilder<Dealersh> builder)
    {
        builder.ToTable("Concessionarias");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("ConcessionariaID").IsRequired().ValueGeneratedOnAdd();
        builder.Property(d => d.Name).HasColumnName("Nome").IsRequired();
        builder.Property(d => d.Address).HasColumnName("Endereco").IsRequired();
        builder.Property(d => d.City).HasColumnName("Cidade").IsRequired();
        builder.Property(d => d.Region).HasColumnName("Estado").IsRequired();
        builder.Property(d => d.PostalCode).HasColumnName("CEP").IsRequired();
        builder.Property(d => d.Phone).HasColumnName("Telefone").IsRequired();
        builder.Property(d => d.Email).HasColumnName("Email").IsRequired();
        builder.Property(d => d.MaximumCapacityVehicles).HasColumnName("CapacidadeMaximaVeiculos").IsRequired();
        builder.Property(c => c.CreateAt).HasColumnName("CriadoEm").IsRequired();
        builder.Property(c => c.UpdatedAt).HasColumnName("AlteradoEm");
        builder.Property(c => c.SoftDelete).HasColumnName("Delecao_Logica");


        builder.HasMany(d => d.Sales).WithOne(s => s.Dealersh).HasForeignKey(s => s.IdDealersh).OnDelete(DeleteBehavior.Restrict);
    }
}
