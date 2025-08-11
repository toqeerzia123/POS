using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using IPOC.POS;

namespace IPOC.SaleAndPurchase;
public class StockTransfer:FullAuditedEntity<Guid>
{
    public Guid ProductId { get; set; }
    public Guid FromLocationId { get; set; }
    public Guid ToLocationId { get; set; }
    public int Quantity { get; set; }
    public DateTime TransferDate { get; set; }
    public string InvoiceNumber { get; set; }
    public string Status { get; set; }

    public Product Product { get; set; }
    public Location FromLocation { get; set; }
}
