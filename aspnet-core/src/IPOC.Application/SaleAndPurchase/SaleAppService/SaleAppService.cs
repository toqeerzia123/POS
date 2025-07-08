using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.Timing;
using Abp.UI;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace IPOC.SaleAndPurchase.SaleAppService;
public class SaleAppService : ApplicationService, ISaleAppService
{
    private readonly IRepository<Sale, Guid> _saleRepository;
    private readonly IMapper _mapper;

    public SaleAppService(IRepository<Sale, Guid> saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<List<SaleDto>> GetAllAsync()
    {
        var items = await _saleRepository.GetAllIncluding(x => x.SaleItems).ToListAsync();
        return _mapper.Map<List<SaleDto>>(items);
    }

    public async Task<SaleDto> GetAsync(Guid id)
    {
        var entity = await _saleRepository
            .GetAllIncluding(x => x.SaleItems)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
        {
            throw new UserFriendlyException("Sale not found.");
        }

        return _mapper.Map<SaleDto>(entity);
    }

    public async Task<SaleDto> CreateAsync(CreateUpdateSaleDto input)
    {
        var entity = _mapper.Map<Sale>(input);
        entity.InvoiceNumber = "INV-" + DateTime.UtcNow.Ticks;
        entity.CreatedOn = Clock.Now;
        entity.CreatedBy = AbpSession?.UserId?.ToString() ?? "System";

        await _saleRepository.InsertAsync(entity);
        return _mapper.Map<SaleDto>(entity);
    }

    public async Task<SaleDto> UpdateAsync(Guid id, CreateUpdateSaleDto input)
    {
        var entity = await _saleRepository.GetAllIncluding(x => x.SaleItems)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
            throw new UserFriendlyException("Sale not found.");

        // Clear existing items
        entity.SaleItems.Clear();

        _mapper.Map(input, entity);
        await _saleRepository.UpdateAsync(entity);
        return _mapper.Map<SaleDto>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _saleRepository.DeleteAsync(id);
    }
}

