using RentOrBuy.Home.Business.HomeownershipComputations.HomeAppreciationComputation;
using RentOrBuy.Home.Business.HomeownershipComputations.HomeOwnershipComputation;
using RentOrBuy.Home.Business.HomeownershipComputations.TotalHomeOwnershipCostComputation;
using RentOrBuy.Home.Business.RentalComputations.RentalCostComputation;
using RentOrBuy.Home.Business.RentalComputations.TotalRentalCostComputation;
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
            services.AddScoped<ITotalHomeOwnershipCostCalculator, TotalHomeownershipCostCalculator>();
            services.AddScoped<IRentalCostCalculator, RentalCostCalculator>();
            services.AddScoped<ITotalRentalCostCalculator, TotalRentalCostCalculator>();
            return services;
        }
    }
}
