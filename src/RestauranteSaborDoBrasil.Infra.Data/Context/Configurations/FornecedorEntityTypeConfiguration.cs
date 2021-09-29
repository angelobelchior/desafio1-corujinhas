using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Infra.Data.Context.Configurations.Base;

namespace RestauranteSaborDoBrasil.Infra.Data.Context.Configurations
{
    public class FornecedorEntityTypeConfiguration : EntityTypeConfiguration<Fornecedor>
    {
        public override void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Cnpj)
                .HasColumnType("varchar(14)");
            builder.Property(x => x.NomeFantassia)
                .HasColumnType("varchar(200)")
                .IsRequired();
            builder.Property(x => x.RazaoSocial)
                .HasColumnType("varchar(200)")
                .IsRequired();
            builder.Property(x => x.InscricaoEstadual)
                .HasColumnType("varchar(20)");
            builder.Property(x => x.InscricaoMunicipal)
                .HasColumnType("varchar(20)");
        }
    }
}
