using DigitalPersonalization.Service;

namespace DigitalPersonalization
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IGenericTypeService, GenericTypeService>();
            services.AddScoped<ICreditCardMaskingService, CreditCardMaskingService>();
            services.AddScoped<IAdjustedAmountService, AdjustedAmountService>();
            return services;
        }
    }
}
