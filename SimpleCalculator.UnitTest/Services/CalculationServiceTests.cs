using AutoFixture.Xunit2;
using Moq;
using NFluent;
using SimpleCalculator.API.Enums;
using SimpleCalculator.API.Extensions;
using SimpleCalculator.API.Models.Dtos;
using SimpleCalculator.API.Services.Calculation;
using SimpleCalculator.API.Services.Calculation.Strategies;
using SimpleCalculator.API.Services.Calculation.Strategies.Factory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xunit;

namespace SimpleCalculator.UnitTest.Services
{
    public class CalculationServiceTests
    {
        private readonly ICalculationService _sut;
        private readonly Mock<ICalculationStrategyFactory> _calculationStrategyFactoryMock = new Mock<ICalculationStrategyFactory>();

        public CalculationServiceTests()
        {
            _sut = new CalculationService(_calculationStrategyFactoryMock.Object);
        }

        [Theory]
        [InlineData(3, 2, 5)]
        [InlineData(0, 0, 0)]
        [InlineData(-1.33, 2, 0.67)]
        public void CalculateResult_Addition_Success_Theory(decimal operand1, decimal operand2, decimal expected)
        {
            // arrange
            CalculationDto calculationDto = new CalculationDto
            {
                Operand1 = operand1,
                Operand2 = operand2,
                OperationType = OperationType.Addition
            };

            _calculationStrategyFactoryMock.Setup(x => x.GetCalculationStrategy(calculationDto)).Returns(() => new AdditionStrategy(calculationDto.ToCalculationInput()));
            // act
            var result = _sut.CalculateResult(calculationDto);

            // assert
            Check.That(result).Equals(expected);
        }

        [Theory]
        [InlineData(3, 2, 1.5)]
        [InlineData(0, 2, 0)]
        [InlineData(-1, -5, 0.2)]
        public void CalculateResult_Division_Success_Theory(decimal operand1, decimal operand2, decimal expected)
        {
            // arrange
            CalculationDto calculationDto = new CalculationDto
            {
                Operand1 = operand1,
                Operand2 = operand2,
                OperationType = OperationType.Division
            };

            _calculationStrategyFactoryMock.Setup(x => x.GetCalculationStrategy(calculationDto)).Returns(() => new DivisionStrategy(calculationDto.ToCalculationInput()));
            // act
            var result = _sut.CalculateResult(calculationDto);

            // assert
            Check.That(result).Equals(expected);
        }

        [Theory]
        [InlineData(3, 0)]
        [InlineData(0, 0)]
        [InlineData(-1, 0)]
        public void CalculateResult_Division_DivisorBeZero_ThrowException_Theory(decimal operand1, decimal operand2)
        {
            // arrange
            CalculationDto calculationDto = new CalculationDto
            {
                Operand1 = operand1,
                Operand2 = operand2,
                OperationType = OperationType.Division
            };

            _calculationStrategyFactoryMock.Setup(x => x.GetCalculationStrategy(calculationDto)).Returns(() => new DivisionStrategy(calculationDto.ToCalculationInput()));
            // act
            // assert
            Check.ThatCode(() => _sut.CalculateResult(calculationDto)).Throws<DivideByZeroException>();
        }

        [Theory]
        [InlineData((OperationType)(-1))]
        [InlineData((OperationType)6)]
        [InlineData((OperationType)1.5)]
        public void CalculateResult_InvalidEnumValue_ThrowException_Theory(OperationType operationType)
        {
            // arrange
            CalculationDto calculationDto = new CalculationDto
            {
                Operand1 = 10,
                Operand2 = 5,
                OperationType = operationType
            };

            // act
            // assert
            Check.ThatCode(() => _sut.CalculateResult(calculationDto)).Throws<InvalidEnumArgumentException>();
        }

    }
}
