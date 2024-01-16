using MediatR;

namespace RetinaOnlineServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF
{
    public sealed class CreateUCAFHandler : IRequestHandler<CreateUCAFRequest, CreateUCAFResponse>
    {
        private readonly IUCAFService _service;

        public CreateUCAFHandler(IUCAFService service)
        {
            _service = service;
        }

        public async Task<CreateUCAFResponse> Handle(CreateUCAFRequest request, CancellationToken cancellationToken)
        {
            await _service.CreateUcafAsync(request);
            return new();
        }
    }
}
