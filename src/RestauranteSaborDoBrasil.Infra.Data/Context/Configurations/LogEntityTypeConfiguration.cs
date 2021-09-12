using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestauranteSaborDoBrasil.Domain.Enums;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Infra.Data.Context.Configurations.Base;

namespace RestauranteSaborDoBrasil.Infra.Data.Context.Configurations
{
    public class LogEntityTypeConfiguration : EntityTypeConfiguration<Log>
    {
        public override void Configure(EntityTypeBuilder<Log> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Mensagem)
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder.Property(x => x.Tipo)
                .HasColumnType("varchar(100)")
                .HasConversion(new EnumToStringConverter<TipoLog>())
                .IsRequired();
        }
    }
}
