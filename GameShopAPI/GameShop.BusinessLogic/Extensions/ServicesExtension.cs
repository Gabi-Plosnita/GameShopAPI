using GameShop.BusinessLogic.Services;
using GameShop.DataAccess.DataContext;
using GameShop.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GameShop.BusinessLogic.Extensions
{
    public static class ServicesExtension
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            // Configure Repositories
            services.AddScoped<BaseRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IGameCompanyRepository, GameCompanyRespository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Configure Services
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGameCompanyService, GameCompanyService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
        }

        public static void ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<GameShopDbContext>(
                options => options.UseSqlServer(connectionString));
        }
    }
}
