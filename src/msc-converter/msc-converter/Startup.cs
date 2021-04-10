using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace msc_converter
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public IConfigurationSection SettingsSection => _configuration.GetSection("Settings");
        public ApplicationSettings ApplicationSettings => SettingsSection.Get<ApplicationSettings>();

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHttpClient();
            services.Configure<ApplicationSettings>(SettingsSection);
            services.AddTransient<IExchangeRateProvider, ExchangeRateProvider>();
            services.AddTransient<ICurrencyConvertService, CurrencyConvertService>();

            services.AddCors(options =>
            {
                options.AddPolicy("mscpolicy", builder => builder
                    .WithOrigins(ApplicationSettings.AllowedDomains)
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            app.UseCors("mscpolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
