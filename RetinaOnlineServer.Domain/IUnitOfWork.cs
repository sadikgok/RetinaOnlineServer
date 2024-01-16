using Microsoft.EntityFrameworkCore;

namespace RetinaOnlineServer.Domain
{
    public interface IUnitOfWork
    {
        void SetDbContextInstance(DbContext context);
        Task<int> SaveChangesAsync();
    }
}
