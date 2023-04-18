using System.Security.Claims;
using System.Threading.Tasks;

namespace CinemaManagement.Interfaces
{
    public interface ISessionService
    {
        ClaimsPrincipal GetUserId();
    }
}
