using Cod3rsGrowth.dominio;
using Cod3rsGrowth.dominio.Migracoes;
using Cod3rsGrowth.infra;
using Cod3rsGrowth.Servico;
using FluentMigrator.Runner;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;

namespace Cod3rsGrowth.forms
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            
            using (var serviceProvider = CreateServices())
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
            ApplicationConfiguration.Initialize();
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;
            Application.Run(ServiceProvider.GetRequiredService<FormLista>());
        }
        private static ServiceProvider CreateServices()
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[ConstantesDoRepositorio.CONNECTION_STRING];
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(result)
                    .ScanIn(typeof(_20240605085700_CriarTabelas).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddTransient<IGeneroRepositorio, GeneroRepositorio>();
                    services.AddTransient<IAnimeRepositorio, AnimeRepositorio>();
                    services.AddTransient<IAnimeGeneroRepositorio, AnimeGeneroRepositorio>();
                    services.AddTransient<AnimeServico> ();
                    services.AddTransient<GeneroServico> ();
                    services.AddTransient<AnimeGeneroServico>();
                    services.AddScoped<IValidator<Anime>, AnimeValidador>();
                    services.AddScoped<IValidator<Genero>, GeneroValidador>();
                    services.AddScoped<IValidator<AnimeGenero>, AnimeGeneroValidador>();
                    services.AddTransient<FormLista>();
                });
        }
    }
}