using Cod3rsGrowth.dominio;
using Cod3rsGrowth.dominio.Migracoes;
using Cod3rsGrowth.infra;
using Cod3rsGrowth.Servico;
using FluentMigrator.Runner;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddSqlServer()
        .WithGlobalConnectionString(ConstantesDoRepositorio.CONNECTION_STRING)
        .ScanIn(typeof(_20240605085700_CriarTabelas).Assembly).For.Migrations())
    .AddLogging(lb => lb.AddFluentMigratorConsole());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var runner = builder.Services.BuildServiceProvider().GetRequiredService<IMigrationRunner>();
runner.MigrateUp();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
