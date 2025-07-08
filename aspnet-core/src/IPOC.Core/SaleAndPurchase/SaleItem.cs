using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace IPOC.SaleAndPurchase;
public class SaleItem:FullAuditedEntity<Guid>
{
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }     // snapshot for reporting
    public string Barcode { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice => (UnitPrice * Quantity) - Discount;

    public string Unit { get; set; }            // e.g. kg, pcs
}
