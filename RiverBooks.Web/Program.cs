using System.Reflection;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using RiverBooks.Books;
using RiverBooks.Users;
using Serilog;


var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

logger.Information("Starting web host");


var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((_, config) => config.ReadFrom.Configuration(builder.Configuration));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services
  .AddAuthenticationJwtBearer(options =>
  {
    options.SigningKey = builder.Configuration["Auth:JwtSecret"]!;
  })
  .AddAuthorization()
  .AddFastEndpoints()
  .SwaggerDocument();
List<Assembly> mediatRAssemblies = [typeof(Program).Assembly];
builder.Services.RegisterBooksServices(builder.Configuration, logger, mediatRAssemblies);
builder.Services.RegisterUsersServices(builder.Configuration, logger, mediatRAssemblies);
builder.Services
  .AddAuthenticationJwtBearer(options =>
  {
    options.SigningKey = builder.Configuration["Auth:JwtSecret"]!;
  })
  .AddAuthorization()
  .AddFastEndpoints()
  .SwaggerDocument();
// Important : après Identity
builder.Services.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies.ToArray()));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication()
  .UseAuthorization();
app.UseFastEndpoints()
  .UseSwaggerGen();

app.Run();

public partial class Program { } //Needed for test
