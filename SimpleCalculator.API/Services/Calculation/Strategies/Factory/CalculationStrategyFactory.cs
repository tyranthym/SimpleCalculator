using SimpleCalculator.API.Enums;
using SimpleCalculator.API.Extensions;
using SimpleCalculator.API.Models.Dtos;


namespace SimpleCalculator.API.Services.Calculation.Strategies.Factory
{
    public class CalculationStrategyFactory : ICalculationStrategyFactory
    {
        public ICalculationStrategy GetCalculationStrategy(CalculationDto calculationDto)
        {
            //map to strategy input
            var calculationInput = calculationDto.ToCalculationInput();

            return calculationDto.OperationType switch
            {
                OperationType.Addition => new AdditionStrategy(calculationInput),
                OperationType.Subtraction => new SubtractionStrategy(calculationInput),
                OperationType.Multiplication => new MultiplicationStrategy(calculationInput),
                OperationType.Division => new DivisionStrategy(calculationInput),
                _ => null,
            };
        }
    }
}
