using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;

namespace IPOC.VendorAndCustomer.ClientAppService;
public class ClientAppService : ApplicationService, IClientAppService
{
    private readonly IRepository<Client, Guid> _clientRepository;
    private readonly IMapper _mapper;

    public ClientAppService(IRepository<Client, Guid> clientRepository, IMapper mapper)
    {
        _clientRepository = clientRepository;
        _mapper = mapper;
    }

    public async Task<List<ClientDto>> GetListAsync()
    {
        var clients = await _clientRepository.GetAllListAsync();
        return _mapper.Map<List<ClientDto>>(clients);
    }

    public async Task<ClientDto> GetAsync(Guid id)
    {
        var client = await _clientRepository.GetAsync(id);
        return _mapper.Map<ClientDto>(client);
    }

    public async Task<ClientDto> CreateAsync(CreateUpdateClientDto input)
    {
        var client = _mapper.Map<Client>(input);
        await _clientRepository.InsertAsync(client);
        return _mapper.Map<ClientDto>(client);
    }

    public async Task<ClientDto> UpdateAsync(Guid id, CreateUpdateClientDto input)
    {
        var client = await _clientRepository.GetAsync(id);
        _mapper.Map(input, client);
        await _clientRepository.UpdateAsync(client);
        return _mapper.Map<ClientDto>(client);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _clientRepository.DeleteAsync(id);
    }
}

