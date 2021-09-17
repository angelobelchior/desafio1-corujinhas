using Moq;
using Xunit;
using System;
using System.Threading.Tasks;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Commons.Tests.Base;
using RestauranteSaborDoBrasil.Commons.Tests.Builders;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Ingredientes.Handler;

namespace RestauranteSaborDoBrasil.Unit.Tests.Application.UseCases.Ingredientes
{
    public class CriarIngredienteUseCaseTest : BaseTest
    {
        private readonly Mock<IBaseRepository<Ingrediente>> _baseRepository;

        public CriarIngredienteUseCaseTest()
        {
            _baseRepository = new Mock<IBaseRepository<Ingrediente>>();
        }

        private CriarIngredienteUseCase InicializarUseCase()
            => new CriarIngredienteUseCase(_notifications, _unitOfWorkMock.Object, _baseRepository.Object, _mapper);

        [Theory]
        [InlineData("Ingrediente Test", true)]
        [InlineData("Ingrediente Test", false)]
        [InlineData(null, true)]
        public async Task CriarIngredienteSuccessfully(string descricao, bool isCommited)
        {
            #region Arrange
            var ingrediente = DomainModelBuilder.Ingrediente;
            var request = RequestBuilder.CriarIngredienteRequest;
            request.Descricao = descricao;

            _baseRepository.Setup(x => x.AddAsync(It.IsAny<Ingrediente>())).ReturnsAsync(ingrediente);
            _baseRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(ingrediente);
            _unitOfWorkMock.Setup(x => x.CommitAsync()).ReturnsAsync(isCommited);

            var useCase = InicializarUseCase();
            #endregion

            #region Act
            var result = await useCase.Handle(request, default);
            #endregion

            #region Assert
            if (!string.IsNullOrEmpty(descricao))
            {
                _baseRepository.Verify(x => x.AddAsync(It.IsAny<Ingrediente>()), Times.Once);
                _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Once);
                if (isCommited) Assert.False(_notifications.HasNotifications());
            }
            else
            {
                _baseRepository.Verify(x => x.AddAsync(It.IsAny<Ingrediente>()), Times.Never);
                _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Never);
                Assert.True(_notifications.HasNotifications());
            }
            #endregion
        }
    }
}
