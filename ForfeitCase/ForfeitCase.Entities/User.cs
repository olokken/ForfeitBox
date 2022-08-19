using System;
using System.Text.Json.Serialization;

using System.Text.Json.Serialization;

namespace ForfeitCase.Entities
{
  public class User
  {
    [JsonPropertyName("userId")]
    public string? UserId { get; set; }
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    public string? Password { get; set; }
    public IEnumerable<Case>? Cases { get; set; }
  }
}

