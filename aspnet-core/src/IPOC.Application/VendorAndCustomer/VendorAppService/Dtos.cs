using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPOC.VendorAndCustomer.VendorAppService;
public class VendorDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string ContactInfo { get; set; }
}

public class CreateUpdateVendorDto
{
    public string Name { get; set; }
    public string ContactInfo { get; set; }
}

