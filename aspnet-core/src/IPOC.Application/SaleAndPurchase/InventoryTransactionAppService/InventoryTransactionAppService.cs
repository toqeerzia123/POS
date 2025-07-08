using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;

namespace IPOC.SaleAndPurchase.InventoryTransactionAppService;
public class InventoryTransactionAppService : ApplicationService, IInventoryTransactionAppService
{
    private readonly IRepository<InventoryTransaction, Guid> _repository;
    private readonly IMapper _mapper;

    public InventoryTransactionAppService(
        IRepository<InventoryTransaction, Guid> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<InventoryTransactionDto>> GetAllAsync()
    {
        var list = await _repository.GetAllListAsync();
        return _mapper.Map<List<InventoryTransactionDto>>(list);
    }

    public async Task<InventoryTransactionDto> GetAsync(Guid id)
    {
        var entity = await _repository.GetAsync(id);
        return _mapper.Map<InventoryTransactionDto>(entity);
    }

    public async Task<InventoryTransactionDto> CreateAsync(CreateUpdateInventoryTransactionDto input)
    {
        var entity = _mapper.Map<InventoryTransaction>(input);
        await _repository.InsertAsync(entity);
        return _mapper.Map<InventoryTransactionDto>(entity);
    }

    public async Task<InventoryTransactionDto> UpdateAsync(Guid id, CreateUpdateInventoryTransactionDto input)
    {
        var entity = await _repository.GetAsync(id);
        _mapper.Map(input, entity);
        await _repository.UpdateAsync(entity);
        return _mapper.Map<InventoryTransactionDto>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}

