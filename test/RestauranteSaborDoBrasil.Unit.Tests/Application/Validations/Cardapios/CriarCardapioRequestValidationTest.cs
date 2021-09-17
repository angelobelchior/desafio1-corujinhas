using Xunit;
using System.Collections.Generic;
using RestauranteSaborDoBrasil.Domain.Enums;
using RestauranteSaborDoBrasil.Commons.Tests.Base;
using RestauranteSaborDoBrasil.Commons.Tests.Builders;
using RestauranteSaborDoBrasil.Application.Validations.Cardapios;
using RestauranteSaborDoBrasil.Application.UseCases.Cardapios.Request;
using RestauranteSaborDoBrasil.Application;

namespace RestauranteSaborDoBrasil.Unit.Tests.Application.Validations.Cardapios
{
    public class CriarCardapioRequestValidationTest : BaseTest
    {
        private readonly CriarCardapioRequestValidation _validator;

        public CriarCardapioRequestValidationTest()
        {
            _validator = new CriarCardapioRequestValidation();
        }

        [Fact]
        public void ValidateIfHasDiaSemana()
        {
            #region Arrange
            var request = RequestBuilder.CriarCardapioRequest;
            request.DiaSemana = (DiaSemana)999;
            #endregion

            #region Act
            var result = _validator.Validate(request);
            #endregion

            #region Assert
            ErrorsContains(result, $"*{ApplicationResources.DiaSemanaIsNotValid}*");
            #endregion
        }

        [Fact]
        public void ValidateIfHasPratos()
        {
            #region Arrange
            var request = RequestBuilder.CriarCardapioRequest;
            request.Pratos = new List<CardapioRequest.PratoRequest>();
            #endregion

            #region Act
            var result = _validator.Validate(request);
            #endregion

            #region Assert
            ErrorsContains(result, $"*{ApplicationResources.PratosIsNotValid}*");
            #endregion
        }
    }
}
