using SimpleCalculator.API.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.API.Services.Calculation.Strategies
{
    public abstract class CalculationStrategyBase : ICalculationStrategy
    {
        public CalculationInput CalculationInput { get; }      

        public CalculationStrategyBase(CalculationInput calculationInput)
        {
            CalculationInput = calculationInput;
        }

        public abstract decimal CalculateResult();

    }
}
