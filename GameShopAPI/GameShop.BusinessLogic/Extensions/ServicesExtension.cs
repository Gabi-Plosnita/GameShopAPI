using GameShop.BusinessLogic.Services;
using GameShop.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GameShop.BusinessLogic.Extensions
{
    public static class ServicesExtension
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            // Configure Repositories
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGameCompanyRepository, GameCompanyRespository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            // Configure Services
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGameCompanyService, GameCompanyService>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
