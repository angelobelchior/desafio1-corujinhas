using Moq;
using Xunit;
using System;
using System.Threading.Tasks;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Commons.Tests.Base;
using RestauranteSaborDoBrasil.Commons.Tests.Builders;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Handler;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;

namespace RestauranteSaborDoBrasil.Unit.Tests.Application.UseCases.Pratos
{
    public class CriarPratoUseCaseTest : BaseTest
    {
        private readonly Mock<IBaseRepository<Prato>> _baseRepository;

        public CriarPratoUseCaseTest()
        {
            _baseRepository = new Mock<IBaseRepository<Prato>>();
        }

        private CriarPratoUseCase InicializarUseCase()
            => new(_notifications, _unitOfWorkMock.Object, _baseRepository.Object, _mapper);

        [Theory]
        [InlineData("Prato Test", true)]
        [InlineData("Prato Test", false)]
        [InlineData(null, true)]
        public async Task CriarCardapioSuccessfully(string nome, bool isCommited)
        {
            #region Arrange
            var prato = DomainModelBuilder.Prato;
            var request = RequestBuilder.CriarPratoRequest;
            request.Nome = nome;

            _baseRepository.Setup(x => x.AddAsync(It.IsAny<Prato>())).ReturnsAsync(prato);
            _baseRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(prato);

            _unitOfWorkMock.Setup(x => x.CommitAsync()).ReturnsAsync(isCommited);
            var useCase = InicializarUseCase();
            #endregion

            #region Act
            await useCase.Handle(request, default);
            #endregion

            #region Assert
            if (!string.IsNullOrEmpty(nome))
            {
                _baseRepository.Verify(x => x.AddAsync(It.IsAny<Prato>()), Times.Once);
                _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Once);
                if (isCommited) Assert.False(_notifications.HasNotifications());
            }
            else
            {
                _baseRepository.Verify(x => x.AddAsync(It.IsAny<Prato>()), Times.Never);
                _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Never);
                Assert.True(_notifications.HasNotifications());
            }
            #endregion
        }
    }
}
