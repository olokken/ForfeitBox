using System.Text;
using System.Text.Json;
using ForfeitCase.Entities;
using ForfeitCase.Web.Dtos;
using ForfeitCase.Web.Dtos.User;
using Xunit;

namespace ForfeitCase.Test
{
  public class UserEndpointTest
  {
    [Fact]
    public async void Test()
    {
      await using var application = new TestApplication();
      var client = application.CreateClient();

      //Creating a user
      CreateUserDto userDto = new CreateUserDto
      {
        Name = "name",
        Email = "mail@mail.com"
      };
      HttpContent content = new StringContent(JsonSerializer.Serialize(userDto), Encoding.UTF8, "application/json");
      var createResponse = await client.PostAsync("/api/User", content);
      String stringResponse = await createResponse.Content.ReadAsStringAsync();
      User? user = JsonSerializer.Deserialize<User>(stringResponse);
      Assert.True(createResponse.IsSuccessStatusCode);

      //Fetching all users
      if (user != null)
      {
        HttpResponseMessage response = await client.GetAsync($"/api/User/{user.UserId}");
        Assert.True(response.IsSuccessStatusCode);
      }
    }
  }
}

