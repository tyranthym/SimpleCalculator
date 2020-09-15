using SimpleCalculator.API.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.API.Services.Calculation.Strategies
{
    public interface ICalculationStrategy
    {
        CalculationInput CalculationInput { get; }
        decimal CalculateResult();
    }
}
