using RentOrBuy.Home.Business.HomeownershipCompuations;
using RentOrBuy.Home.Business.RentOrBuyComputations;

namespace RentOrBuy.Home.API
{
    public static class RentOrBuyServiceCollection
    {
        public static IServiceCollection AddRentOrBuyServiceCollection(
            this IServiceCollection services)
        {
            services.AddScoped<IRentOrBuyCalculator, RentOrBuyCalculator>();
            services.AddScoped<IHomeOwnershipCalculator, HomeOwnershipCalculator>();
            return services;
        }
    }
}
