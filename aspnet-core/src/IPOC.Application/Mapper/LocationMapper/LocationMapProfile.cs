using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IPOC.POS;
using IPOC.POSManagement.LocationService.Dto;

namespace IPOC.Mapper;
public class LocationMapProfile : Profile
{
    public LocationMapProfile()
    {
        CreateMap<Location, LocationDto>().ReverseMap();
        CreateMap<CreateUpdateLocationDto, Location>();
    }
}
