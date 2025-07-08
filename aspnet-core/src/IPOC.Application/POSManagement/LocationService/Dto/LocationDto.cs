using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace IPOC.POSManagement.LocationService.Dto;
public class LocationDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public bool IsActive { get; set; }
}
