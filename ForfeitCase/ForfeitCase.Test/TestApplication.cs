using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySqlConnector;

namespace ForfeitCase.Test
{
  class TestApplication : WebApplicationFactory<Program>
  {
    public string DefaultUserId { get; set; } = "1";

    protected override IHost CreateHost(IHostBuilder builder)
    {
      builder.ConfigureServices(services =>
      {
        var serviceDescriptor = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(IDbConnection));
        if (serviceDescriptor != null)
        {
          services.Remove(serviceDescriptor);
        }
        //Server=127.0.0.1;Port=3306;Database=test_db;Uid=root;Pwd=root;
        services.AddScoped<IDbConnection, MySqlConnection>(_ => new MySqlConnection("Server=127.0.0.1;Port=3306;Database=ForfeitCase;Uid=root;Pwd=MyNewPass;"));
      });
      return base.CreateHost(builder);
    }
  }
}


