using Moq;
using Xunit;
using System.Threading.Tasks;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Commons.Tests.Base;
using RestauranteSaborDoBrasil.Commons.Tests.Builders;
using RestauranteSaborDoBrasil.Commons.Tests.Extensions;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Handler;

namespace RestauranteSaborDoBrasil.Unit.Tests.Application.UseCases.Ingredientes
{
    public class ListarIngredienteUseCaseTest : BaseTest
    {
        private readonly Mock<IBaseRepository<Ingrediente>> _baseRepository;

        public ListarIngredienteUseCaseTest()
        {
            _baseRepository = new Mock<IBaseRepository<Ingrediente>>();
        }

        private ListarIngredienteUseCase InicializarUseCase()
            => new(_notifications, _unitOfWorkMock.Object, _baseRepository.Object, _mapper);

        [Fact]
        public async Task ListarIngredientesSuccessfully()
        {
            #region Arrange
            var ingrediente = DomainModelBuilder.Ingrediente;
            _baseRepository.SetupGet(x => x.GetAllQuery).Returns(EFCoreExtension.GetDbSet(EFCoreExtension.ToQueryable(ingrediente)).Object);
            var useCase = InicializarUseCase();
            #endregion

            #region Act
            var result = await useCase.Handle(default, default);
            #endregion

            #region Assert
            _baseRepository.Verify(x => x.GetAllQuery, Times.Once);
            Assert.NotEmpty(result);
            #endregion
        }
    }
}
