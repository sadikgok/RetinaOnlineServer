using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RetinaOnlineServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using RetinaOnlineServer.Application.Services.AppServices;
using RetinaOnlineServer.Domain.AppEntities;
using RetinaOnlineServer.Persistance.Context;

namespace RetinaOnlineServer.Persistance.Services.AppServices
{
    public sealed class CompanyServices : ICompanyService
    {
        private static readonly Func<AppDbContext, string, Task<Company?>> GetCompanyByNameCompiled = EF.CompileAsyncQuery((AppDbContext contex, string name) => contex.Set<Company>().FirstOrDefault(p => p.Name == name));

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CompanyServices(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateCompany(CreateCompanyRequest request)
        {
            Company company = _mapper.Map<Company>(request);
            company.Id = Guid.NewGuid().ToString();
            await _context.Set<Company>().AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task<Company?> GetCompanyByName(string name)
        {
            return await GetCompanyByNameCompiled(_context, name);
        }

        public async Task MigrateCompanyDatabases()
        {
            var companies = await _context.Set<Company>().ToListAsync();
            foreach (var company in companies)
            {
                var db = new CompanyDbContext(company);
                db.Database.Migrate();
            }
        }
    }
}
