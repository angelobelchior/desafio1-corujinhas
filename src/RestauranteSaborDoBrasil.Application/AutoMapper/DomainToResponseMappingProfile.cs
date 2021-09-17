using AutoMapper;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Response;
using RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Response;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Response;
using RestauranteSaborDoBrasil.Domain.Models;

namespace RestauranteSaborDoBrasil.Application.AutoMapper
{
    public class DomainToResponseMappingProfile : Profile
    {
        public DomainToResponseMappingProfile()
        {
            CreateMap<Ingrediente, IngredienteResponse>();
            
            CreateMap<Receita, PratoResponse.ReceitaResponse>()
                .ForMember(dest => dest.Ingrediente, opt => opt.MapFrom(src => src.Ingrediente.Descricao));
            CreateMap<Prato, PratoResponse>();
            
            CreateMap<Cardapio, CardapioResponse>();
            CreateMap<PratoCardapio, CardapioResponse.PratoResponse>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Prato.Nome))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Prato.Descricao));
        }
    }
}
