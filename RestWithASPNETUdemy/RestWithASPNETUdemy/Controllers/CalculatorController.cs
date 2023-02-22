using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Somar(string firstNumber,string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) 
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
            
        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("sub/{firstNumber}/{secondNumber}")]
    public IActionResult Subtrair(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());

        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("div/{firstNumber}/{secondNumber}")]
    public IActionResult Divisao(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());

        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("mul/{firstNumber}/{secondNumber}")]
    public IActionResult Multiplicacao(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());

        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("med/{firstNumber}/{secondNumber}")]
    public IActionResult media(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            sum = sum / 2;
            return Ok(sum.ToString());

        }
        return BadRequest("Invalid Input");
    }

    [HttpGet("raiz/{firstNumber}")]
    public IActionResult RaizQuadrada(string firstNumber)
    {
        if (IsNumeric(firstNumber))
        {
            var sum = ConvertToDouble(firstNumber);
            sum = Math.Sqrt(sum);
            return Ok(sum.ToString());

        }
        return BadRequest("Invalid Input");
    }

    private double ConvertToDouble(string Number)
    {
        double decimalValue;
        if (double.TryParse(Number, out decimalValue))
        {
            return decimalValue;
        }
        return 0;
    }

    private decimal ConvertToDecimal(string Number)
    {
        decimal decimalValue;
        if(decimal.TryParse(Number,out decimalValue))
        {
            return decimalValue;
        }
        return 0; 
    }

    private bool IsNumeric(string Number)
    {
        double number;
        bool isNumber = double.TryParse(Number,
            System.Globalization.NumberStyles.Any,
            System.Globalization.NumberFormatInfo.InvariantInfo,
            out number);
        return isNumber;
    }
}
