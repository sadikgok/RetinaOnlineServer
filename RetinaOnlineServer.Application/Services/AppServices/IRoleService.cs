using RetinaOnlineServer.Application.Features.RoleFeatures.Commands.CreateRole;
using RetinaOnlineServer.Domain.AppEntities.Identity;

namespace RetinaOnlineServer.Application.Services.AppServices
{
    public interface IRoleService
    {
        Task AddAsync(CreateRoleRequest request);
        Task UpdateAsync(AppRole request);
        Task DeleteAsync(AppRole appRole);
        Task<IList<AppRole>> GetAllRolesAsync();
        Task<AppRole> GetById(string id);
        Task<AppRole> GetByCode(string code);
    }
}
