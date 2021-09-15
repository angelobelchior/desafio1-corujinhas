using AutoMapper;
using RestauranteSaborDoBrasil.Application.Events.LogApp;
using RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Request;
using RestauranteSaborDoBrasil.Application.UseCases.Receitas.Request;
using RestauranteSaborDoBrasil.Domain.Models;
using System;
using System.Linq;

namespace RestauranteSaborDoBrasil.Application.AutoMapper
{
    public class RequestToDomainMappingProfile : Profile
    {
        public RequestToDomainMappingProfile()
        {
            CreateMap<LogEvent, Log>();
            CreateMap<CriarIngredienteRequest, Ingrediente>();
            CreateMap<EditarIngredienteRequest, Ingrediente>();
            CreateMap<PratoRequest.ReceitaRequest, Receita>();
            CreateMap<CriarPratoRequest, Prato>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .AfterMap((src, dest) => {
                    dest.Receitas = src.Receitas.Select(x => new Receita
                    {
                        Id = Guid.NewGuid(),
                        IngredienteId = x.IngredienteId,
                        PratoId = dest.Id,
                        Quantidade = x.Quantidade
                    }).ToList();
                });
            CreateMap<EditarPratoRequest, Prato>()
                .ForMember(dest => dest.Receitas, opt => opt.Ignore());

            CreateMap<PratoRequest.ReceitaRequest, ReceitaRequest.Ingrediente>();
            CreateMap<EditarPratoRequest, EditarReceitaRequest>()
                .ForMember(dest => dest.PratoId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Ingredientes, opt => opt.MapFrom(src => src.Receitas));
        }
    }
}
