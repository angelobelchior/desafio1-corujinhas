using Moq;
using Xunit;
using System;
using MediatR;
using System.Threading.Tasks;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Commons.Tests.Base;
using RestauranteSaborDoBrasil.Commons.Tests.Builders;
using RestauranteSaborDoBrasil.Application.UseCases.Pratos.Handler;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Receitas.Request;

namespace RestauranteSaborDoBrasil.Unit.Tests.Application.UseCases.Pratos
{
    public class EditarPratoUseCaseTest : BaseTest
    {
        private readonly Mock<IBaseRepository<Prato>> _baseRepository;

        public EditarPratoUseCaseTest()
        {
            _baseRepository = new Mock<IBaseRepository<Prato>>();
        }

        private EditarPratoUseCase InicializarUseCase()
            => new(_notifications, _unitOfWorkMock.Object, _baseRepository.Object, _mapper, _mediator.Object);

        [Theory]
        [InlineData("Prato Test", true, true, true)]
        [InlineData("Prato Test", false, true, true)]
        [InlineData("Prato Test", false, true, false)]
        [InlineData(null, true, true, true)]
        public async Task EditarPratoSuccessfully(string nome, bool hasExist, bool isCommited, bool successSaveReceita)
        {
            #region Arrange
            var prato = DomainModelBuilder.Prato;
            var request = RequestBuilder.EditarPratoRequest;
            request.Nome = nome;
            request.AtribuirId(prato.Id);

            _mediator.Setup(x => x.Send(It.IsAny<EditarReceitaRequest>(), default)).ReturnsAsync(successSaveReceita);
            _unitOfWorkMock.Setup(x => x.CommitAsync()).ReturnsAsync(isCommited);

            if (hasExist)
                _baseRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(prato);

            var useCase = InicializarUseCase();
            #endregion

            #region Act
            var result = await useCase.Handle(request, default);
            #endregion

            #region Assert
            if (!string.IsNullOrEmpty(nome))
            {
                _mediator.Verify(x => x.Send(It.IsAny<EditarReceitaRequest>(), default), Times.Once);

                if (hasExist && successSaveReceita)
                {
                    _baseRepository.Verify(x => x.GetByIdAsync(It.IsAny<Guid>()), Times.Exactly(2));
                    _baseRepository.Verify(x => x.Update(It.IsAny<Prato>()), Times.Once);
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
