using AutoMapper;
using RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Response;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Response;
using RestauranteSaborDoBrasil.Domain.Models;
using System.Collections.Generic;

namespace RestauranteSaborDoBrasil.Application.AutoMapper
{
    public class DomainToResponseMappingProfile : Profile
    {
        public DomainToResponseMappingProfile()
        {
            CreateMap<Receita, PratoResponse.ReceitaResponse>()
                .ForMember(dest => dest.Ingrediente, opt => opt.MapFrom(src => src.Ingrediente.Descricao));
            CreateMap<Ingrediente, IngredienteResponse>();
            CreateMap<Prato, PratoResponse>();
        }
    }
}
