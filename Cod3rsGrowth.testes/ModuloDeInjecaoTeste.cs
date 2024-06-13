using Cod3rsGrowth.dominio;
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
            services.AddScoped<IAnimeGeneroRepositorio, AnimeGeneroRepositorioMock>();
            services.AddScoped<AnimeServico>();
            services.AddScoped<GeneroServico>();
            services.AddScoped<AnimeGeneroServico>();
            services.AddSingleton<TabelaDeAnime>();
            services.AddSingleton<TabelaDeGenero>();
            services.AddScoped<IValidator<Anime>, AnimeValidador>();
            services.AddScoped<IValidator<Genero>, GeneroValidador>();
            services.AddScoped<IValidator<AnimeGenero>, AnimeGeneroValidador>();
            return services;
        }

    }
}
