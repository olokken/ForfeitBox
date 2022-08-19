using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ForfeitCase.Web
{
  public class Utils
  {
    public static string GetIdFromToken(HttpContext httpContext)
    {
      string token = httpContext.Request.Headers["Authorization"];
      if (token != null)
      {
        token = token.Substring(7);
        var handler = new JwtSecurityTokenHandler();
        var jwt = handler.ReadJwtToken(token);
        IEnumerable<Claim> claims = jwt.Claims;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        string? oid = claims.FirstOrDefault(c => c.Type == "oid").Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.            
        if (oid != null)
        {
          return oid;
        }
      }
      return "";
    }
  }
}

