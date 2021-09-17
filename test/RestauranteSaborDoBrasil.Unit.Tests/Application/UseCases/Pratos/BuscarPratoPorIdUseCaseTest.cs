using Moq;
using Xunit;
using System;
using System.Threading.Tasks;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Commons.Tests.Base;
using RestauranteSaborDoBrasil.Commons.Tests.Builders;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Handler;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Request;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;

namespace RestauranteSaborDoBrasil.Unit.Tests.Application.UseCases.Pratos
{
    public class BuscarPratoPorIdUseCaseTest : BaseTest
    {
        private readonly Mock<IBaseRepository<Prato>> _baseRepository;

        public BuscarPratoPorIdUseCaseTest()
        {
            _baseRepository = new Mock<IBaseRepository<Prato>>();
        }

        private BuscarPratoPorIdUseCase InicializarUseCase()
            => new(_notifications, _unitOfWorkMock.Object, _baseRepository.Object, _mapper);

        [Fact]
        public async Task BuscarPratoPorIdSuccessfully()
        {
            #region Arrange
            var prato = DomainModelBuilder.Prato;
            _baseRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(prato);
            var useCase = InicializarUseCase();
            #endregion

            #region Act
            var result = await useCase.Handle(new BuscarPratoRequest { Id = prato.Id }, default);
            #endregion

            #region Assert
            _baseRepository.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(prato.Id, result.Id);
            #endregion
        }
    }
}
