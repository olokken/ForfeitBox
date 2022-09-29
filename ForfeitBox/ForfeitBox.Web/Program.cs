using System.Data;
using ForfeitBox.Repository;
using ForfeitBox.Service;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDbConnection, MySqlConnection>(_ => new MySqlConnection(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IAllocationRepsitory, AllocationRepsitory>();
builder.Services.AddScoped<IAllocationService, AllocationService>();

builder.Services.AddScoped<IBoxRepsitory, BoxRepsitory>();
builder.Services.AddScoped<IBoxService, BoxService>();

builder.Services.AddScoped<IForfeitRepository, ForfeitRepository>();
builder.Services.AddScoped<IForfeitService, ForfeitService>();

builder.Services.AddScoped<IPaymentRepsitory, PaymentRepsitory>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddScoped<IUserCaseRepsitory, UserCaseRepsitory>();
builder.Services.AddScoped<IUserCaseService, UserCaseService>();

builder.Services.AddScoped<IUserRepsitory, UserRepsitory>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
