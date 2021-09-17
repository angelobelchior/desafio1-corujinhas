using Moq;
using Xunit;
using System.Threading.Tasks;
using RestauranteSaborDoBrasil.Domain.Models;
using RestauranteSaborDoBrasil.Commons.Tests.Base;
using RestauranteSaborDoBrasil.Domain.Interfaces.Repositories.Base;
using RestauranteSaborDoBrasil.Application.UseCases.Receitas.Handler;
using RestauranteSaborDoBrasil.Commons.Tests.Builders;
using RestauranteSaborDoBrasil.Commons.Tests.Extensions;

namespace RestauranteSaborDoBrasil.Unit.Tests.Application.UseCases.Receitas
{
    public class EditarReceitaUseCaseTest : BaseTest
    {
        private readonly Mock<IBaseRepository<Receita>> _baseRepository;

        public EditarReceitaUseCaseTest()
        {
            _baseRepository = new Mock<IBaseRepository<Receita>>();
        }

        private EditarReceitaUseCase InicializarUseCase()
            => new(_notifications, _unitOfWorkMock.Object, _baseRepository.Object, _mapper);

        [Fact]
        public async Task EditarReceitaSuccessfully()
        {
            #region Arrange
            var receita = DomainModelBuilder.Receita;
            var request = RequestBuilder.EditarReceitaRequest;
            request.PratoId = receita.PratoId;

            _baseRepository.SetupGet(x => x.GetAllQuery).Returns(EFCoreExtension.GetDbSet(EFCoreExtension.ToQueryable(receita)).Object);
            _baseRepository.SetupGet(x => x.GetAllQueryNoTracking).Returns(EFCoreExtension.GetDbSet(EFCoreExtension.ToQueryable(receita)).Object);

            var useCase = InicializarUseCase();
            #endregion

            #region Act
            var result = await useCase.Handle(request, default);
            #endregion

            #region Assert
            _baseRepository.Verify(x => x.GetAllQuery, Times.Once);
            _baseRepository.Verify(x => x.GetAllQueryNoTracking, Times.Exactly(request.Ingredientes.Count));
            _baseRepository.Verify(x => x.AddAsync(It.IsAny<Receita>()), Times.Exactly(request.Ingredientes.Count));
            _baseRepository.Verify(x => x.Delete(It.IsAny<Receita>()), Times.Once);
            _unitOfWorkMock.Verify(x => x.CommitAsync(), Times.Once);
            #endregion
        }
    }
}
