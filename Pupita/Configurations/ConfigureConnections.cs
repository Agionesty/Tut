using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pupita.Core.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pupita.API.Configurations
{
    public static class ConfigureConnections 
    { //функция, которая через класс добавляетметод в другой класс, коорый пишется после слова this
        public static IServiceCollection AddConnectionProvider(
            this IServiceCollection services, IConfiguration configuraton)
        {
            services
                .AddDbContext<MusicContext>(opt =>
                opt.UseSqlServer(configuraton.GetConnectionString("Default"), 
                b => b.MigrationsAssembly("Pupita.API"))); // контекст связан именно с этим проеком
            return services;
        }
    }
}
