﻿using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
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
            services.AddScoped<IAnimeRepositorio, AnimeRepositorioMock>();
            services.AddScoped<IGeneroRepositorio, GeneroRepositorioMock>();
            services.AddScoped<IAnimeServico, AnimeServico>();
            services.AddScoped<IGeneroServico, GeneroServico>();
            services.AddSingleton<TabelaDeAnime>();
            services.AddSingleton<TabelaDeGenero>();
            return services;
        }

    }
}
