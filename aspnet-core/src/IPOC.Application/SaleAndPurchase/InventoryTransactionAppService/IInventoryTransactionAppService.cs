using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPOC.SaleAndPurchase.InventoryTransactionAppService;
public interface IInventoryTransactionAppService
{
    Task<List<InventoryTransactionDto>> GetAllAsync();
    Task<InventoryTransactionDto> GetAsync(Guid id);
    Task<InventoryTransactionDto> CreateAsync(CreateUpdateInventoryTransactionDto input);
    Task<InventoryTransactionDto> UpdateAsync(Guid id, CreateUpdateInventoryTransactionDto input);
    Task DeleteAsync(Guid id);
}
