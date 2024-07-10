using Base.BAL.Dominio;
using Base.Repository.Dominio;
using BaseAPI.Abstraction.DBContext;
using BaseAPI.BAL;
using BaseAPI.DataAccess;
using BaseAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder
                            .AllowAnyHeader()
                            .WithMethods("POST", "GET", "PUT", "DELETE")
                            .WithOrigins("http://localhost:4200", "http://localhost:8787/", "") // Parametrizar
                            .AllowCredentials();
                      });
});

builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration);
    config.Enrich.FromLogContext();
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DBBaseConnection");
builder.Services.AddDbContext<APIDBContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("BaseAPI.Rest")));

/*Definicion de la configuracion para JWT*/
var secretKey = builder.Configuration.GetSection("settings").GetSection("secretKey").ToString();
var keyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(config => {

    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(config => {
    config.RequireHttpsMetadata = false;
    config.SaveToken = false;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});



builder.Services.AddScoped(typeof(AuthenticationBAL<>), typeof(AuthenticationBAL<>));
builder.Services.AddScoped(typeof(AuthenticationRepository<>), typeof(AuthenticationRepository<>));

builder.Services.AddScoped(typeof(TerrestreRepository<>), typeof(TerrestreRepository<>));
builder.Services.AddScoped(typeof(MaritimaRepository<>), typeof(MaritimaRepository<>));

builder.Services.AddScoped(typeof(TerrestreBAL<>), typeof(TerrestreBAL<>));
builder.Services.AddScoped(typeof(MaritimaBAL<>), typeof(MaritimaBAL<>));

builder.Services.AddScoped(typeof(ResponseRepository<>), typeof(ResponseRepository<>));
builder.Services.AddScoped(typeof(AuthBAL), typeof(AuthBAL));
builder.Services.AddScoped(typeof(IDBContext<>), typeof(DBContext<>));
builder.Services.AddScoped(typeof(APIDBContext), typeof(APIDBContext));
builder.Services.AddScoped(typeof(ITokenHandlerService), typeof(TokenHandlerService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();


app.UseHttpsRedirection();

app.UseRouting();


app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();


app.Run();

