using RetinaOnlineServer.Application.Abstractions;
using RetinaOnlineServer.Infrasturcture.Authentication;

namespace RetinaOnlineServer.WebApi.Configurations
{
    public class InfrustructureDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJwtProvider, JwtProvider>();
        }
    }
}
