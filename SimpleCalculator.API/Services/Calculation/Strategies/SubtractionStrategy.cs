using SimpleCalculator.API.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.API.Services.Calculation.Strategies
{
    public class SubtractionStrategy : CalculationStrategyBase
    {
        public SubtractionStrategy(CalculationInput calculationInput) : base(calculationInput) { }

        public override decimal CalculateResult()
        {
            return decimal.Subtract(CalculationInput.Operand1, CalculationInput.Operand2);
        }
    }
}
