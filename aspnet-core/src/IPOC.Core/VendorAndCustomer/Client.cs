using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace IPOC.VendorAndCustomer;
public class Client:FullAuditedEntity<Guid>
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public bool IsActive { get; set; }
}
