using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using IPOC.POSManagement.LocationService.Dto;

namespace IPOC.POSManagement.LocationService;
public interface ILocationAppService:IApplicationService
{
    Task<LocationDto> GetAsync(Guid id);
    Task<List<LocationDto>> GetAllAsync();
    Task<LocationDto> CreateAsync(CreateUpdateLocationDto input);
    Task<LocationDto> UpdateAsync(Guid id, CreateUpdateLocationDto input);
    Task DeleteAsync(Guid id);
}
