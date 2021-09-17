using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestauranteSaborDoBrasil.Domain.Enums;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Infra.Data.Context.Configurations.Base;

namespace RestauranteSaborDoBrasil.Infra.Data.Context.Configurations
{
    public class MovimentacaoEstoqueEntityTypeConfiguration : EntityTypeConfiguration<MovimentacaoEstoque>
    {
        public override void Configure(EntityTypeBuilder<MovimentacaoEstoque> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.TipoMovimentacao)
                .HasColumnType("varchar(50)")
                .HasConversion(new EnumToStringConverter<TipoMovimentacaoEstoque>());

            builder.HasOne(x => x.Ingrediente)
                .WithMany(f => f.Movimentacoes)
                .HasForeignKey(x => x.IngredienteId);
        }
    }
}
