using Microsoft.EntityFrameworkCore;

namespace RetinaOnlineServer.Domain
{
    public interface IContextService
    {
        DbContext CreateContextInstance(string companyId);
    }
}
