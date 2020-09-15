using SimpleCalculator.API.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.API.Extensions
{
    public static class CalculationDtoExtensions
    {
        public static CalculationInput ToCalculationInput(this CalculationDto dto)
        {
            var calculationInput = new CalculationInput
            {
                Operand1 = dto.Operand1,
                Operand2 = dto.Operand2
            };
            return calculationInput;
        }
    }
}
