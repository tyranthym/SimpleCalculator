using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.API.Models.Dtos
{
    public class CalculationInput
    {
        public decimal Operand1 { get; set; }
        public decimal Operand2 { get; set; }
    }
}
