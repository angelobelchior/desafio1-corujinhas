using AutoMapper;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Response;
using RestauranteSaborDoBrasil.Domain.Models;

namespace RestauranteSaborDoBrasil.Application.AutoMapper
{
    public class DomainToResponseMappingProfile : Profile
    {
        public DomainToResponseMappingProfile()
        {
            CreateMap<Receita, PratoResponse.ReceitaResponse>()
                .ForMember(dest => dest.Ingrediente, opt => opt.MapFrom(src => src.Ingrediente.Descricao));
            CreateMap<Prato, PratoResponse>();
        }
    }
}
