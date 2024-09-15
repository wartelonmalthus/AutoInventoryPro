using AutoInventoryPro.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoInventoryPro.Infraestructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Usuarios");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Id).HasColumnName("UsuarioID").IsRequired().ValueGeneratedOnAdd();
        builder.Property(d => d.Name).HasColumnName("NomeUsuario").IsRequired();
        builder.Property(d => d.Password).HasColumnName("Senha").IsRequired();
        builder.Property(d => d.Email).HasColumnName("Email").IsRequired();
        builder.Property(d => d.UserRole).HasColumnName("NivelAcesso").IsRequired();
        builder.Property(c => c.CreateAt).HasColumnName("CriadoEm").IsRequired();
        builder.Property(c => c.UpdatedAt).HasColumnName("AlteradoEm");
        builder.Property(c => c.SoftDelete).HasColumnName("Delecao_Logica");

    }
}
