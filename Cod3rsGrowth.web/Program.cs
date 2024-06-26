using Cod3rsGrowth.dominio;
using Cod3rsGrowth.dominio.Migracoes;
using Cod3rsGrowth.infra;
using Cod3rsGrowth.Servico;
using FluentMigrator.Runner;
using FluentValidation;
using ConfigurationManager = System.Configuration.ConfigurationManager;
var builder = WebApplication.CreateBuilder(args);

var appSettings = ConfigurationManager.AppSettings;
string result = appSettings[ConstantesDoRepositorio.CONNECTION_STRING];

builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddSqlServer()
        .WithGlobalConnectionString(result)
        .ScanIn(typeof(_20240605085700_CriarTabelas).Assembly).For.Migrations())
    .AddLogging(lb => lb.AddFluentMigratorConsole());

builder.Services.AddControllers();
builder.Services.AddScoped<IGeneroRepositorio, GeneroRepositorio>();
builder.Services.AddScoped<IAnimeRepositorio, AnimeRepositorio>();
builder.Services.AddScoped<IAnimeGeneroRepositorio, AnimeGeneroRepositorio>();
builder.Services.AddScoped<AnimeServico>();
builder.Services.AddScoped<GeneroServico>();
builder.Services.AddScoped<AnimeGeneroServico>();
builder.Services.AddScoped<IValidator<Anime>, AnimeValidador>();
builder.Services.AddScoped<IValidator<Genero>, GeneroValidador>();
builder.Services.AddScoped<IValidator<AnimeGenero>, AnimeGeneroValidador>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
