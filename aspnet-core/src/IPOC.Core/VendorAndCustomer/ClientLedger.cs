using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace IPOC.VendorAndCustomer;
public class ClientLedger:FullAuditedEntity<Guid>
{
    public Guid ClientId { get; set; }
    public Client Client { get; set; }

    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

    public string ReferenceType { get; set; } // e.g., "SALE", "PAYMENT", "REFUND"
    public Guid? ReferenceId { get; set; }    // e.g., SaleId or PaymentId

    public decimal Debit { get; set; } = 0;   // Amount owed by client (e.g., a sale)
    public decimal Credit { get; set; } = 0;  // Amount paid by client
    public decimal Balance { get; set; }      // Running balance (can also be calculated)

    public string Description { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}
