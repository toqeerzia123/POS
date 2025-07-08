using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPOC.SaleAndPurchase.InventoryAppService;
public interface IInventoryAppService
{
    Task<List<InventoryDto>> GetAllAsync();
    Task<InventoryDto> GetAsync(Guid id);
    Task<InventoryDto> CreateAsync(CreateUpdateInventoryDto input);
    Task<InventoryDto> UpdateAsync(Guid id, CreateUpdateInventoryDto input);
    Task DeleteAsync(Guid id);
}
