using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace IPOC.SaleAndPurchase.StockTransferAppService;
public class StockTransferAppService : ApplicationService, IStockTransferAppService
{
    private readonly IRepository<StockTransfer, Guid> _stockTransferRepository;
    private readonly IMapper _mapper;

    public StockTransferAppService(IRepository<StockTransfer, Guid> stockTransferRepository, IMapper mapper)
    {
        _stockTransferRepository = stockTransferRepository;
        _mapper = mapper;
    }

    public async Task<List<StockTransferInvoiceDto>> GetAllAsync()
    {
        try
        {
            var result = await _stockTransferRepository.GetAll()
        .Include(st => st.Product)
            .ThenInclude(p => p.Category)
        .Include(st => st.FromLocation)
        .GroupBy(st => new
        {
            st.InvoiceNumber,
            TransferFrom = st.FromLocation.Name
        })
        .Select(g => new StockTransferInvoiceDto
        {
            InvoiceNo = g.Key.InvoiceNumber,
            // Pick a single date from the group (e.g., min or max)
            TransferDate = g.Min(x => x.TransferDate),
            TotalQuantity = g.Sum(x => x.Quantity),
            TransferFrom = g.Key.TransferFrom,
            Status=g.FirstOrDefault().Status,
           
            Products = g
                .GroupBy(p => new
                {
                    p.ProductId,
                    ProductName = p.Product.Name,
                    ProductCategory = p.Product.Category.Name
                })
                .Select(pg => new StockTransferProductDto
                {
                    ProductId = pg.Key.ProductId,
                    ProductName = pg.Key.ProductName,
                    ProductCategory = pg.Key.ProductCategory,
                    Quantity = pg.Sum(x => x.Quantity)
                }).ToList()
        })
        .ToListAsync();


            return result;

        }
        catch (Exception ex)
        {

            throw;
        }
   
        
    }

    public async Task<StockTransferDto> GetAsync(Guid id)
    {
        var entity = await _stockTransferRepository.GetAsync(id);
        return _mapper.Map<StockTransferDto>(entity);
    }

    public async Task<StockTransferDto> CreateAsync(List<CreateUpdateStockTransferDto> input)
    {
        try
        {
            input.ForEach(x =>
            {
                x.TransferDate = DateTime.Now;
                x.Status = "INPROGRESS";
            });
            var entity = _mapper.Map<List<StockTransfer>>(input);
             _stockTransferRepository.InsertRange(entity);
         
            return _mapper.Map<StockTransferDto>(entity.FirstOrDefault());
        }
        catch (Exception ex)
        {

            throw;
        }
       
    }

    public async Task<StockTransferDto> UpdateAsync(Guid id, CreateUpdateStockTransferDto input)
    {
        var entity = await _stockTransferRepository.GetAsync(id);
        _mapper.Map(input, entity);
        await _stockTransferRepository.UpdateAsync(entity);
        return _mapper.Map<StockTransferDto>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _stockTransferRepository.DeleteAsync(id);
    }
}

