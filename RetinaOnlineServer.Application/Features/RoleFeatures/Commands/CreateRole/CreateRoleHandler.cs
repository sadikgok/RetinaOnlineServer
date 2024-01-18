using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RetinaOnlineServer.Application.Services.AppServices;
using RetinaOnlineServer.Domain.AppEntities.Identity;

namespace RetinaOnlineServer.Application.Features.RoleFeatures.Commands.CreateRole
{
    public sealed class CreateRoleHandler : IRequestHandler<CreateRoleRequest, CreateRoleResponse>
    {
        private readonly IRoleService _roleService;

        public CreateRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<CreateRoleResponse> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
        {
            AppRole role = await _roleService.GetByCode(request.Code);
            if (role != null) throw new Exception("Bu rol daha önce kayıt edilmiş");

            await _roleService.AddAsync(request);
            return new();
        }
    }
}
