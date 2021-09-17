using Moq;
using Xunit;
using System.Threading.Tasks;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Commons.Tests.Base;
using RestauranteSaborDoBrasil.Commons.Tests.Builders;
using RestauranteSaborDoBrasil.Commons.Tests.Extensions;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Handler;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;

namespace RestauranteSaborDoBrasil.Unit.Tests.Application.UseCases.Pratos
{
    public class ListarPratosUseCaseTest : BaseTest
    {
        private readonly Mock<IBaseRepository<Prato>> _baseRepository;

        public ListarPratosUseCaseTest()
        {
            _baseRepository = new Mock<IBaseRepository<Prato>>();
        }

        private ListarPratosUseCase InicializarUseCase()
            => new(_notifications, _unitOfWorkMock.Object, _baseRepository.Object, _mapper);

        [Fact]
        public async Task ListarCardapiosSuccessfully()
        {
            #region Arrange
            var prato = DomainModelBuilder.Prato;
            _baseRepository.SetupGet(x => x.GetAllQuery).Returns(EFCoreExtension.GetDbSet(EFCoreExtension.ToQueryable(prato)).Object);
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
