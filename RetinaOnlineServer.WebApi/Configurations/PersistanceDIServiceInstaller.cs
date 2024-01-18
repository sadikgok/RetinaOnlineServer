using RetinaOnlineServer.Application.Features.CompanyFeatures;
using RetinaOnlineServer.Application.Services.AppServices;
using RetinaOnlineServer.Domain.Repositories.UCAFRepositories;
using RetinaOnlineServer.Domain;
using RetinaOnlineServer.Persistance.Repositories.UCAFRepositories;
using RetinaOnlineServer.Persistance.Services.AppServices;
using RetinaOnlineServer.Persistance.Services.CompanyServices;
using RetinaOnlineServer.Persistance;

namespace RetinaOnlineServer.WebApi.Configurations
{
    public class PersistanceDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICompanyService, CompanyServices>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUCAFCommandRepository, UCAFCommandRepository>();
            services.AddScoped<IUCAFQueryRepository, UCAFQueryRepository>();
            services.AddScoped<IContextService, ContextService>();
            services.AddScoped<IUCAFService, UCAFService>();
            services.AddScoped<IRoleService, RoleService>();
        }
    }
}
