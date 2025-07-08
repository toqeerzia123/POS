using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace IPOC.SaleAndPurchase;
public class InventoryTransaction:FullAuditedEntity<Guid>
{
    public Guid ProductId { get; set; }
    public string TransactionType { get; set; } // "SALE", "PURCHASE", "ADJUSTMENT"
    public int QuantityChanged { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Reference { get; set; } // Could be SaleId, PurchaseId, etc.
    public string Reason { get; set; } // e.g., "Sale", "Purchase", "Manual Adjustment"
}
