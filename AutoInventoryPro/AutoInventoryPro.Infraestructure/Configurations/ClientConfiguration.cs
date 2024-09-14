using AutoInventoryPro.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoInventoryPro.Infraestructure.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clientes");
        builder.HasKey(d => d.Id);

        builder.Property(c => c.Id).HasColumnName("ClienteID").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Nome").IsRequired();
        builder.Property(c => c.CPF).HasColumnName("CPF").IsRequired();
        builder.Property(c => c.Phone).HasColumnName("Telefone").IsRequired();
        builder.Property(c => c.CreateAt).HasColumnName("CriadoEm").IsRequired();
        builder.Property(c => c.UpdatedAt).HasColumnName("AlteradoEm");
        builder.Property(c => c.SoftDelete).HasColumnName("Delecao_Logica");

       builder.HasMany(c => c.Sales).WithOne(s => s.Client).HasForeignKey(s => s.IdClient).OnDelete(DeleteBehavior.Restrict);
    }
}
