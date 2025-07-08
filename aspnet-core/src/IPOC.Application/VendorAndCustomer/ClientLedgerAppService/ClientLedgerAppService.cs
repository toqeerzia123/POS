using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace IPOC.VendorAndCustomer.ClientLedgerAppService;
public class ClientLedgerAppService : ApplicationService, IClientLedgerAppService
{
    private readonly IRepository<ClientLedger, Guid> _ledgerRepo;
    private readonly IRepository<Client, Guid> _clientRepo;
    private readonly IMapper _mapper;

    public ClientLedgerAppService(IRepository<ClientLedger, Guid> ledgerRepo, IRepository<Client, Guid> clientRepo, IMapper mapper)
    {
        _ledgerRepo = ledgerRepo;
        _clientRepo = clientRepo;
        _mapper = mapper;
    }

    public async Task<List<ClientLedgerDto>> GetListAsync()
    {
        var ledgers = await _ledgerRepo.GetAllIncluding(x => x.Client).ToListAsync();
        return _mapper.Map<List<ClientLedgerDto>>(ledgers);
    }

    public async Task<ClientLedgerDto> GetAsync(Guid id)
    {
        var ledger = await _ledgerRepo.GetAllIncluding(x => x.Client).FirstOrDefaultAsync(x => x.Id == id);
        return _mapper.Map<ClientLedgerDto>(ledger);
    }

    public async Task<ClientLedgerDto> CreateAsync(CreateUpdateClientLedgerDto input)
    {
        var ledger = _mapper.Map<ClientLedger>(input);
        await _ledgerRepo.InsertAsync(ledger);
        return _mapper.Map<ClientLedgerDto>(ledger);
    }

    public async Task<ClientLedgerDto> UpdateAsync(Guid id, CreateUpdateClientLedgerDto input)
    {
        var ledger = await _ledgerRepo.GetAsync(id);
        _mapper.Map(input, ledger);
        await _ledgerRepo.UpdateAsync(ledger);
        return _mapper.Map<ClientLedgerDto>(ledger);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _ledgerRepo.DeleteAsync(id);
    }
}

