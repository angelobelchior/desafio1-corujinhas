using AutoMapper;
using System;
using System.Linq.Expressions;

namespace RestauranteSaborDoBrasil.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AllowNullDestinationValues = true;
                cfg.AllowNullCollections = true;

                cfg.DisableConstructorMapping();

                cfg.ForAllMaps
                (
                    (mapType, mapperExpression) =>
                    {
                        mapperExpression.MaxDepth(1);
                    }
                );

                cfg.AddProfile(new DomainToResponseMappingProfile());
                cfg.AddProfile(new RequestToDomainMappingProfile());
            });
        }

        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> map, Expression<Func<TDestination, object>> selector)
        {
            map.ForMember(selector, config => config.Ignore());
            return map;
        }
    }
}