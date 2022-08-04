using System;
using System.Text.Json.Serialization;

namespace ForfeitCase.Entities
{
  public class User
  {
    [JsonPropertyName("userId")]
    public String? UserId { get; set; }
    [JsonPropertyName("email")]
    public String? Email { get; set; }
    [JsonPropertyName("name")]
    public String? Name { get; set; }
    public String? Password { get; set; }
    public List<Case>? Cases { get; set; }
  }
}

