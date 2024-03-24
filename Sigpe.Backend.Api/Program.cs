using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Sigpe.Backend.Infra.IoC;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddMvc().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SYMMETRIC_SECURITY_KEY")));
builder.Services.AddAuthentication(authOptions =>
{
    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer("Bearer", options =>
{
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        IssuerSigningKey = key,
        ValidateAudience = false,
        ValidateIssuer = false
    };
});

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors(builder =>
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
