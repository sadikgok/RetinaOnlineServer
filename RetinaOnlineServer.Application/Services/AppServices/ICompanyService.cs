using RetinaOnlineServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using RetinaOnlineServer.Domain.AppEntities;

namespace RetinaOnlineServer.Application.Services.AppServices
{
    public interface ICompanyService
    {
        Task CreateCompany(CreateCompanyRequest request);
        Task MigrateCompanyDatabases();
        Task<Company?> GetCompanyByName(string name);
    }
}
