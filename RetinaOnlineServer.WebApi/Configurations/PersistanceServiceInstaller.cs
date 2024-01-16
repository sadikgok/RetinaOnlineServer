using Microsoft.EntityFrameworkCore;
using RetinaOnlineServer.Domain.AppEntities.Identity;
using RetinaOnlineServer.Persistance.Context;

namespace RetinaOnlineServer.WebApi.Configurations
{
    public class PersistanceServiceInstaller : IServiceInstaller
    {
        private const string SectionName = "SqlServer";
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(SectionName)));
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddAutoMapper(typeof(RetinaOnlineServer.Persistance.AssemblyReferance).Assembly);
        }
    }
}
