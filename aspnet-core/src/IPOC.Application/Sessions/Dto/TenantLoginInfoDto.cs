using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using IPOC.MultiTenancy;

namespace IPOC.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
