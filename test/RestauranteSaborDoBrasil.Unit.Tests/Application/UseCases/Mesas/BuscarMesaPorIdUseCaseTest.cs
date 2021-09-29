using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Mesas.Handler;
using RestauranteSaborDoBrasil.Application.UseCases.Mesas.Request;
using RestauranteSaborDoBrasil.Commons.Tests.Builders;
using RestauranteSaborDoBrasil.Commons.Tests.Base;
using RestauranteSaborDoBrasil.Domain.Models;
using System.Threading.Tasks;
using System;
using Xunit;
using Moq;

namespace RestauranteSaborDoBrasil.Unit.Tests.Application.UseCases.Mesas
{
    public class BuscarMesaPorIdUseCaseTest : BaseTest
    {
        private readonly Mock<IBaseRepository<Mesa>> _baseRepository;

        public BuscarMesaPorIdUseCaseTest()
        {
            _baseRepository = new Mock<IBaseRepository<Mesa>>();
        }

        private BuscarMesaPorIdUseCase InicializarUseCase()
            => new(_notifications, _unitOfWorkMock.Object, _baseRepository.Object, _mapper);

        [Fact]
        public async Task BuscarMesaPorIdSuccessfully()
        {
            #region Arrange
            var mesa = DomainModelBuilder.Mesa;
            _baseRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(mesa);
            var useCase = InicializarUseCase();
            #endregion

            #region Act
            var result = await useCase.Handle(new BuscarMesaPorIdRequest { Id = mesa.Id }, default);
            #endregion

            #region Assert
            _baseRepository.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(mesa.Id, result.Id);
            #endregion
        }
    }
}
