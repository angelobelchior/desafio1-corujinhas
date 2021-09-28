using Microsoft.EntityFrameworkCore;
using RestauranteSaborDoBrasil.Domain.Enums;
using RestauranteSaborDoBrasil.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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

            builder.HasOne(x => x.ItemNotaEntrada)
                .WithOne(x => x.MovimentacaoEstoque)
                .HasForeignKey<MovimentacaoEstoque>(x => x.ItemNotaId);

            builder.HasOne(x => x.ItemComanda)
                .WithOne(x => x.MovimentacaoEstoque)
                .HasForeignKey<MovimentacaoEstoque>(x => x.ItemComandaId);
        }
    }
}
