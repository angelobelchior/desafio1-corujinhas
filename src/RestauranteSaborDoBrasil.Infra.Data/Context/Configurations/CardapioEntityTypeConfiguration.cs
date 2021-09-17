using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestauranteSaborDoBrasil.Domain.Enums;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Infra.Data.Context.Configurations.Base;

namespace RestauranteSaborDoBrasil.Infra.Data.Context.Configurations
{
    public class CardapioEntityTypeConfiguration : EntityTypeConfiguration<Cardapio>
    {
        public override void Configure(EntityTypeBuilder<Cardapio> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.DiaSemana)
                .HasColumnType("varchar(50)")
                .HasConversion(new EnumToStringConverter<DiaSemana>());

            builder.HasIndex(x => x.DiaSemana)
                .IsUnique();
        }
    }
}
