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
    private readonly IMapper _mapper;

    public InventoryAppService(IRepository<Inventory, Guid> inventoryRepository, IMapper mapper)
    {
        _inventoryRepository = inventoryRepository;
        _mapper = mapper;
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
        var entity = _mapper.Map<Inventory>(input);
        entity.LastUpdated = DateTime.UtcNow;
        await _inventoryRepository.InsertAsync(entity);
        return _mapper.Map<InventoryDto>(entity);
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

