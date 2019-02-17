using System.Threading.Tasks;
using System.Security.Claims;
using CrExtApiCore.Repositories;
namespace CrExtApiCore.Factories
{
 public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity );
       Task<ClaimsIdentity> GenerateClaimsIdentity(string userName,string id);
    }
}