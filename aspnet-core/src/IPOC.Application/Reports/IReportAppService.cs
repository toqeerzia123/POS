using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using IPOC.SaleAndPurchase.StockTransferAppService;
using IPOC.VendorAndCustomer.ClientLedgerAppService;

namespace IPOC.Reports;
public interface IReportAppService : IApplicationService
{
    Task<List<SalesSummaryDto>> GetDailySalesAsync(DateTime start, DateTime end);
    Task<List<ProductSalesDto>> GetSalesByProductAsync(DateTime start, DateTime end);
    Task<List<CategorySalesDto>> GetSalesByCategoryAsync(DateTime start, DateTime end);
    Task<List<LocationSalesDto>> GetSalesByLocationAsync(DateTime start, DateTime end);

    Task<ClientLedgerReportDto> GetClientLedgerAsync(Guid clientId);
    Task<ClientLedgerDto> GetVendorLedgerAsync(Guid vendorId);

    Task<List<StockLevelDto>> GetCurrentStockAsync();
    Task<List<StockTransferDto>> GetStockTransfersAsync(DateTime start, DateTime end);
}
