using MediatR;
using Microsoft.AspNetCore.Identity;
using RetinaOnlineServer.Application.Services.AppServices;
using RetinaOnlineServer.Domain.AppEntities.Identity;

namespace RetinaOnlineServer.Application.Features.RoleFeatures.Commands.DeleteRole
{
    public sealed class DeleteRoleHandler : IRequestHandler<DeleteRoleRequest, DeleteRoleResponse>
    {
        private readonly IRoleService _roleService;

        public DeleteRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<DeleteRoleResponse> Handle(DeleteRoleRequest request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleService.GetById(request.Id);
            if (role == null) throw new Exception("Role bulunamadı");
            await _roleService.DeleteByIdAsync(request.Id);
            return new();
        }
    }
}
