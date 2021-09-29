using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Mesas.Handler;
using RestauranteSaborDoBrasil.Commons.Tests.Extensions;
using RestauranteSaborDoBrasil.Commons.Tests.Builders;
using RestauranteSaborDoBrasil.Commons.Tests.Base;
using RestauranteSaborDoBrasil.Domain.Models;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace RestauranteSaborDoBrasil.Unit.Tests.Application.UseCases.Mesas
{
    public class ListarMesaUseCaseTest : BaseTest
    {
        private readonly Mock<IBaseRepository<Mesa>> _baseRepository;

        public ListarMesaUseCaseTest()
        {
            _baseRepository = new Mock<IBaseRepository<Mesa>>();
        }

        private ListarMesaUseCase InicializarUseCase()
            => new(_notifications, _unitOfWorkMock.Object, _baseRepository.Object, _mapper);

        [Fact]
        public async Task ListarMesasSuccessfully()
        {
            #region Arrange
            var mesa = DomainModelBuilder.Mesa;
            _baseRepository.SetupGet(x => x.GetAllQuery).Returns(EFCoreExtension.GetDbSet(EFCoreExtension.ToQueryable(mesa)).Object);
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
