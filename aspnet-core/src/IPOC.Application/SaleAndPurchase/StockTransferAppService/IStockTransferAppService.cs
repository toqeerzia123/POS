using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;

namespace IPOC.SaleAndPurchase.StockTransferAppService;
public interface IStockTransferAppService : IApplicationService
{
    Task<List<StockTransferDto>> GetAllAsync();
    Task<StockTransferDto> GetAsync(Guid id);
    Task<StockTransferDto> CreateAsync(CreateUpdateStockTransferDto input);
    Task<StockTransferDto> UpdateAsync(Guid id, CreateUpdateStockTransferDto input);
    Task DeleteAsync(Guid id);
}

