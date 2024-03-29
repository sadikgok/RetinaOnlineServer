﻿using Microsoft.EntityFrameworkCore;
using RetinaOnlineServer.Domain;
using RetinaOnlineServer.Domain.AppEntities;
using RetinaOnlineServer.Persistance.Context;

namespace RetinaOnlineServer.Persistance
{
    public sealed class ContextService : IContextService
    {
        private readonly AppDbContext _appContext;

        public ContextService(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public DbContext CreateContextInstance(string companyId)
        {
            Company company = _appContext.Set<Company>().Find(companyId);
            return new CompanyDbContext(company);
        }
    }
}
