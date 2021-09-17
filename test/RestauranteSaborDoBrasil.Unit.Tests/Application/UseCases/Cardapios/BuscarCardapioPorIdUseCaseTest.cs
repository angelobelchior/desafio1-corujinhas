using Moq;
using Xunit;
using System;
using System.Threading.Tasks;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Commons.Tests.Base;
using RestauranteSaborDoBrasil.Commons.Tests.Builders;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Handler;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Request;

namespace RestauranteSaborDoBrasil.Unit.Tests.Application.UseCases.Cardapios
{
    public class BuscarCardapioPorIdUseCaseTest : BaseTest
    {
        private readonly Mock<IBaseRepository<Cardapio>> _baseRepository;

        public BuscarCardapioPorIdUseCaseTest()
        {
            _baseRepository = new Mock<IBaseRepository<Cardapio>>();
        }

        private BuscarCardapioPorIdUseCase InicializarUseCase()
            => new(_notifications, _unitOfWorkMock.Object, _baseRepository.Object, _mapper);

        [Fact]
        public async Task BuscarCardapioPorIdSuccessfully()
        {
            #region Arrange
            var cardapio = DomainModelBuilder.Cardapio;
            _baseRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(cardapio);
            var useCase = InicializarUseCase();
            #endregion

            #region Act
            var result = await useCase.Handle(new BuscarCardapioRequest { Id = cardapio.Id }, default);
            #endregion

            #region Assert
            _baseRepository.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(cardapio.Id, result.Id);
            #endregion
        }
    }
}
