using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;

namespace IPOC.POSManagement.PosSettingService;
public class PosSettingAppService : ApplicationService, IPosSettingAppService
{
    private readonly IRepository<PosSetting, Guid> _posSettingRepository;

    public PosSettingAppService(IRepository<PosSetting, Guid> posSettingRepository)
    {
        _posSettingRepository = posSettingRepository;
    }

    public async Task<List<PosSettingDto>> GetAllAsync()
    {
        var items = await _posSettingRepository.GetAllListAsync();
        return ObjectMapper.Map<List<PosSettingDto>>(items);
    }

    public async Task<PosSettingDto> GetAsync(Guid id)
    {
        var item = await _posSettingRepository.GetAsync(id);
        return ObjectMapper.Map<PosSettingDto>(item);
    }

    public async Task<PosSettingDto> CreateAsync(CreateUpdatePosSettingDto input)
    {
        var entity = ObjectMapper.Map<PosSetting>(input);
        await _posSettingRepository.InsertAsync(entity);
        return ObjectMapper.Map<PosSettingDto>(entity);
    }

    public async Task<PosSettingDto> UpdateAsync(Guid id, CreateUpdatePosSettingDto input)
    {
        var entity = await _posSettingRepository.GetAsync(id);
        ObjectMapper.Map(input, entity);
        await _posSettingRepository.UpdateAsync(entity);
        return ObjectMapper.Map<PosSettingDto>(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _posSettingRepository.DeleteAsync(id);
    }
}

