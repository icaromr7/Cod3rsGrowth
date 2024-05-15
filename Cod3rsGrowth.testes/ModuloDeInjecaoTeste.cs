using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
    public static class ModuloDeInjecaoTeste
    {
        public static IServiceCollection BindServices(IServiceCollection services)
        {
            services.AddScoped<IAnimeServico, AnimeRepository>();
            services.AddScoped<IGeneroServico, GeneroRepository>();
            services.AddScoped<IAnimeRepositorioMock, AnimeRepositorioMock>();
            services.AddScoped<IGeneroRepositorioMock, GeneroRepositorioMock>();
            return services;
        }

    }
}
