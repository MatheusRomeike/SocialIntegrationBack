using Application.Context;
using Application.Interfaces.ServiceInterfaces;
using Application.Services;
using Application.SocialNetworks;
using Application.Token;
using Data.Contracts;
using Data.Repository;
using Data.Interfaces.RepositoryInterface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

#region Npgsql
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
#endregion

#region Envinroment
DotNetEnv.Env.Load(Path.Combine(Directory.GetCurrentDirectory(), ".env"));

#endregion

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

builder.Logging.AddConsole();
builder.Services.AddControllers();
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
              IssuerSigningKey = JwtSecurityKey.Create(Environment.GetEnvironmentVariable("SECRET"))
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
//var urlDev = "https://dominiodocliente.com.br";
//var urlHML = "https://dominiodocliente2.com.br";
//var urlPROD = "https://dominiodocliente3.com.br";
//app.UseCors(b => b.WithOrigins(urlDev, urlHML, urlPROD));

var devCliente = "http://localhost:4200";
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader().WithOrigins(devCliente));
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
    services.AddScoped<ICompanyRepository, CompanyRepository>();
    services.AddScoped<IImageRepository, ImageRepository>();
    services.AddScoped<IPostGroupRepository, PostGroupRepository>();
    services.AddScoped<IPostImageRepository, PostImageRepository>();
    services.AddScoped<IPostRepository, PostRepository>();
    services.AddScoped<ISocialNetworkRepository, SocialNetworkRepository>();
    services.AddScoped<IUserRepository, UserRepository>();


    services.AddScoped<IPublishService, PublishService>();
    services.AddScoped<IRestClientService, RestClientService>();
    services.AddScoped<IUserService, UserService>();


    services.AddScoped<ISocialNetworkService, XService>();
}