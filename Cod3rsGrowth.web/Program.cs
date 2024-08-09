using Cod3rsGrowth.dominio;
using Cod3rsGrowth.dominio.Migracoes;
using Cod3rsGrowth.infra;
using Cod3rsGrowth.Servico;
using Cod3rsGrowth.web;
using FluentMigrator.Runner;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Diagnostics;
using ConfigurationManager = System.Configuration.ConfigurationManager;
const string PERFIL_TESTE = "BancoDeDadosTeste";
const string CONNECTION_STRING_TESTE = "ConnectionStringTeste";
const int POSICAO_COMMAND_LINE_ARGS = 1;
var builder = WebApplication.CreateBuilder(args);

var appSettings = ConfigurationManager.AppSettings;

if (Environment.GetCommandLineArgs()[POSICAO_COMMAND_LINE_ARGS] == PERFIL_TESTE)
    ConnectionString.connectionString = CONNECTION_STRING_TESTE;
string result = appSettings[ConnectionString.connectionString];
builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddSqlServer()
        .WithGlobalConnectionString(result)
        .ScanIn(typeof(_20240605085700_CriarTabelas).Assembly).For.Migrations())
    .AddLogging(lb => lb.AddFluentMigratorConsole());

builder.Services.AddMvc().AddJsonOptions(x => { x.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter()); });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDirectoryBrowser();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AnimeServico>();
builder.Services.AddScoped<GeneroServico>();
builder.Services.AddScoped<AnimeGeneroServico>();
builder.Services.AddScoped<IAnimeRepositorio, AnimeRepositorio>();
builder.Services.AddScoped<IGeneroRepositorio, GeneroRepositorio>();
builder.Services.AddScoped<IAnimeGeneroRepositorio, AnimeGeneroRepositorio>();
builder.Services.AddScoped<IValidator<Anime>, AnimeValidador>();
builder.Services.AddScoped<IValidator<Genero>, GeneroValidador>();
builder.Services.AddScoped<IValidator<AnimeGenero>, AnimeGeneroValidador>();
builder.Services.AddFluentValidation();
builder.Services.ConfigureProblemDetailsModelState();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseProblemDetailsExceptionHandler(app.Services.GetRequiredService<ILoggerFactory>());
using (var scope = app.Services.CreateScope())
{
    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
}
app.UseHttpsRedirection();

app.UseFileServer(new FileServerOptions {EnableDirectoryBrowsing = true});
app.UseStaticFiles(new StaticFileOptions {ServeUnknownFileTypes = true});

app.UseAuthorization();



app.MapControllers();

app.Run();
