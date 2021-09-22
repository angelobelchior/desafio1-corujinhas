using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Infra.Data.Context.Configurations.Base;
using System.Collections.Generic;
using System;

namespace RestauranteSaborDoBrasil.Infra.Data.Context.Configurations
{
    public class MesaEntityTypeConfiguration : EntityTypeConfiguration<Mesa>
    {
        public override void Configure(EntityTypeBuilder<Mesa> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Numero)
                .HasColumnType("varchar(2)")
                .IsRequired();

            builder.HasData(ConfigureData());
        }

        private List<Mesa> ConfigureData()
        => new() {
            new Mesa{Id = new Guid( "8f32249b-0819-4272-8704-594511e24596" ), Numero = "01", QuantidadeMax = 6},
            new Mesa{Id = new Guid( "19e3e924-771e-4a85-852c-b8d0eb787284" ), Numero = "02", QuantidadeMax = 6},
            new Mesa{Id = new Guid( "a7a8f253-1fd0-441c-97a5-f9ad6aafd7ac" ), Numero = "03", QuantidadeMax = 6},
            new Mesa{Id = new Guid( "2cdab575-5995-4bb8-a8ff-1fbf28c8247b" ), Numero = "04", QuantidadeMax = 6},
            new Mesa{Id = new Guid( "4daa1d7b-2d3b-48e9-80fe-51ef7fdf6dcb" ), Numero = "05", QuantidadeMax = 6},
            new Mesa{Id = new Guid( "82f0a7b0-5d36-4f93-b558-210012960ecf" ), Numero = "06", QuantidadeMax = 6},
            new Mesa{Id = new Guid( "c316ae0e-2afc-44e2-8c16-86637a0e7bfc" ), Numero = "07", QuantidadeMax = 6},
            new Mesa{Id = new Guid( "fe9ff411-2bf0-4424-9e3a-868732ad2140" ), Numero = "08", QuantidadeMax = 6},
            new Mesa{Id = new Guid( "0ae6aa2e-064f-4b5e-bc1e-5468bfdcd5ed" ), Numero = "09", QuantidadeMax = 6},
            new Mesa{Id = new Guid( "5edd16a3-3f19-4214-8986-a867fd76e5ff" ), Numero = "10", QuantidadeMax = 6},
            new Mesa{Id = new Guid( "c169b985-cc94-4a56-81e7-25a57b74cdc2" ), Numero = "11", QuantidadeMax = 6},
            new Mesa{Id = new Guid( "7413ed05-521c-497e-8eba-7d8c83c7bfb7" ), Numero = "12", QuantidadeMax = 6},
            new Mesa{Id = new Guid( "9220a944-194d-4fab-a372-643bc01fb2a4" ), Numero = "13", QuantidadeMax = 6},
            new Mesa{Id = new Guid( "e91a45d8-7224-48c3-a29b-84d46fdafb67" ), Numero = "14", QuantidadeMax = 6},
            new Mesa{Id = new Guid( "d4cae3c4-2178-4f90-a2ac-623b3a322ebd" ), Numero = "15", QuantidadeMax = 6},
            new Mesa{Id = new Guid( "8e668119-ef0f-46f7-bc1b-d428d30c1904" ), Numero = "16", QuantidadeMax = 6},
            new Mesa{Id = new Guid( "9d8530bd-a89b-4a9b-9de4-d0576debd947" ), Numero = "17", QuantidadeMax = 6},
            new Mesa{Id = new Guid( "1adb73e8-0a2d-403d-88cb-7f561e864f64" ), Numero = "18", QuantidadeMax = 6},
            new Mesa{Id = new Guid( "9fb5adab-b100-49b3-8ab3-5b9d5656c21a" ), Numero = "19", QuantidadeMax = 6},
            new Mesa{Id = new Guid( "b6b1ef31-dd14-4f53-b114-bbc08a75f648" ), Numero = "20", QuantidadeMax = 6},

        };
    }
}
