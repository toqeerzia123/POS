using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPOC.POSManagement.LocationService.Dto;
public class CreateUpdateLocationDto
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public bool IsActive { get; set; }
}
