using CinemaManagement.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagement.Controllers.CMSController
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        public ISessionService session { get; set; }
    }
}
