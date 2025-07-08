using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;

namespace IPOC.VendorAndCustomer.VendorLedgerService;
public class VendorLedgerAppService : ApplicationService, IVendorLedgerAppService
{
    private readonly IRepository<VendorLedgerEntry, Guid> _ledgerRepository;
    private readonly IMapper _mapper;

    public VendorLedgerAppService(IRepository<VendorLedgerEntry, Guid> ledgerRepository, IMapper mapper)
    {
        _ledgerRepository = ledgerRepository;
        _mapper = mapper;
    }

    public async Task<List<VendorLedgerEntryDto>> GetAllAsync()
    {
        var entries = await _ledgerRepository.GetAllListAsync();
        return _mapper.Map<List<VendorLedgerEntryDto>>(entries);
    }

    public async Task<VendorLedgerEntryDto> GetAsync(Guid id)
    {
        var entry = await _ledgerRepository.GetAsync(id);
        return _mapper.Map<VendorLedgerEntryDto>(entry);
    }

    public async Task<VendorLedgerEntryDto> CreateAsync(CreateUpdateVendorLedgerEntryDto input)
    {
        var entry = _mapper.Map<VendorLedgerEntry>(input);
        await _ledgerRepository.InsertAsync(entry);
        return _mapper.Map<VendorLedgerEntryDto>(entry);
    }

    public async Task<VendorLedgerEntryDto> UpdateAsync(Guid id, CreateUpdateVendorLedgerEntryDto input)
    {
        var entry = await _ledgerRepository.GetAsync(id);
        _mapper.Map(input, entry);
        await _ledgerRepository.UpdateAsync(entry);
        return _mapper.Map<VendorLedgerEntryDto>(entry);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _ledgerRepository.DeleteAsync(id);
    }
}

