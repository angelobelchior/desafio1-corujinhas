using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Infra.Data.Context.Configurations.Base;

namespace RestauranteSaborDoBrasil.Infra.Data.Context.Configurations
{
    public class ReceitaEntityTypeConfiguration : EntityTypeConfiguration<Receita>
    {
        public override void Configure(EntityTypeBuilder<Receita> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Prato)
                .WithMany(f => f.Receitas)
                .HasForeignKey(x => x.PratoId);

            builder.HasOne(x => x.Ingrediente)
                .WithMany(f => f.Receitas)
                .HasForeignKey(x => x.IngredienteId);
        }
    }
}
