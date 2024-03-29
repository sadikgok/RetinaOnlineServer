﻿
using MediatR;
using RetinaOnlineServer.Application.Services.AppServices;

namespace RetinaOnlineServer.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
    public sealed class MigrateCompanyDatabasesHandler : IRequestHandler<MigrateCompanyDatabasesRequest, MigrateCompanyDatabasesResponse>
    {
        private readonly ICompanyService _companyService;

        public MigrateCompanyDatabasesHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<MigrateCompanyDatabasesResponse> Handle(MigrateCompanyDatabasesRequest request, CancellationToken cancellationToken)
        {
            await _companyService.MigrateCompanyDatabases();
            return new();
        }
    }
}
