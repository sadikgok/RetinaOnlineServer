using RetinaOnlineServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;

namespace RetinaOnlineServer.Application.Features.CompanyFeatures
{
    public interface IUCAFService
    {
        Task CreateUcafAsync(CreateUCAFRequest request);
    }
}
