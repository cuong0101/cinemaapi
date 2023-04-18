using CinemaManagement.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CinemaManagement.Services
{
    public class SessionService : ISessionService
    {

        private readonly IHttpContextAccessor accessor;

        public SessionService(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        public ClaimsPrincipal GetUser()
        {
            return accessor?.HttpContext?.User;
        }

        public ClaimsPrincipal GetUserId()
        {
            return accessor?.HttpContext?.User ;
        }
    }
}
