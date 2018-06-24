

using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using The.Barber.Api.Auth;
using The.Barber.Api.Models;
using Newtonsoft.Json;

namespace The.Barber.Api.Helpers
{
    public class Tokens
    {
      public static async Task<string> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory,string userName, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings)
      {
        var response = new
        {
          perfil = identity.Claims.Single(c => c.Type == "rol").Value,
          id = identity.Claims.Single(c => c.Type == "id").Value,
          auth_token = await jwtFactory.GenerateEncodedToken(userName, identity),
          expires_in = (int)jwtOptions.ValidFor.TotalSeconds
        };
            try
            {
                return JsonConvert.SerializeObject(response, serializerSettings);

            }
            catch (System.Exception e)
            {

                throw;
            }
      }
    }
}
