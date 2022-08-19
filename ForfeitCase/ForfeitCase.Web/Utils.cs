using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ForfeitBox.Web
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
        Claim? claim = claims.FirstOrDefault(c => c.Type == "oid");      
        if (claim != null)
        {
          return claim.Value;
        }
      }
      return "";
    }
  }
}

