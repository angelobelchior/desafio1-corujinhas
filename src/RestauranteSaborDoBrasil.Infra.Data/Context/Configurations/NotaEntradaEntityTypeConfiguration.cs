using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Infra.Data.Context.Configurations.Base;

namespace RestauranteSaborDoBrasil.Infra.Data.Context.Configurations
{
    public class NotaEntradaEntityTypeConfiguration : EntityTypeConfiguration<NotaEntrada>
    {
        public override void Configure(EntityTypeBuilder<NotaEntrada> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Numero)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.HasOne(x => x.Fornecedor)
                .WithMany(x => x.Notas)
                .HasForeignKey(x => x.FornecedorId);
        }
    }
}
