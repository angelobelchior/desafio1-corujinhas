using AutoMapper;
using RestauranteSaborDoBrasil.Application.Events.Log;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Request;
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
            CreateMap<PratoRequest.ReceitaRequest, Receita>();
            CreateMap<CriarPratoRequest, Prato>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .AfterMap((src, dest) => {
                    dest.Receitas = src.Receita.Select(x => new Receita
                    {
                        Id = Guid.NewGuid(),
                        IngredienteId = x.IngredienteId,
                        PratoId = dest.Id,
                        Quantidade = x.Quantidade
                    }).ToList();
                });
        }
    }
}
