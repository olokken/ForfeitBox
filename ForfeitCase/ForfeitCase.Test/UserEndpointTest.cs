using System.Text;
using System.Text.Json;
using ForfeitCase.Entities;
using ForfeitCase.Web.Dtos;
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
      Assert.True(createResponse.IsSuccessStatusCode);

      //Fetching all users
      HttpResponseMessage response = await client.GetAsync("/api/User");
      String body = await response.Content.ReadAsStringAsync(); 
      IEnumerable<User>? users = JsonSerializer.Deserialize<IEnumerable<User>>(body);
      Assert.NotEmpty(users); 
      Assert.True(response.IsSuccessStatusCode);
    }
  }
}

