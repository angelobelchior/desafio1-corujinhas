using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Infra.Data.Context.Configurations.Base;

namespace RestauranteSaborDoBrasil.Infra.Data.Context.Configurations
{
    public class HistoricoMesaTypeConfiguration : EntityTypeConfiguration<HistoricoMesa>
    {
        public override void Configure(EntityTypeBuilder<HistoricoMesa> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Mesa)
                .WithMany(f => f.Historico)
                .HasForeignKey(x => x.MesaId);
        }
    }
}
