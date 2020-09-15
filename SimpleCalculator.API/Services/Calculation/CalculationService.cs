using SimpleCalculator.API.Models.Dtos;
using SimpleCalculator.API.Services.Calculation.Strategies.Factory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.API.Services.Calculation
{
    public class CalculationService : ICalculationService
    {
        private readonly ICalculationStrategyFactory _calculationStrategyFactory;

        public CalculationService(ICalculationStrategyFactory calculationStrategyFactory)
        {
            this._calculationStrategyFactory = calculationStrategyFactory;           
        }

        public decimal CalculateResult(CalculationDto calculationDto)
        {
            var calculationStrategy = _calculationStrategyFactory.GetCalculationStrategy(calculationDto);
            if (calculationStrategy == null)
            {
                throw new InvalidEnumArgumentException("Operation type is not valid");
            }
            return calculationStrategy.CalculateResult();
        }
    }
}
