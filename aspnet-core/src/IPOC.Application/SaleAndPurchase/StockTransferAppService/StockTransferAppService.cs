using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;

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

    public async Task<List<StockTransferDto>> GetAllAsync()
    {
        var items = await _stockTransferRepository.GetAllListAsync();
        return _mapper.Map<List<StockTransferDto>>(items);
    }

    public async Task<StockTransferDto> GetAsync(Guid id)
    {
        var entity = await _stockTransferRepository.GetAsync(id);
        return _mapper.Map<StockTransferDto>(entity);
    }

    public async Task<StockTransferDto> CreateAsync(CreateUpdateStockTransferDto input)
    {
        var entity = _mapper.Map<StockTransfer>(input);
        await _stockTransferRepository.InsertAsync(entity);
        return _mapper.Map<StockTransferDto>(entity);
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

