using System.Threading.Tasks;
using Abp.Application.Services;
using IPOC.Authorization.Accounts.Dto;

namespace IPOC.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
