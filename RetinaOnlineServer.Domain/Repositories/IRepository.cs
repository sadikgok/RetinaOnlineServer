using Microsoft.EntityFrameworkCore;
using RetinaOnlineServer.Domain.Abstractions;

namespace RetinaOnlineServer.Domain.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        void SetDbContexInstance(DbContext context);
        DbSet<T> Entity { get; set; }
    }
}
