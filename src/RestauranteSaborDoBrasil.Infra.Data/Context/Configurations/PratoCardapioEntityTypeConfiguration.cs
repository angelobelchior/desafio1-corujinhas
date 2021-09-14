using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Infra.Data.Context.Configurations.Base;

namespace RestauranteSaborDoBrasil.Infra.Data.Context.Configurations
{
    public class PratoCardapioEntityTypeConfiguration : EntityTypeConfiguration<PratoCardapio>
    {
        public override void Configure(EntityTypeBuilder<PratoCardapio> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Prato)
                .WithMany(f => f.Cardapios)
                .HasForeignKey(x => x.PratoId);

            builder.HasOne(x => x.Cardapio)
                .WithMany(f => f.Pratos)
                .HasForeignKey(x => x.CardapioId);
        }
    }
}
