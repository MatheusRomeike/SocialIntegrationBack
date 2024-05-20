using Application.Context;
using Application.Interfaces.ServiceInterfaces;
using Application.Services;
using Application.SocialMediaService;
using Application.Token;
using Data.Contracts;
using Data.Repository;
using Data.Interfaces.RepositoryInterface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;

#region Npgsql
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
#endregion

#region Environment
#if DEBUG
DotNetEnv.Env.Load(Path.Combine(Directory.GetCurrentDirectory(), ".env.local"));
#else
    DotNetEnv.Env.Load(Path.Combine(Directory.GetCurrentDirectory(), ".env"));
#endif
#endregion

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

builder.Logging.AddConsole();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Token JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(option =>
      {
          option.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = false,
              ValidateAudience = false,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,

              ValidIssuer = "SocialHub.Securiry.Bearer",
              ValidAudience = "SocialHub.Securiry.Bearer",
              IssuerSigningKey = JwtSecurityKey.Create(Environment.GetEnvironmentVariable("SECRET_TOKEN"))
          };

          option.Events = new JwtBearerEvents
          {
              OnAuthenticationFailed = context =>
              {
                  Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                  return Task.CompletedTask;
              },
              OnTokenValidated = context =>
              {
                  Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                  return Task.CompletedTask;
              }
          };
      });
#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region Access
//var urlHML = "https://dominiodocliente2.com.br";
//var urlPROD = "https://dominiodocliente3.com.br";
//app.UseCors(b => b.WithOrigins(urlDev, urlHML, urlPROD));

var urlDev = "https://pocmatheus.web.app";
var urlDevLocal = "http://localhost:4200";
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader().WithOrigins(urlDev, urlDevLocal));
#endregion

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseSwaggerUI();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
    services.AddDbContext<DataContext>(options =>
                    options.UseNpgsql(connectionString));


    services.AddScoped<IUnitOfWork, UnitOfWork>();

    services.AddScoped<IAccountRepository, AccountRepository>();
    services.AddScoped<IAccountConfigurationRepository, AccountConfigurationRepository>();
    services.AddScoped<IPostRepository, PostRepository>();
    services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
    services.AddScoped<ISocialMediaConfigurationRepository, SocialMediaConfigurationRepository>();
    services.AddScoped<IUserRepository, UserRepository>();


    services.AddScoped<IAccountService, AccountService>();
    services.AddScoped<ISocialMediaService, SocialMediaService>();
    services.AddScoped<IUserService, UserService>();

    services.AddScoped<IPublishService, XService>();
}