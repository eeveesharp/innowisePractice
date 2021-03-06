using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.BLL.Interfaces;
using Shop.BLL.Models;
using Shop.BLL.Services;
using Shop.DAL.DI;

namespace Shop.BLL.DI
{
    public static class BusinessLogicRegister
    {
        public static void AddBusinessLogic(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IGenericServices<Product>, ProductServices>();

            serviceCollection.AddScoped<IOrderServices, OrderServices>();

            serviceCollection.AddScoped<IGenericServices<Client>, ClientServices>();

            serviceCollection.AddDataAccess(configuration);
        }
    }
}
