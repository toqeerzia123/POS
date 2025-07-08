using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace IPOC.SaleAndPurchase;
public class Inventory : FullAuditedEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid? LocationId { get; set; } // If multi-warehouse
    public int QuantityAvailable { get; set; }
    public int QuantityReserved { get; set; } // For pending sales
    public DateTime LastUpdated { get; set; }
}
