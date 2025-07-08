using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;

namespace IPOC.POSManagement.PosSettingService;
public interface IPosSettingAppService : IApplicationService
{
    Task<PosSettingDto> GetAsync(Guid id);
    Task<List<PosSettingDto>> GetAllAsync();
    Task<PosSettingDto> CreateAsync(CreateUpdatePosSettingDto input);
    Task<PosSettingDto> UpdateAsync(Guid id, CreateUpdatePosSettingDto input);
    Task DeleteAsync(Guid id);
}
