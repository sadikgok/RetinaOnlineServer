using Microsoft.AspNetCore.Identity;

namespace RetinaOnlineServer.Domain.AppEntities.Identity
{
    public sealed class AppRole : IdentityRole<string>
    {
        public  string Code { get; set; } 
    }
}
