using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
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
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
        }
        private static ServiceProvider CreateServices()
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings["ConnectionString"];
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(result)
                    .ScanIn(typeof(AdicionarTabelas).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}