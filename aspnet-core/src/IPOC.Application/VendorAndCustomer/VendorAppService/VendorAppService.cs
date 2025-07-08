using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper;

namespace IPOC.VendorAndCustomer.VendorAppService;
public class VendorAppService : ApplicationService, IVendorAppService
{
    private readonly IRepository<Vendor, Guid> _vendorRepository;
    private readonly IMapper _mapper;

    public VendorAppService(IRepository<Vendor, Guid> vendorRepository, IMapper mapper)
    {
        _vendorRepository = vendorRepository;
        _mapper = mapper;
    }

    public async Task<List<VendorDto>> GetAllAsync()
    {
        var vendors = await _vendorRepository.GetAllListAsync();
        return _mapper.Map<List<VendorDto>>(vendors);
    }

    public async Task<VendorDto> GetAsync(Guid id)
    {
        var vendor = await _vendorRepository.GetAsync(id);
        return _mapper.Map<VendorDto>(vendor);
    }

    public async Task<VendorDto> CreateAsync(CreateUpdateVendorDto input)
    {
        var entity = _mapper.Map<Vendor>(input);
        await _vendorRepository.InsertAsync(entity);
        return _mapper.Map<VendorDto>(entity);
    }

    public async Task<VendorDto> UpdateAsync(Guid id, CreateUpdateVendorDto input)
    {
        var entity = await _vendorRepository.GetAsync(id);
        _mapper.Map(input, entity);
        await _vendorRepository.UpdateAsync(entity);
        return _mapper.Map<VendorDto>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _vendorRepository.DeleteAsync(id);
    }
}

