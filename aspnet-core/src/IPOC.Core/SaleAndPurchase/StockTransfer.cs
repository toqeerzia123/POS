using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace IPOC.SaleAndPurchase;
public class StockTransfer:FullAuditedEntity<Guid>
{
    public Guid ProductId { get; set; }
    public Guid FromLocationId { get; set; }
    public Guid ToLocationId { get; set; }
    public int Quantity { get; set; }
    public DateTime TransferDate { get; set; }
}
