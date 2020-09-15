using Microsoft.OpenApi.Extensions;
using SimpleCalculator.API.Extensions;
using SimpleCalculator.API.Models.Dtos;
using SimpleCalculator.API.Models.Requests;
using SimpleCalculator.API.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.API.ModelMappers
{
    public class CalculationMapper : ICalculationMapper
    {
        public CalculationDto FromCalculationRequestToCalculationDto(CalculationRequest calculationRequest)
        {
            CalculationDto calculationDto = new CalculationDto
            {
                Operand1 = calculationRequest.Operand1,
                Operand2 = calculationRequest.Operand2,
                OperationType = calculationRequest.OperationType
            };
            return calculationDto;
        }

        public CalculationResponse ToCalculationResponse(CalculationDto calculationDto, decimal result)
        {
            CalculationResponse calculationResponse = new CalculationResponse
            {
                Operand1 = calculationDto.Operand1,
                Operand2 = calculationDto.Operand2,
                OperationType = calculationDto.OperationType,
                Result = result
            };
            calculationResponse.Message = $"{calculationResponse.Operand1} {calculationResponse.OperationType.GetDisplayAttributeName()} {calculationResponse.Operand2} = {calculationResponse.Result}";
            return calculationResponse;
        }
    }
}
