using Microsoft.Extensions.DependencyInjection;
using Pupita.Core.Repositories;
using Pupita.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Pupita.API.Configurations
{
    public static class ServicesConfigurations
    {
        public static IServiceCollection AddRepository(
            this IServiceCollection services)
        {
            services
                .AddTransient<IAlbumRepository, AlbumRepository>()
                .AddTransient<IArtistRepository, ArtistRepository>();

            return services;
        }
    }
}
