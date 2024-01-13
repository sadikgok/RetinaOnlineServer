using Microsoft.AspNetCore.Mvc;

namespace RetinaOnlineServer.Presentation.Abstraction
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
