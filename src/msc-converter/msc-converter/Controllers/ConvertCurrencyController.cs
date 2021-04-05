using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace msc_converter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertCurrencyController : ControllerBase
    {
        private readonly ICurrencyConvertService _currencyConvert;
        
        public ConvertCurrencyController(ICurrencyConvertService currencyConvert)
        {
            _currencyConvert = currencyConvert;
        }

        [HttpGet]
        public async Task<decimal> ConvertCurrency(string currency, decimal value)
        {
            return await _currencyConvert.ConvertCurrency(currency, value);
        }

    }
}