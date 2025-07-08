using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPOC.VendorAndCustomer.ClientAppService;
public interface IClientAppService
{
    Task<List<ClientDto>> GetListAsync();
    Task<ClientDto> GetAsync(Guid id);
    Task<ClientDto> CreateAsync(CreateUpdateClientDto input);
    Task<ClientDto> UpdateAsync(Guid id, CreateUpdateClientDto input);
    Task DeleteAsync(Guid id);
}
