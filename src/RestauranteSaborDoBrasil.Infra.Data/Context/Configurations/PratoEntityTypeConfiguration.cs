using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Infra.Data.Context.Configurations.Base;

namespace RestauranteSaborDoBrasil.Infra.Data.Context.Configurations
{
    public class PratoEntityTypeConfiguration : EntityTypeConfiguration<Prato>
    {
        public override void Configure(EntityTypeBuilder<Prato> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar(max)");
        }
    }
}
