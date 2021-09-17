using Moq;
using Xunit;
using System;
using System.Threading.Tasks;
using RestauranteSaborDoBrasil.Domain.Enums;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Commons.Tests.Base;
using RestauranteSaborDoBrasil.Commons.Tests.Builders;
using RestauranteSaborDoBrasil.Commons.Tests.Extensions;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Handler;

namespace RestauranteSaborDoBrasil.Unit.Tests.Application.UseCases.Cardapios
{
    public class BuscarCardapioPorDiaUseCaseTest : BaseTest
    {
        private readonly Mock<IBaseRepository<Cardapio>> _baseRepository;

        public BuscarCardapioPorDiaUseCaseTest()
        {
            _baseRepository = new Mock<IBaseRepository<Cardapio>>();
        }

        private BuscarCardapioPorDiaUseCase InicializarUseCase()
            => new(_notifications, _unitOfWorkMock.Object, _baseRepository.Object, _mapper);

        [Fact]
        public async Task BuscarCardapioPorDiaSuccessfully()
        {
            #region Arrange
            var cardapio = DomainModelBuilder.Cardapio;
            cardapio.DiaSemana = (DiaSemana)DateTime.UtcNow.DayOfWeek;
            _baseRepository.SetupGet(x => x.GetAllQuery).Returns(EFCoreExtension.GetDbSet(EFCoreExtension.ToQueryable(cardapio)).Object);
            var useCase = InicializarUseCase();
            #endregion

            #region Act
            var result = await useCase.Handle(default, default);
            #endregion

            #region Assert
            _baseRepository.Verify(x => x.GetAllQuery, Times.Once);
            Assert.NotNull(result);
            #endregion
        }
    }
}
