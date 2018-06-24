
using System.Security.Claims;
using System.Threading.Tasks;

namespace The.Barber.Api.Auth
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(string userName, string id, string perfil);
    }
}
