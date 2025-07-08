using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace IPOC.VendorAndCustomer.ClientLedgerAppService;
public class ClientLedgerDto : FullAuditedEntityDto<Guid>
{
    public Guid ClientId { get; set; }
    public string ClientName { get; set; }   // Optional convenience
    public DateTime TransactionDate { get; set; }
    public string ReferenceType { get; set; }
    public Guid? ReferenceId { get; set; }
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
    public decimal Balance { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; }
}
public class CreateUpdateClientLedgerDto
{
    public Guid ClientId { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    public string ReferenceType { get; set; }
    public Guid? ReferenceId { get; set; }
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
    public decimal Balance { get; set; }
    public string Description { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}

