using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Infra.Data.Context.Configurations.Base;

namespace RestauranteSaborDoBrasil.Infra.Data.Context.Configurations
{
    public class IngredienteEntityTypeConfiguration : EntityTypeConfiguration<Ingrediente>
    {
        public override void Configure(EntityTypeBuilder<Ingrediente> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar(200)")
                .IsRequired();
        }
    }
}
