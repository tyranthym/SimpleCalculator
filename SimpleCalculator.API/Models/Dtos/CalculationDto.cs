
using SimpleCalculator.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.API.Models.Dtos
{
    public class CalculationDto
    {
        public decimal Operand1 { get; set; }
        public decimal Operand2 { get; set; }
        public OperationType OperationType { get; set; }        
    }
}
