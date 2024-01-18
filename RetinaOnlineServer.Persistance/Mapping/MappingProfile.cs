using AutoMapper;
using RetinaOnlineServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using RetinaOnlineServer.Application.Features.CompanyFeatures.UCAFFeatures.Commands.CreateUCAF;
using RetinaOnlineServer.Application.Features.RoleFeatures.Commands.CreateRole;
using RetinaOnlineServer.Domain.AppEntities;
using RetinaOnlineServer.Domain.AppEntities.Identity;
using RetinaOnlineServer.Domain.CompanyEntities;

namespace RetinaOnlineServer.Persistance.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyRequest, Company>();
            CreateMap<CreateUCAFRequest, UniformChartOfAccount>();
            CreateMap<CreateRoleRequest, AppRole>();
        }
    }
}
