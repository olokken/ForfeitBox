using Xunit;

namespace ForfeitCase.Test
{
  public class WeatherForecastTest
  {
    [Fact]
    public async void Test()
    {
      await using var application = new TestApplication();
      var client = application.CreateClient();

      var response = await client.GetAsync("/api/WeatherForecast");
      Assert.True(response.IsSuccessStatusCode); 
    }
  }
}

