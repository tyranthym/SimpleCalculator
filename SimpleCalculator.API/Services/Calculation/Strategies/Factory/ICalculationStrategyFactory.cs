using SimpleCalculator.API.Enums;
using SimpleCalculator.API.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.API.Services.Calculation.Strategies.Factory
{
    public interface ICalculationStrategyFactory
    {
        ICalculationStrategy GetCalculationStrategy(CalculationDto calculationDto);
    }
}
