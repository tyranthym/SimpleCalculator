using AutoFixture.Xunit2;
using NFluent;
using SimpleCalculator.API.Extensions;
using SimpleCalculator.API.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SimpleCalculator.UnitTest.Extensions
{
    public class CalculationDtoExtensionTests
    {
		[Theory, AutoData]
		public void ToCalculationInput_ConvertsDboToInput_WhenCalled(CalculationDto calculationDto)
		{
			// act
			var calculationInput = calculationDto.ToCalculationInput();

			// assert
			Check.That(calculationInput.Operand1).Equals(calculationDto.Operand1);
			Check.That(calculationInput.Operand2).Equals(calculationDto.Operand2);
		}
	}
}
