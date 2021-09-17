using Moq;
using Xunit;
using System;
using System.Linq;
using System.Threading.Tasks;
using RestauranteSaborDoBrasil.Domain.Enums;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Commons.Tests.Base;
using RestauranteSaborDoBrasil.Commons.Tests.Builders;
using RestauranteSaborDoBrasil.Commons.Tests.Extensions;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Handler;

namespace RestauranteSaborDoBrasil.Unit.Tests.Application.UseCases.Cardapios
{
    public class EditarCardapioUseCaseTest : BaseTest
    {
        private readonly Mock<IBaseRepository<Cardapio>> _baseRepository;
        private readonly Mock<IBaseRepository<PratoCardapio>> _pratoCardapioRepository;

        public EditarCardapioUseCaseTest()
        {
            _baseRepository = new Mock<IBaseRepository<Cardapio>>();
            _pratoCardapioRepository = new Mock<IBaseRepository<PratoCardapio>>();
        }

        private EditarCardapioUseCase InicializarUseCase()
            => new(_notifications, _unitOfWorkMock.Object, _baseRepository.Object, _pratoCardapioRepository.Object, _mapper);
        

        [Theory]
        [InlineData(1, true)]
        public async Task EditarCardapioSuccessfully(int diaSemana, bool isCommited)
        {
            #region Arrange
            var cardapio = DomainModelBuilder.Cardapio;
            var request = RequestBuilder.EditarCardapioRequest;
            var prato = cardapio.Pratos.First();
            prato.CardapioId = cardapio.Id;
            request.AtribuirId(cardapio.Id);
            request.DiaSemana = (DiaSemana)diaSemana;

            _baseRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(cardapio);
            _pratoCardapioRepository.SetupGet(x => x.GetAllQuery).Returns(EFCoreExtension.GetDbSet(EFCoreExtension.ToQueryable(prato)).Object);
            _pratoCardapioRepository.SetupGet(x => x.GetAllQueryNoTracking).Returns(EFCoreExtension.GetDbSet(EFCoreExtension.ToQueryable(cardapio.Pratos.First())).Object);
            _unitOfWorkMock.Setup(x => x.CommitAsync()).ReturnsAsync(isCommited);

            var useCase = InicializarUseCase();
            #endregion

            #region Act
            await useCase.Handle(request, default);
            #endregion

            #region Assert
            if (diaSemana == 1)
            {
                _pratoCardapioRepository.Verify(x => x.GetAllQueryNoTracking, Times.Exactly(request.Pratos.Count));
                _pratoCardapioRepository.Verify(x => x.AddAsync(It.IsAny<PratoCardapio>()), Times.Exactly(request.Pratos.Count));
                _pratoCardapioRepository.Verify(x => x.Delete(It.IsAny<PratoCardapio>()), Times.Once);

                _baseRepository.Verify(x => x.Update(It.IsAny<Cardapio>()), Times.Once);
                _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Once);
                if(isCommited) Assert.False(_notifications.HasNotifications());
            }
            else
                Assert.True(_notifications.HasNotifications());
            #endregion
        }
    }
}
