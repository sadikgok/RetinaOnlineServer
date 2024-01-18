using RetinaOnlineServer.Domain.AppEntities.Identity;

namespace RetinaOnlineServer.Application.Features.RoleFeatures.Queries.GetAllRoles
{
    public class GetAllRolesResponse
    {
        public IList<AppRole> Roles { get; set; }
    }
}