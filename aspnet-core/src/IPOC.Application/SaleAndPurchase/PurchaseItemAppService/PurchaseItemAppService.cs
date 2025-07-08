using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using IPOC.SaleAndPurchase.PurchaseAppService;

namespace IPOC.SaleAndPurchase.PurchaseItemAppService;
public class PurchaseItemAppService : ApplicationService, IPurchaseItemAppService
{
    private readonly IRepository<PurchaseItem, Guid> _purchaseItemRepository;
    private readonly IMapper _mapper;

    public PurchaseItemAppService(IRepository<PurchaseItem, Guid> purchaseItemRepository, IMapper mapper)
    {
        _purchaseItemRepository = purchaseItemRepository;
        _mapper = mapper;
    }

    //public async Task<List<PurchaseItemDto>> GetAllAsync()
    //{
    //    var items = await _purchaseItemRepository.GetAllListAsync();
    //    return _mapper.Map<List<PurchaseItemDto>>(items);
    //}

    public async Task<PurchaseItemDto> GetAsync(Guid id)
    {
        var item = await _purchaseItemRepository.GetAsync(id);
        return _mapper.Map<PurchaseItemDto>(item);
    }

    public async Task<PurchaseItemDto> CreateAsync(CreateUpdatePurchaseItemDto input)
    {
        var entity = _mapper.Map<PurchaseItem>(input);
        await _purchaseItemRepository.InsertAsync(entity);
        return _mapper.Map<PurchaseItemDto>(entity);
    }

    public async Task<PurchaseItemDto> UpdateAsync(Guid id, CreateUpdatePurchaseItemDto input)
    {
        var entity = await _purchaseItemRepository.GetAsync(id);
        _mapper.Map(input, entity);
        await _purchaseItemRepository.UpdateAsync(entity);
        return _mapper.Map<PurchaseItemDto>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _purchaseItemRepository.DeleteAsync(id);
    }
}

