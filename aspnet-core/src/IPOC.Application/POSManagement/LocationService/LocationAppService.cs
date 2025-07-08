using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;
using IPOC.POS;
using IPOC.POSManagement.LocationService.Dto;

namespace IPOC.POSManagement.LocationService;
public class LocationAppService : ApplicationService, ILocationAppService
{
    private readonly IRepository<Location, Guid> _locationRepository;

    public LocationAppService(IRepository<Location, Guid> locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<LocationDto> GetAsync(Guid id)
    {
        var entity = await _locationRepository.GetAsync(id);
        return ObjectMapper.Map<LocationDto>(entity);
    }

    public async Task<List<LocationDto>> GetAllAsync()
    {
        var items = await _locationRepository.GetAllListAsync();
        return ObjectMapper.Map<List<LocationDto>>(items);
    }

    public async Task<LocationDto> CreateAsync(CreateUpdateLocationDto input)
    {
        try
        {
            var entity = ObjectMapper.Map<Location>(input);
            await _locationRepository.InsertAsync(entity);
            return ObjectMapper.Map<LocationDto>(entity);
        }
        catch (Exception ex)
        {

            throw;
        }
     
    }

    public async Task<LocationDto> UpdateAsync(Guid id, CreateUpdateLocationDto input)
    {
        var entity = await _locationRepository.GetAsync(id);
        ObjectMapper.Map(input, entity);
        await _locationRepository.UpdateAsync(entity);
        return ObjectMapper.Map<LocationDto>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _locationRepository.DeleteAsync(id);
    }
}

