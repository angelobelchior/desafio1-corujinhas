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
    public class EditarIngredienteUseCaseTest : BaseTest
    {
        private readonly Mock<IBaseRepository<Ingrediente>> _baseRepository;

        public EditarIngredienteUseCaseTest()
        {
            _baseRepository = new Mock<IBaseRepository<Ingrediente>>();
        }

        private EditarIngredienteUseCase InicializarUseCase()
            => new(_notifications, _unitOfWorkMock.Object, _baseRepository.Object, _mapper);

        [Theory]
        [InlineData("Ingrediente Test", true, true)]
        [InlineData("Ingrediente Test", false, true)]
        [InlineData(null, true, true)]
        public async Task EditarIngredienteSuccessfully(string descricao, bool hasExist, bool isCommited)
        {
            #region Arrange
            var ingrediente = DomainModelBuilder.Ingrediente;
            var request = RequestBuilder.EditarIngredienteRequest;
            request.Descricao = descricao;
            request.AtribuirId(ingrediente.Id);

            _unitOfWorkMock.Setup(x => x.CommitAsync()).ReturnsAsync(isCommited);
            if (hasExist)
                _baseRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(ingrediente);
            
            var useCase = InicializarUseCase();
            #endregion

            #region Act
            var result = await useCase.Handle(request, default);
            #endregion

            #region Assert
            if (!string.IsNullOrEmpty(descricao))
            {
                if (hasExist)
                {
                    _baseRepository.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Exactly(2));
                    _baseRepository.Verify(x => x.Update(It.IsAny<Ingrediente>()), Times.Once);
                    _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Once);
                    if (isCommited) Assert.False(_notifications.HasNotifications());
                }
                else
                    Assert.True(_notifications.HasNotifications());
            }
            else
                Assert.True(_notifications.HasNotifications());
            #endregion
        }
    }
}
