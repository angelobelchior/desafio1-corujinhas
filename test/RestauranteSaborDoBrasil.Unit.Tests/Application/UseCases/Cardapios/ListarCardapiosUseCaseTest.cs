using Moq;
using Xunit;
using System.Threading.Tasks;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Commons.Tests.Base;
using RestauranteSaborDoBrasil.Commons.Tests.Builders;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Handler;
using RestauranteSaborDoBrasil.Commons.Tests.Extensions;

namespace RestauranteSaborDoBrasil.Unit.Tests.Application.UseCases.Cardapios
{
    public class ListarCardapiosUseCaseTest : BaseTest
    {
        private readonly Mock<IBaseRepository<Cardapio>> _baseRepository;

        public ListarCardapiosUseCaseTest()
        {
            _baseRepository = new Mock<IBaseRepository<Cardapio>>();
        }

        private ListarCardapiosUseCase InicializarUseCase()
            => new(_notifications, _unitOfWorkMock.Object, _baseRepository.Object, _mapper);

        [Fact]
        public async Task ListarCardapiosSuccessfully()
        {
            #region Arrange
            var cardapio = DomainModelBuilder.Cardapio;
            _baseRepository.SetupGet(x => x.GetAllQuery).Returns(EFCoreExtension.GetDbSet(EFCoreExtension.ToQueryable(cardapio)).Object);
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
