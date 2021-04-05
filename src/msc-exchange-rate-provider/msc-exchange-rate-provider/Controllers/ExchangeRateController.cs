using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace msc_exchange_rate_provider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRateController : ControllerBase
    {
        private static readonly Dictionary<string, decimal> ExchangeRates = new Dictionary<string, decimal>
        {
            { "EUR", 4.60m },
            { "GBP", 5.42m },
        };

        [HttpGet]
        public decimal GetExchangeRate(string currency)
        {
            return ExchangeRates.FirstOrDefault(x => x.Key.ToLower() == currency.ToLower()).Value;
        }
    }
}