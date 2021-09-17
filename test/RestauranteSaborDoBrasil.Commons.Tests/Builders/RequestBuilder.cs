using Bogus;
using RestauranteSaborDoBrasil.Domain.Enums;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Receitas.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Request;

namespace RestauranteSaborDoBrasil.Commons.Tests.Builders
{
    public static class RequestBuilder
    {
        public static CriarCardapioRequest CriarCardapioRequest
            => new Faker<CriarCardapioRequest>()
            .RuleFor(x => x.DiaSemana, f => DiaSemana.Domingo)
            .RuleFor(x => x.Pratos, f => f.Make(f.Random.Int(1, 4), () => CardapioPratoRequest));

        public static EditarCardapioRequest EditarCardapioRequest
            => new Faker<EditarCardapioRequest>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.DiaSemana, f => DiaSemana.Domingo)
            .RuleFor(x => x.Pratos, f => f.Make(f.Random.Int(1, 4), () => CardapioPratoRequest));

        private static CardapioRequest.PratoRequest CardapioPratoRequest
            => new Faker<CardapioRequest.PratoRequest>()
            .RuleFor(x => x.PratoId, f => f.Random.Guid())
            .RuleFor(x => x.Preco, f => f.Random.Float(1, 100));

        public static CriarIngredienteRequest CriarIngredienteRequest
            => new Faker<CriarIngredienteRequest>()
            .RuleFor(x => x.Descricao, f => f.Random.Words(2))
            .RuleFor(x => x.EstoqueMinimo, f => 10)
            .RuleFor(x => x.EstoqueMaximo, f => f.Random.Float(20, 30));

        public static EditarIngredienteRequest EditarIngredienteRequest
            => new Faker<EditarIngredienteRequest>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.Descricao, f => f.Random.Words(2))
            .RuleFor(x => x.EstoqueMinimo, f => 10)
            .RuleFor(x => x.EstoqueMaximo, f => f.Random.Float(20, 30));

        public static PratoRequest.ReceitaRequest PratoReceitaRequest
          => new Faker<PratoRequest.ReceitaRequest>()
          .RuleFor(x => x.IngredienteId, f => f.Random.Guid())
          .RuleFor(x => x.Quantidade, f => f.Random.Float(1));

        public static CriarPratoRequest CriarPratoRequest
            => new Faker<CriarPratoRequest>()
            .RuleFor(x => x.Nome, f => f.Random.Word())
            .RuleFor(x => x.Descricao, f => f.Lorem.Paragraph())
            .RuleFor(x => x.Receitas, f => f.Make(f.Random.Int(1, 5), () => PratoReceitaRequest));

        public static EditarPratoRequest EditarPratoRequest
            => new Faker<EditarPratoRequest>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.Nome, f => f.Random.Word())
            .RuleFor(x => x.Descricao, f => f.Lorem.Paragraph())
            .RuleFor(x => x.Receitas, f => f.Make(f.Random.Int(1, 5), () => PratoReceitaRequest));

        public static EditarReceitaRequest EditarReceitaRequest
            => new Faker<EditarReceitaRequest>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.PratoId, f => f.Random.Guid())
            .RuleFor(x => x.Ingredientes, f => f.Make(f.Random.Int(1, 10), () => ReceitaIngrediente));

        public static ReceitaRequest.Ingrediente ReceitaIngrediente
            => new Faker<ReceitaRequest.Ingrediente>()
            .RuleFor(x => x.IngredienteId, f => f.Random.Guid())
            .RuleFor(x => x.Quantidade, f => f.Random.Float(1, 5));
    }
}
