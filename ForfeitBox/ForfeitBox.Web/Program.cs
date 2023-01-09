using System.Data;
using ForfeitBox.Repository;
using ForfeitBox.Service;
using Microsoft.OpenApi.Models;
using MySqlConnector;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddScoped<IDbConnection, MySqlConnection>(_ => new MySqlConnection(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IAllocationRepository, AllocationRepository>();
builder.Services.AddScoped<IAllocationService, AllocationService>();

builder.Services.AddScoped<IBoxRepository, BoxRepository>();
builder.Services.AddScoped<IBoxService, BoxService>();

builder.Services.AddScoped<IForfeitRepository, ForfeitRepository>();
builder.Services.AddScoped<IForfeitService, ForfeitService>();

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddScoped<IUserCaseRepository, UserCaseRepository>();
builder.Services.AddScoped<IUserCaseService, UserCaseService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

builder.WebHost.UseUrls("http://*:8050");

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(); 

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
