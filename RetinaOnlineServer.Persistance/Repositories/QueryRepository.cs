﻿using Microsoft.EntityFrameworkCore;
using RetinaOnlineServer.Domain.Abstractions;
using RetinaOnlineServer.Domain.Repositories;
using RetinaOnlineServer.Persistance.Context;
using System.Linq.Expressions;

namespace RetinaOnlineServer.Persistance.Repositories
{
    public class QueryRepository<T> : IQueryRepository<T> where T : Entity
    {
        private static readonly Func<CompanyDbContext, string, bool, Task<T>> GetByIdComplied = EF.CompileAsyncQuery((CompanyDbContext context, string id, bool isTracking) =>
        isTracking == true
        ? context.Set<T>().FirstOrDefault(p => p.Id == id)
        : context.Set<T>().AsNoTracking().FirstOrDefault(p => p.Id == id));

        private static readonly Func<CompanyDbContext, bool, Task<T>> GetFirstComplied = EF.CompileAsyncQuery((CompanyDbContext context, bool isTracking) =>
        isTracking == true
        ? context.Set<T>().FirstOrDefault()
        : context.Set<T>().AsNoTracking().FirstOrDefault());

        private static readonly Func<CompanyDbContext, Expression<Func<T, bool>>, bool, Task<T>> GetFirstByExpressionComplied = EF.CompileAsyncQuery((CompanyDbContext context, Expression<Func<T, bool>> expression, bool isTracking) =>
        isTracking == true
        ? context.Set<T>().FirstOrDefault(expression)
        : context.Set<T>().AsNoTracking().FirstOrDefault(expression));

        private CompanyDbContext _context;
        public DbSet<T> Entity { get; set; }

        public void SetDbContexInstance(DbContext context)
        {
            _context = (CompanyDbContext)context;
            Entity = _context.Set<T>();
        }

        public IQueryable<T> GetAll(bool isTracking = true)
        {
            var result = Entity.AsQueryable();
            if (!isTracking)
                result = result.AsNoTracking();
            return result;
        }

        public async Task<T> GetById(string id, bool isTracking = true)
        {
            return await GetByIdComplied(_context, id, isTracking);
        }

        public async Task<T> GetFirst(bool isTracking = true)
        {
            return await GetFirstComplied(_context, isTracking);
        }

        public async Task<T> GetFirstByExpression(Expression<Func<T, bool>> expression, bool isTracking = true)
        {
            return await GetFirstByExpressionComplied(_context, expression, isTracking);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression, bool isTracking = true)
        {
            var result = Entity.Where(expression);
            if (!isTracking) result = result.AsNoTracking();
            return result;
        }
    }
}
