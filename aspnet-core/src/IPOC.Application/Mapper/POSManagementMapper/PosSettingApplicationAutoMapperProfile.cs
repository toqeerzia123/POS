using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IPOC.POSManagement.PosSettingService;
using IPOC.POSManagement;

namespace IPOC.Mapper.POSManagementMapper;
public class PosSettingApplicationAutoMapperProfile : Profile
{
    public PosSettingApplicationAutoMapperProfile()
    {
        // Entity ➜ DTO
        CreateMap<PosSetting, PosSettingDto>();

        // DTO ➜ Entity (for create)
        CreateMap<CreateUpdatePosSettingDto, PosSetting>();

        // DTO ➜ Entity update: 
        // ABP’s ObjectMapper.Map(source, destination) uses this map implicitly
        // so we don’t need an explicit reverse map here unless you add members
    }
}
