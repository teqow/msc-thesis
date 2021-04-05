using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace msc_converter
{
    public interface IExchangeRateProvider
    {
        Task<decimal> GetExchangeRateAsync(string currency);
    }

    public class ExchangeRateProvider : IExchangeRateProvider
    {
        private readonly IOptions<Settings> _settingsProvider;
        private static readonly HttpClient client = new HttpClient();

        public ExchangeRateProvider(IOptions<Settings> settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public async Task<decimal> GetExchangeRateAsync(string currency)
        {
            var response = await client.GetAsync(
                string.Concat(_settingsProvider.Value.ExchangeRateApiUrl, $"api/ExchangeRate?currency={currency}"));

            response.EnsureSuccessStatusCode();
            using var responseStream = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<decimal>(responseStream);
        }
    }
}