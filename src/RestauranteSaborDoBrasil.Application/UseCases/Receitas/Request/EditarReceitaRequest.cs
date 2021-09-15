using System;

namespace RestauranteSaborDoBrasil.Application.UseCases.Receitas.Request
{
    public class EditarReceitaRequest : ReceitaRequest
    {
        public Guid Id { get; set; }
    }
}
