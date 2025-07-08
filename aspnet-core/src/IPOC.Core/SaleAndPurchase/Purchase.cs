using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace IPOC.SaleAndPurchase;
public class Purchase:FullAuditedEntity<Guid>
{

    public DateTime PurchaseDate { get; set; }
    public Guid VendorId { get; set; }
    public decimal TotalAmount { get; set; }
    public List<PurchaseItem> Items { get; set; } = new();
}
