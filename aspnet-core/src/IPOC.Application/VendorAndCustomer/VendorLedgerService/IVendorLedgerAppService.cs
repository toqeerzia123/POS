using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPOC.VendorAndCustomer.VendorLedgerService;
public interface IVendorLedgerAppService
{
    Task<List<VendorLedgerEntryDto>> GetAllAsync();
    Task<VendorLedgerEntryDto> GetAsync(Guid id);
    Task<VendorLedgerEntryDto> CreateAsync(CreateUpdateVendorLedgerEntryDto input);
    Task<VendorLedgerEntryDto> UpdateAsync(Guid id, CreateUpdateVendorLedgerEntryDto input);
    Task DeleteAsync(Guid id);
}
