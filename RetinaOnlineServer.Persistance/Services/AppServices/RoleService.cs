using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RetinaOnlineServer.Application.Features.RoleFeatures.Commands.CreateRole;
using RetinaOnlineServer.Application.Services.AppServices;
using RetinaOnlineServer.Domain.AppEntities.Identity;

namespace RetinaOnlineServer.Persistance.Services.AppServices
{
    public sealed class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public RoleService(RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateRoleRequest request)
        {
            AppRole role = _mapper.Map<AppRole>(request);
            role.Id = Guid.NewGuid().ToString();
            await _roleManager.CreateAsync(role);
        }

        public async Task DeleteAsync(AppRole role)
        {
            await _roleManager.DeleteAsync(role);
        } 

        public async Task<IList<AppRole>> GetAllRolesAsync()
        {
            IList<AppRole> roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }

        public async Task<AppRole> GetByCode(string code)
        {
            AppRole role = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Code == code);
            return role;
        }

        public async Task<AppRole> GetById(string id)
        {
            AppRole role = await _roleManager.FindByIdAsync(id);
            return role;
        }

        public async Task UpdateAsync(AppRole role)
        {
            await _roleManager.UpdateAsync(role);
        }
    }
}
