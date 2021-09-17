using Moq;
using Xunit;
using System;
using System.Threading.Tasks;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Commons.Tests.Base;
using RestauranteSaborDoBrasil.Commons.Tests.Builders;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Handler;
using RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Request;

namespace RestauranteSaborDoBrasil.Unit.Tests.Application.UseCases.Ingredientes
{
    public class BuscarIngredientePorIdUseCaseTest : BaseTest
    {
        private readonly Mock<IBaseRepository<Ingrediente>> _baseRepository;

        public BuscarIngredientePorIdUseCaseTest()
        {
            _baseRepository = new Mock<IBaseRepository<Ingrediente>>();
        }

        private BuscarIngredientePorIdUseCase InicializarUseCase()
            => new(_notifications, _unitOfWorkMock.Object, _baseRepository.Object, _mapper);

        [Fact]
        public async Task BuscarIngredientePorIdSuccessfully()
        {
            #region Arrange
            var ingrediente = DomainModelBuilder.Ingrediente;
            _baseRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(ingrediente);
            var useCase = InicializarUseCase();
            #endregion

            #region Act
            var result = await useCase.Handle(new BuscarIngredienteRequest { Id = ingrediente.Id }, default);
            #endregion

            #region Assert
            _baseRepository.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(ingrediente.Id, result.Id);
            #endregion
        }
    }
}
