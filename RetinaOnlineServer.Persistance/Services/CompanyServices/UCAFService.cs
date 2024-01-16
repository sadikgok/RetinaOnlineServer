using AutoMapper;
using RetinaOnlineServer.Application.Features.CompanyFeatures;
using RetinaOnlineServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using RetinaOnlineServer.Domain;
using RetinaOnlineServer.Domain.CompanyEntities;
using RetinaOnlineServer.Domain.Repositories.UCAFRepositories;
using RetinaOnlineServer.Persistance.Context;

namespace RetinaOnlineServer.Persistance.Services.CompanyServices
{
    public sealed class UCAFService : IUCAFService
    {
        private readonly IUCAFCommandRepository _commandRepository;
        private readonly IContextService _contextService;
        private CompanyDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UCAFService(IUCAFCommandRepository commandRepository, IContextService contextService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _commandRepository = commandRepository;
            _contextService = contextService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateUcafAsync(CreateUCAFRequest request)
        {
            _context = (CompanyDbContext)_contextService.CreateContextInstance(request.CompanyId);
            _commandRepository.SetDbContexInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);
            UniformChartOfAccount uniformChartOfAccount = _mapper.Map<UniformChartOfAccount>(request);
            uniformChartOfAccount.Id = Guid.NewGuid().ToString();
            await _commandRepository.AddAsync(uniformChartOfAccount);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
