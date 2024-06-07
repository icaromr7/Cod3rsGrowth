using Cod3rsGrowth.dominio;
using Cod3rsGrowth.infra;
using Cod3rsGrowth.Servico;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.testes
{
    public static class ModuloDeInjecaoTeste
    {
        public static IServiceCollection BindServices(IServiceCollection services)
        {
            services.AddScoped<IAnimeRepositorio, AnimeRepositorioMock>();
            services.AddScoped<IGeneroRepositorio, GeneroRepositorioMock>();
            services.AddScoped<AnimeServico>();
            services.AddScoped<GeneroServico>();
            services.AddSingleton<TabelaDeAnime>();
            services.AddSingleton<TabelaDeGenero>();
            services.AddScoped<IValidator<Anime>, AnimeValidador>();
            services.AddScoped<IValidator<Genero>, GeneroValidador>();
            return services;
        }

    }
}
