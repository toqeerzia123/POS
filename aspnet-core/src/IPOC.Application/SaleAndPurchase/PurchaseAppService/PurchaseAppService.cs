using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;

namespace IPOC.SaleAndPurchase.PurchaseAppService;
public class PurchaseAppService : ApplicationService, IPurchaseAppService
{
    private readonly IRepository<Purchase, Guid> _purchaseRepository;
    private readonly IMapper _mapper;

    public PurchaseAppService(IRepository<Purchase, Guid> purchaseRepository, IMapper mapper)
    {
        _purchaseRepository = purchaseRepository;
        _mapper = mapper;
    }

    public async Task<List<PurchaseDto>> GetAllAsync()
    {
        var purchases =  _purchaseRepository.GetAllIncluding(p => p.Items);
        return _mapper.Map<List<PurchaseDto>>(purchases);
    }

    public async Task<PurchaseDto> GetAsync(Guid id)
    {
        var purchase =  _purchaseRepository.GetAllIncluding(p => p.Items);
        var result = purchase.FirstOrDefault(p => p.Id == id);
        return _mapper.Map<PurchaseDto>(result);
    }

    public async Task<PurchaseDto> CreateAsync(CreateUpdatePurchaseDto input)
    {
        var entity = _mapper.Map<Purchase>(input);
        await _purchaseRepository.InsertAsync(entity);
        return _mapper.Map<PurchaseDto>(entity);
    }

    public async Task<PurchaseDto> UpdateAsync(Guid id, CreateUpdatePurchaseDto input)
    {
        var purchase = await _purchaseRepository.GetAsync(id);
        _mapper.Map(input, purchase);
        await _purchaseRepository.UpdateAsync(purchase);
        return _mapper.Map<PurchaseDto>(purchase);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _purchaseRepository.DeleteAsync(id);
    }
}

