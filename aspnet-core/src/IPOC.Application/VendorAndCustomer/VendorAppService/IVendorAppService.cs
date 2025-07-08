using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPOC.VendorAndCustomer.VendorAppService;
public interface IVendorAppService
{
    Task<List<VendorDto>> GetAllAsync();
    Task<VendorDto> GetAsync(Guid id);
    Task<VendorDto> CreateAsync(CreateUpdateVendorDto input);
    Task<VendorDto> UpdateAsync(Guid id, CreateUpdateVendorDto input);
    Task DeleteAsync(Guid id);
}

