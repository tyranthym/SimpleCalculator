using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.API.Enums
{
    public enum OperationType
    {
        [Display(Name = "+")]
        Addition,
        [Display(Name = "-")]
        Subtraction,
        [Display(Name = "*")]
        Multiplication,
        [Display(Name = "/")]
        Division
    }
}
