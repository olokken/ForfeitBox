using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ForfeitBox.Entities;

namespace ForfeitBox.Web
{
  public class Utils
  {
    public static string GetIdFromToken(HttpContext httpContext)
    {
      IEnumerable<Claim> claims = GetClaims(httpContext); 
      Claim? claim = claims.FirstOrDefault(c => c.Type == "sub");      
      if (claim != null)
      {
        return claim.Value;
      }
      return "";
    }

    public static IEnumerable<Claim> GetClaims(HttpContext httpContext)
    {
      string token = httpContext.Request.Headers["Authorization"];
        if (token != null)
        {
          token = token.Substring(7);
          var handler = new JwtSecurityTokenHandler();
          var jwt = handler.ReadJwtToken(token);
          return jwt.Claims;
        }
      return Enumerable.Empty<Claim>(); 
    }

    public static User? CreateUserFromToken(HttpContext httpContext)
    {
      IEnumerable<Claim> claims = GetClaims(httpContext);
      Claim? sub = claims.FirstOrDefault(c => c.Type == "sub");
      Claim? email = claims.FirstOrDefault(c => c.Type == "email");
      if(sub != null && email != null)
      {
        return new User
        {
          UserId = sub.Value,
          Email = email.Value,
        }; 
      }
      return null; 
    }

    public static string createCode()
    {
      var random = new Random();
      var result = new char[6];

      // Generate 6 random characters
      for (int i = 0; i < 6; i++)
      {
        // Generate a random number between 0 and 61
        int randomNumber = random.Next(0, 62);
        // Convert the random number to a character between A-Z or 0-9
        result[i] = Convert.ToChar(randomNumber + 'A');
        if (result[i] > '9')
        {
          result[i] = (char)(result[i] - 10);
        }
      }

      // Convert the char array to a string and print it
      return new string(result);
    }
  }
}

