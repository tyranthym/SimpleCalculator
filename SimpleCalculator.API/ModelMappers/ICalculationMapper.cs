using SimpleCalculator.API.Models.Dtos;
using SimpleCalculator.API.Models.Requests;
using SimpleCalculator.API.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.API.ModelMappers
{
    public interface ICalculationMapper
    {
        CalculationDto FromCalculationRequestToCalculationDto(CalculationRequest calculationRequest);
        CalculationResponse ToCalculationResponse(CalculationDto calculationDto, decimal result);
    }
}
