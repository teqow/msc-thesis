using System.Threading.Tasks;

namespace msc_converter
{
    public interface ICurrencyConvertService
    {
        Task<decimal> ConvertCurrency(string currency, decimal value);
    }

    public class CurrencyConvertService : ICurrencyConvertService
    {
        private readonly IExchangeRateProvider _exchangeRateProvider;

        public CurrencyConvertService(IExchangeRateProvider exchangeRateProvider)
        {
            _exchangeRateProvider = exchangeRateProvider;
        }

        public async Task<decimal> ConvertCurrency(string currency, decimal value)
        {
            var exchangeRate = await _exchangeRateProvider.GetExchangeRateAsync(currency);

            return value * exchangeRate;
        }
    }
}