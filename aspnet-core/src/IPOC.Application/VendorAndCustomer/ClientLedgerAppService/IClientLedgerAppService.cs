using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPOC.VendorAndCustomer.ClientLedgerAppService;
public interface IClientLedgerAppService
{
    Task<List<ClientLedgerDto>> GetListAsync();
    Task<ClientLedgerDto> GetAsync(Guid id);
    Task<ClientLedgerDto> CreateAsync(CreateUpdateClientLedgerDto input);
    Task<ClientLedgerDto> UpdateAsync(Guid id, CreateUpdateClientLedgerDto input);
    Task DeleteAsync(Guid id);
}
