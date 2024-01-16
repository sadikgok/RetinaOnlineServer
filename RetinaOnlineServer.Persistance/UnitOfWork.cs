using Microsoft.EntityFrameworkCore;
using RetinaOnlineServer.Domain;
using RetinaOnlineServer.Persistance.Context;

namespace RetinaOnlineServer.Persistance
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private CompanyDbContext _contex;
        public void SetDbContextInstance(DbContext context)
        {
            _contex = (CompanyDbContext)context;
        }

        public async Task<int> SaveChangesAsync()
        {
            int count = await _contex.SaveChangesAsync();
            return count;
        }
    }
}
