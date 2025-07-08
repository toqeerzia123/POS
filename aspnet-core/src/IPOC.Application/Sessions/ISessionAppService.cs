using System.Threading.Tasks;
using Abp.Application.Services;
using IPOC.Sessions.Dto;

namespace IPOC.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
