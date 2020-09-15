using Microsoft.AspNetCore.Mvc;
using SimpleCalculator.API.ModelMappers;
using SimpleCalculator.API.Models.Requests;
using SimpleCalculator.API.Models.Response;
using SimpleCalculator.API.Services.Calculation;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.API.Controllers
{
    [SwaggerTag("Perform simple (+, -, *, /) operation")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorsController : ControllerBase
    {

        private readonly ICalculationService _calculationService;
        private readonly ICalculationMapper _calculationMapper;

        public CalculatorsController(ICalculationService calculationService, ICalculationMapper calculationMapper)
        {
            this._calculationService = calculationService;
            this._calculationMapper = calculationMapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CalculationResponse), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public IActionResult Calculate(CalculationRequest requestModel)
        {
            //map request to dto (service layer)
            var dto = _calculationMapper.FromCalculationRequestToCalculationDto(requestModel);

            //calculate result
            var result = _calculationService.CalculateResult(dto);          

            //map to response
            var calculationResponse = _calculationMapper.ToCalculationResponse(dto, result);            

            return Ok(calculationResponse);
        }
    }
}
