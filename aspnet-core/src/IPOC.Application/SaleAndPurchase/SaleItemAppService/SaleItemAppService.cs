using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using IPOC.SaleAndPurchase.SaleAppService;

namespace IPOC.SaleAndPurchase.SaleItemAppService;
public class SaleItemAppService : ApplicationService, ISaleItemAppService
{
    private readonly IRepository<SaleItem, Guid> _saleItemRepository;
    private readonly IMapper _mapper;

    public SaleItemAppService(IRepository<SaleItem, Guid> saleItemRepository, IMapper mapper)
    {
        _saleItemRepository = saleItemRepository;
        _mapper = mapper;
    }

    public async Task<List<SaleItemDto>> GetAllAsync()
    {
        var items = await _saleItemRepository.GetAllListAsync();
        return _mapper.Map<List<SaleItemDto>>(items);
    }

    public async Task<SaleItemDto> GetAsync(Guid id)
    {
        var item = await _saleItemRepository.GetAsync(id);
        return _mapper.Map<SaleItemDto>(item);
    }

    public async Task<SaleItemDto> CreateAsync(CreateUpdateSaleItemDto input)
    {
        var entity = _mapper.Map<SaleItem>(input);
        await _saleItemRepository.InsertAsync(entity);
        return _mapper.Map<SaleItemDto>(entity);
    }

    public async Task<SaleItemDto> UpdateAsync(Guid id, CreateUpdateSaleItemDto input)
    {
        var entity = await _saleItemRepository.GetAsync(id);
        _mapper.Map(input, entity);
        await _saleItemRepository.UpdateAsync(entity);
        return _mapper.Map<SaleItemDto>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _saleItemRepository.DeleteAsync(id);
    }
}

