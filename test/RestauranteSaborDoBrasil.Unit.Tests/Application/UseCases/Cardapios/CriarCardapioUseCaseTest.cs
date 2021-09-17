using Moq;
using Xunit;
using System;
using System.Threading.Tasks;
using RestauranteSaborDoBrasil.Domain.Enums;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Commons.Tests.Base;
using RestauranteSaborDoBrasil.Commons.Tests.Builders;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Handler;

namespace RestauranteSaborDoBrasil.Unit.Tests.Application.UseCases.Cardapios
{
    public class CriarCardapioUseCaseTest : BaseTest
    {
        private readonly Mock<IBaseRepository<Cardapio>> _baseRepository;

        public CriarCardapioUseCaseTest()
        {
            _baseRepository = new Mock<IBaseRepository<Cardapio>>();
        }

        private CriarCardapioUseCase InicializarUseCase()
            => new(_notifications, _unitOfWorkMock.Object, _baseRepository.Object, _mapper);

        [Theory]
        [InlineData(1, true)]
        [InlineData(1, false)]
        [InlineData(999, true)]
        public async Task CriarCardapioSuccessfully(int diaSemana, bool isCommited)
        {
            #region Arrange
            var cardapio = DomainModelBuilder.Cardapio;
            var request = RequestBuilder.CriarCardapioRequest;
            request.DiaSemana = (DiaSemana)diaSemana;
            _baseRepository.Setup(x => x.AddAsync(It.IsAny<Cardapio>())).ReturnsAsync(cardapio);
            _baseRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(cardapio);
            
            _unitOfWorkMock.Setup(x => x.CommitAsync()).ReturnsAsync(isCommited);
            var useCase = InicializarUseCase();
            #endregion

            #region Act
            await useCase.Handle(request, default);
            #endregion

            #region Assert
            if(diaSemana == 1)
            {
                _baseRepository.Verify(x => x.AddAsync(It.IsAny<Cardapio>()), Times.Once);
                _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Once);
                if(isCommited) Assert.False(_notifications.HasNotifications());
            }
            else
            {
                _baseRepository.Verify(x => x.AddAsync(It.IsAny<Cardapio>()), Times.Never);
                _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Never);
                Assert.True(_notifications.HasNotifications());
            }
            #endregion
        }
    }
}
