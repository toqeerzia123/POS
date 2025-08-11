using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;

namespace IPOC.SaleAndPurchase.InventoryAppService;
public class InventoryAppService : ApplicationService, IInventoryAppService
{
    private readonly IRepository<Inventory, Guid> _inventoryRepository;
    private readonly IRepository<StockTransfer, Guid> _stockTransferRepository;
    private readonly IMapper _mapper;

    public InventoryAppService(IRepository<Inventory, Guid> inventoryRepository, IMapper mapper, IRepository<StockTransfer, Guid> stockTransferRepository)
    {
        _inventoryRepository = inventoryRepository;
        _mapper = mapper;
        _stockTransferRepository = stockTransferRepository;
    }

    public async Task<List<InventoryDto>> GetAllAsync()
    {
        var items = await _inventoryRepository.GetAllListAsync();
        return _mapper.Map<List<InventoryDto>>(items);
    }

    public async Task<InventoryDto> GetAsync(Guid id)
    {
        var entity = await _inventoryRepository.GetAsync(id);
        return _mapper.Map<InventoryDto>(entity);
    }

    public async Task<InventoryDto> CreateAsync(CreateUpdateInventoryDto input)
    {
        var alldata = _stockTransferRepository.GetAllList(x=>x.InvoiceNumber==input.InvoiceId && x.ToLocationId==input.LocationId);
        foreach (var item in alldata)
        {
            var checkInventory =await _inventoryRepository.FirstOrDefaultAsync(x=>x.ProductId==item.ProductId);
            if (checkInventory !=null)
            {
                checkInventory.QuantityAvailable = checkInventory.QuantityAvailable + item.Quantity;
              await  _inventoryRepository.UpdateAsync(checkInventory);
            }
            else
            {
                Inventory inventory = new Inventory { ProductId=item.ProductId,QuantityAvailable=item.Quantity,LocationId=item.ToLocationId,LastUpdated=DateTime.Now};
                await _inventoryRepository.InsertAsync(inventory);

            }
            item.Status = "TRANSFERED";
           await _stockTransferRepository.UpdateAsync(item);
        }
      
        return _mapper.Map<InventoryDto>(null);
    }

    public async Task<InventoryDto> UpdateAsync(Guid id, CreateUpdateInventoryDto input)
    {
        var entity = await _inventoryRepository.GetAsync(id);
        _mapper.Map(input, entity);
        entity.LastUpdated = DateTime.UtcNow;
        await _inventoryRepository.UpdateAsync(entity);
        return _mapper.Map<InventoryDto>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _inventoryRepository.DeleteAsync(id);
    }
}

