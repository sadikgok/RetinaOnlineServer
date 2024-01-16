using AutoMapper;
using RetinaOnlineServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using RetinaOnlineServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using RetinaOnlineServer.Domain.AppEntities;
using RetinaOnlineServer.Domain.CompanyEntities;

namespace RetinaOnlineServer.Persistance.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyRequest, Company>().ReverseMap();
            CreateMap<CreateUCAFRequest, UniformChartOfAccount>().ReverseMap();
        }
    }
}
