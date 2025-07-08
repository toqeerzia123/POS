using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace IPOC.VendorAndCustomer;
public class VendorLedgerEntry:FullAuditedEntity<Guid>
{
    public Guid VendorId { get; set; }
    public DateTime EntryDate { get; set; }

    public decimal Amount { get; set; }  // +ve for purchases (debit), -ve for payments (credit)
    public string TransactionType { get; set; }  // e.g., "Purchase", "Payment", "Adjustment"
    public string ReferenceNumber { get; set; }  // PO number, Invoice number, Payment ref, etc.
    public string Description { get; set; }
}
