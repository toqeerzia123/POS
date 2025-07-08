using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace IPOC.VendorAndCustomer.ClientAppService;
public class ClientDto : FullAuditedEntityDto<Guid>
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public bool IsActive { get; set; }
}
public class CreateUpdateClientDto
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public bool IsActive { get; set; }
}
