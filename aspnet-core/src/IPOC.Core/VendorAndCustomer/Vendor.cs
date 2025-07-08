using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace IPOC.VendorAndCustomer;
public class Vendor : FullAuditedEntity<Guid>
{
    public string Name { get; set; }
    public string ContactInfo { get; set; }
}
