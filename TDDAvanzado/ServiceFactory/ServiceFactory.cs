using BusinessLogic;
using DataAccess;
using IBusinessLogic;
using IDataAccess;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServiceFactory
{
    public static class ServiceFactory
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMovieLogic, MovieLogic>();
            serviceCollection.AddScoped<IMovieRepository, MovieRepository>();
        }
    }
}
