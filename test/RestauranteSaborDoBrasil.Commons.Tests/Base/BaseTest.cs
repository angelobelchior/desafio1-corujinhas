using AutoMapper;
using Bogus;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using RestauranteSaborDoBrasil.Application.AutoMapper;
using RestauranteSaborDoBrasil.Domain.Core.Interfaces;
using RestauranteSaborDoBrasil.Domain.Core.Notifications;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories;
using System.Linq;

namespace RestauranteSaborDoBrasil.Commons.Tests.Base
{
    public class BaseTest
    {
        protected IHandler<DomainNotification> _notifications;
        protected Mock<IUnitOfWork> _unitOfWorkMock;
        protected Mock<IMediator> _mediator;
        protected IMapper _mapper;
        protected Faker _faker;
        protected Mock<ILogger<DomainNotificationHandler>> _logger;

        public BaseTest()
        {
            _faker = new Faker();
            _logger = new Mock<ILogger<DomainNotificationHandler>>();
            _notifications = new DomainNotificationHandler(_logger.Object);
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _mediator = new Mock<IMediator>();

            var mapperFactory = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullDestinationValues = true;
                cfg.AllowNullCollections = true;

                cfg.DisableConstructorMapping();

                cfg.ForAllMaps
                (
                    (mapType, mapperExpression) =>
                    {
                        mapperExpression.MaxDepth(3);
                    }
                );

                cfg.AddProfile(new DomainToResponseMappingProfile());
                cfg.AddProfile(new RequestToDomainMappingProfile());
            });

            _mapper = mapperFactory.CreateMapper();
        }

        protected static void ErrorsContains(FluentValidation.Results.ValidationResult result, string wildcardMessage)
        {
            result.Errors.Select(x => x.ErrorMessage).Should()
                            .ContainMatch(wildcardMessage);
        }
    }
}

