using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.DAL.EF;
using Shop.DAL.Entities;
using Shop.DAL.Interfaces;
using Shop.DAL.Repositories;

namespace Shop.DAL.DI
{
    public static class DataAccessRegister
    {
        public static void AddDataAccess(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            serviceCollection.AddScoped<IGenericRepository<ClientEntity>, ClientRepository>();

            serviceCollection.AddScoped<IGenericRepository<ProductEntity>, ProductRepository>();

            serviceCollection.AddScoped<IOrderRepository, OrderRepository>();

            serviceCollection.AddDbContext<ApplicationContext>(context =>
            {
                context.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
