using RentOrBuy.Home.Business.HomeownershipCompuations;
using RentOrBuy.Home.Business.HomeownershipComputations;
using RentOrBuy.Home.Business.RentalComputations;
using RentOrBuy.Home.Business.RentOrBuyComputations;

namespace RentOrBuy.Home.API
{
    public static class RentOrBuyServiceCollection
    {
        public static IServiceCollection AddRentOrBuyServiceCollection(
            this IServiceCollection services)
        {
            services.AddScoped<IRentOrBuyCalculator, RentOrBuyCalculator>();
            services.AddScoped<IHomeOwnershipCostCalculator, HomeOwnershipCostCalculator>();
            services.AddScoped<IHomeAppreciationCalculator, HomeAppreciationCalculator>();
            services.AddScoped<IRentalCostCalculator, RentalCostCalculator>();
            services.AddScoped<ITotalRentalCostCalculator, TotalRentalCostCalculator>();
            return services;
        }
    }
}
