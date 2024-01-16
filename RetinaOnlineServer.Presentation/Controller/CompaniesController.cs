using MediatR;
using Microsoft.AspNetCore.Mvc;
using RetinaOnlineServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using RetinaOnlineServer.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase;
using RetinaOnlineServer.Presentation.Abstraction;

namespace RetinaOnlineServer.Presentation.Controller
{

    public class CompaniesController : ApiController
    {
        public CompaniesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCompany(CreateCompanyRequest request)
        {
            CreateCompanyResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> MigrateCompanyDatabase()
        {
            MigrateCompanyDatabasesRequest request = new();
            MigrateCompanyDatabasesResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
