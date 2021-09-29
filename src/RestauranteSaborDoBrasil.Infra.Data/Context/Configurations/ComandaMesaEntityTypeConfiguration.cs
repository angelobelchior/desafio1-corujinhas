using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Infra.Data.Context.Configurations.Base;

namespace RestauranteSaborDoBrasil.Infra.Data.Context.Configurations
{
    public class ComandaMesaEntityTypeConfiguration : EntityTypeConfiguration<ComandaMesa>
    {
        public override void Configure(EntityTypeBuilder<ComandaMesa> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Mesa)
                .WithMany(x => x.Comandas)
                .HasForeignKey(x => x.MesaId);

            builder.HasOne(x => x.Comanda)
                .WithOne(x => x.ComandaMesa);
        }
    }
}
