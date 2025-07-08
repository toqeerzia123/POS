using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using AutoMapper.Internal.Mappers;
using IPOC.SaleAndPurchase;
using IPOC.SaleAndPurchase.StockTransferAppService;
using IPOC.VendorAndCustomer;
using IPOC.VendorAndCustomer.ClientLedgerAppService;
using Microsoft.EntityFrameworkCore;

namespace IPOC.Reports;
public class ReportAppService : ApplicationService, IReportAppService
{
    private readonly IRepository<Sale, Guid> _saleRepo;
    private readonly IRepository<SaleItem, Guid> _saleItemRepo;
    private readonly IRepository<ClientLedger, Guid> _clientLedgerRepo;
    private readonly IRepository<Product, Guid> _productRepo;
    private readonly IRepository<StockTransfer, Guid> _stockTransferRepo;
    private readonly IMapper _mapper;

    public ReportAppService(
        IRepository<Sale, Guid> saleRepo,
        IRepository<SaleItem, Guid> saleItemRepo,
        IRepository<ClientLedger, Guid> clientLedgerRepo,
        IRepository<Product, Guid> productRepo,
        IRepository<StockTransfer, Guid> stockTransferRepo,
        IMapper mapper)
    {
        _saleRepo = saleRepo;
        _saleItemRepo = saleItemRepo;
        _clientLedgerRepo = clientLedgerRepo;
        _productRepo = productRepo;
        _stockTransferRepo = stockTransferRepo;
        _mapper = mapper;
    }

    public async Task<List<SalesSummaryDto>> GetDailySalesAsync(DateTime start, DateTime end)
    {
        var sales = await _saleRepo.GetAll()
            .Where(x => x.SaleDate >= start && x.SaleDate <= end)
            .GroupBy(x => x.SaleDate.Date)
            .Select(g => new SalesSummaryDto
            {
                Date = g.Key,
                TotalSales = g.Sum(x => x.TotalAmount),
                TotalDiscount = g.Sum(x => x.DiscountAmount),
                NetRevenue = g.Sum(x => x.NetAmount)
            }).ToListAsync();

        return sales;
    }

    public async Task<List<ProductSalesDto>> GetSalesByProductAsync(DateTime start, DateTime end)
    {
        var sales = await _saleItemRepo.GetAll()
            .Where(x => x.CreationTime >= start && x.CreationTime <= end)
            .GroupBy(x => x.ProductId)
            .Select(g => new ProductSalesDto
            {
                ProductId = g.Key,
                QuantitySold = g.Sum(x => x.Quantity),
                TotalRevenue = g.Sum(x => x.TotalPrice)
            }).ToListAsync();

        return sales;
    }

    public async Task<List<CategorySalesDto>> GetSalesByCategoryAsync(DateTime start, DateTime end)
    {
        var sales = await (from si in _saleItemRepo.GetAll()
                           join p in _productRepo.GetAll() on si.ProductId equals p.Id
                           where si.CreationTime >= start && si.CreationTime <= end
                           group si by p.CategoryId into g
                           select new CategorySalesDto
                           {
                               CategoryId = g.Key,
                               QuantitySold = g.Sum(x => x.Quantity),
                               TotalRevenue = g.Sum(x => x.TotalPrice)
                           }).ToListAsync();

        return sales;
    }

    public async Task<List<LocationSalesDto>> GetSalesByLocationAsync(DateTime start, DateTime end)
    {
        // Assuming Sales table has LocationId
        var sales = await _saleRepo.GetAll()
            .Where(x => x.SaleDate >= start && x.SaleDate <= end)
            .GroupBy(x => x.CreatorUserId) // Or LocationId if exists
            .Select(g => new LocationSalesDto
            {
                Location = g.Key.ToString(),
                NetSales = g.Sum(x => x.NetAmount)
            }).ToListAsync();

        return sales;
    }

    public async Task<ClientLedgerReportDto> GetClientLedgerAsync(Guid clientId)
    {
        var entries = await _clientLedgerRepo.GetAll()
            .Where(x => x.ClientId == clientId)
            .OrderBy(x => x.TransactionDate)
            .ToListAsync();

        return new ClientLedgerReportDto
        {
            ClientId = clientId,
            Entries = _mapper.Map<List<ClientLedgerDto>>(entries),
            ClosingBalance = entries.LastOrDefault()?.Balance ?? 0
        };
    }

    public async Task<VendorLedgerEntry> GetVendorLedgerAsync(Guid vendorId)
    {
        // Similar to ClientLedger logic
        // ...
        throw new NotImplementedException();
    }

    public async Task<List<StockLevelDto>> GetCurrentStockAsync()
    {
        var products = await _productRepo.GetAll()
            .Select(p => new StockLevelDto
            {
                ProductId = p.Id,
                ProductName = p.Name,
             //   Available = p.Inventory.QuantityAvailable,
             //   Reserved = p.Inventory.QuantityReserved
            }).ToListAsync();

        return products;
    }

    public async Task<List<StockTransferDto>> GetStockTransfersAsync(DateTime start, DateTime end)
    {
        var transfers = await _stockTransferRepo.GetAll()
            .Where(x => x.TransferDate >= start && x.TransferDate <= end)
            .Select(x => new StockTransferDto
            {
                ProductId = x.ProductId,
                FromLocationId = x.FromLocationId,
                ToLocationId = x.ToLocationId,
                Quantity = x.Quantity,
                TransferDate = x.TransferDate
            }).ToListAsync();

        return transfers;
    }

    Task<ClientLedgerDto> IReportAppService.GetVendorLedgerAsync(Guid vendorId)
    {
        throw new NotImplementedException();
    }
}
