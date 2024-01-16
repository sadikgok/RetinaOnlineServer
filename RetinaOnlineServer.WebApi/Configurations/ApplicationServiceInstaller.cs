using RetinaOnlineServer.Application;

namespace RetinaOnlineServer.WebApi.Configurations
{
    public class ApplicationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly));
        }
    }
}
