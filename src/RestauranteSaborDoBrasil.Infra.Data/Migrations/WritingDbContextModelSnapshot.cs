﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestauranteSaborDoBrasil.Infra.Data.Context;

namespace RestauranteSaborDoBrasil.Infra.Data.Migrations
{
    [DbContext(typeof(WritingDbContext))]
    partial class WritingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestauranteSaborDoBrasil.Domain.Models.Cardapio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiaSemana")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("DiaSemana")
                        .IsUnique();

                    b.ToTable("Cardapio");
                });

            modelBuilder.Entity("RestauranteSaborDoBrasil.Domain.Models.Ingrediente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<float>("EstoqueMaximo")
                        .HasColumnType("real");

                    b.Property<float>("EstoqueMinimo")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Ingrediente");
                });

            modelBuilder.Entity("RestauranteSaborDoBrasil.Domain.Models.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("RestauranteSaborDoBrasil.Domain.Models.MovimentacaoEstoque", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataMovimentacao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IngredienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Quantidade")
                        .HasColumnType("real");

                    b.Property<Guid>("ResponsavelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TipoMovimentacao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IngredienteId");

                    b.ToTable("MovimentacaoEstoque");
                });

            modelBuilder.Entity("RestauranteSaborDoBrasil.Domain.Models.Prato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Prato");
                });

            modelBuilder.Entity("RestauranteSaborDoBrasil.Domain.Models.PratoCardapio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CardapioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PratoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Preco")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CardapioId");

                    b.HasIndex("PratoId", "CardapioId")
                        .IsUnique();

                    b.ToTable("PratoCardapio");
                });

            modelBuilder.Entity("RestauranteSaborDoBrasil.Domain.Models.Receita", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IngredienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PratoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Quantidade")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("IngredienteId");

                    b.HasIndex("PratoId", "IngredienteId")
                        .IsUnique();

                    b.ToTable("Receita");
                });

            modelBuilder.Entity("RestauranteSaborDoBrasil.Domain.Models.MovimentacaoEstoque", b =>
                {
                    b.HasOne("RestauranteSaborDoBrasil.Domain.Models.Ingrediente", "Ingrediente")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediente");
                });

            modelBuilder.Entity("RestauranteSaborDoBrasil.Domain.Models.PratoCardapio", b =>
                {
                    b.HasOne("RestauranteSaborDoBrasil.Domain.Models.Cardapio", "Cardapio")
                        .WithMany("Pratos")
                        .HasForeignKey("CardapioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestauranteSaborDoBrasil.Domain.Models.Prato", "Prato")
                        .WithMany("Cardapios")
                        .HasForeignKey("PratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cardapio");

                    b.Navigation("Prato");
                });

            modelBuilder.Entity("RestauranteSaborDoBrasil.Domain.Models.Receita", b =>
                {
                    b.HasOne("RestauranteSaborDoBrasil.Domain.Models.Ingrediente", "Ingrediente")
                        .WithMany("Receitas")
                        .HasForeignKey("IngredienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestauranteSaborDoBrasil.Domain.Models.Prato", "Prato")
                        .WithMany("Receitas")
                        .HasForeignKey("PratoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediente");

                    b.Navigation("Prato");
                });

            modelBuilder.Entity("RestauranteSaborDoBrasil.Domain.Models.Cardapio", b =>
                {
                    b.Navigation("Pratos");
                });

            modelBuilder.Entity("RestauranteSaborDoBrasil.Domain.Models.Ingrediente", b =>
                {
                    b.Navigation("Movimentacoes");

                    b.Navigation("Receitas");
                });

            modelBuilder.Entity("RestauranteSaborDoBrasil.Domain.Models.Prato", b =>
                {
                    b.Navigation("Cardapios");

                    b.Navigation("Receitas");
                });
#pragma warning restore 612, 618
        }
    }
}
