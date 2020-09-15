using FluentValidation;
using SimpleCalculator.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.API.Models.Requests
{
    public class CalculationRequest
    {
        public decimal Operand1 { get; set; }
        public decimal Operand2 { get; set; }
        public OperationType OperationType { get; set; }
    }

    //fluent validation validatior
    public class CalculationRequestValidator : AbstractValidator<CalculationRequest>
    {
        public CalculationRequestValidator()
        {
            RuleFor(model => model.Operand2).NotEqual(0).When(model => model.OperationType == OperationType.Division);
            RuleFor(model => model.OperationType).IsInEnum();
        }
    }


}
