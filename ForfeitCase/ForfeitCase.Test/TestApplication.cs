using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
        //services.AddScoped<IDbConnection, SqlConnection>(_ => new SqlConnection(""));
      });
      return base.CreateHost(builder);
    }
  }
}


