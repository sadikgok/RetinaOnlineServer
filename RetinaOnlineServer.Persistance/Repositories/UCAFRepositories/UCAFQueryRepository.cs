using RetinaOnlineServer.Domain.CompanyEntities;
using RetinaOnlineServer.Domain.Repositories.UCAFRepositories;

namespace RetinaOnlineServer.Persistance.Repositories.UCAFRepositories
{
    public sealed class UCAFQueryRepository:QueryRepository<UniformChartOfAccount>,IUCAFQueryRepository
    {
    }
}
