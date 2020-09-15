using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.API.Models.Response
{
    public interface IResponseBase
    {
        string Message { get; set; }               //response message
    }

    public class ResponseBase : IResponseBase
    {
        public string Message { get; set; }
    }
}
