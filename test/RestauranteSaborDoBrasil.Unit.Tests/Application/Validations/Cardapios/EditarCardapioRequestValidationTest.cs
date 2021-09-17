using Xunit;
using RestauranteSaborDoBrasil.Commons.Tests.Base;
using RestauranteSaborDoBrasil.Commons.Tests.Builders;
using RestauranteSaborDoBrasil.Application.Validations.Cardapios;

namespace RestauranteSaborDoBrasil.Unit.Tests.Application.Validations.Cardapios
{
    public class EditarCardapioRequestValidationTest : BaseTest
    {
        private readonly EditarCardapioRequestValidation _validator;

        public EditarCardapioRequestValidationTest()
        {
            _validator = new EditarCardapioRequestValidation();
        }

        [Fact]
        public void ValidateIfHasDiaSemana()
        {
            #region Arrange
            var request = RequestBuilder.EditarCardapioRequest;
            request.AtribuirId(System.Guid.Empty);
            #endregion

            #region Act
            var result = _validator.Validate(request);
            #endregion

            #region Assert
            ErrorsContains(result, "*'Id' must not be empty.*");
            #endregion
        }
    }
}
