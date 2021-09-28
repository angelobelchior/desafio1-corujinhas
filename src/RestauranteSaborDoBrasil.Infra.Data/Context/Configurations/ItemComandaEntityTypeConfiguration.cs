using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Infra.Data.Context.Configurations.Base;

namespace RestauranteSaborDoBrasil.Infra.Data.Context.Configurations
{
    public class ItemComandaEntityTypeConfiguration : EntityTypeConfiguration<ItemComanda>
    {
        public override void Configure(EntityTypeBuilder<ItemComanda> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Comanda)
                .WithMany(x => x.Itens)
                .HasForeignKey(x => x.ComandaId);

            builder.HasOne(x => x.Prato)
                .WithMany(x => x.Comandas)
                .HasForeignKey(x => x.PratoId);
        }
    }
}
