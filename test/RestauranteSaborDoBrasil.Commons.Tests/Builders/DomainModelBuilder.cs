using Bogus;
using RestauranteSaborDoBrasil.Domain.Enums;
using RestauranteSaborDoBrasil.Domain.Models;

namespace RestauranteSaborDoBrasil.Commons.Tests.Builders
{
    public static class DomainModelBuilder
    {
        public static Cardapio Cardapio
            => new Faker<Cardapio>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.DiaSemana, f => DiaSemana.Domingo)
            .RuleFor(x => x.Pratos, f => f.Make(f.Random.Int(1,4), () => PratoCardapio));

        public static PratoCardapio PratoCardapio
            => new Faker<PratoCardapio>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.Preco, f => f.Random.Float(1))
            .RuleFor(x => x.Prato, f => Prato);

        public static Prato Prato
            => new Faker<Prato>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.Nome, f => f.Random.Word())
            .RuleFor(x => x.Descricao, f => f.Lorem.Paragraphs(f.Random.Int(1,5)))
            .RuleFor(x => x.Receitas, f => f.Make(f.Random.Int(1,10), () => Receita));

        public static Receita Receita
            => new Faker<Receita>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.PratoId, f => f.Random.Guid())
            .RuleFor(x => x.Quantidade, f => f.Random.Float(1, 5))
            .RuleFor(x => x.Ingrediente, Ingrediente);

        public static Ingrediente Ingrediente
            => new Faker<Ingrediente>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.Descricao, f => f.Random.Word())
            .RuleFor(x => x.EstoqueMinimo, f => 10)
            .RuleFor(x => x.EstoqueMaximo, f => f.Random.Float(11, 30))
            .RuleFor(x => x.EstoqueAtual, f => f.Random.Float(1, 100));

    }
}
