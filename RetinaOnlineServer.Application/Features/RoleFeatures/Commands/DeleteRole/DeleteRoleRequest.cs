using MediatR;

namespace RetinaOnlineServer.Application.Features.RoleFeatures.Commands.DeleteRole
{
    public sealed class DeleteRoleRequest : IRequest<DeleteRoleResponse>
    {
        public string Id { get; set; }
    }
}
