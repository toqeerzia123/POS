using Abp.Application.Services;
using IPOC.MultiTenancy.Dto;

namespace IPOC.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

