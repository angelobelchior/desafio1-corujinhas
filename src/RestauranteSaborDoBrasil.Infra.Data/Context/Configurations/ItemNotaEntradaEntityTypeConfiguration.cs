using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Infra.Data.Context.Configurations.Base;

namespace RestauranteSaborDoBrasil.Infra.Data.Context.Configurations
{
    public class ItemNotaEntradaEntityTypeConfiguration : EntityTypeConfiguration<ItemNotaEntrada>
    {
        public override void Configure(EntityTypeBuilder<ItemNotaEntrada> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.NotaEntrada)
                .WithMany(x => x.Itens)
                .HasForeignKey(x => x.NotaEntradaId);

            builder.HasOne(x => x.Ingrediente)
                .WithMany(x => x.ItemNotas)
                .HasForeignKey(x => x.IngredienteId);
        }
    }
}
