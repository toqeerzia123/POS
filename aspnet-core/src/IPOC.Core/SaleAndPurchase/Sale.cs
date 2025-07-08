using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using IPOC.Enums;
using IPOC.VendorAndCustomer;

namespace IPOC.SaleAndPurchase;
public class Sale:FullAuditedEntity<Guid>
{
    public DateTime SaleDate { get; set; }
    public string InvoiceNumber { get; set; }  // Auto-generated unique invoice no.
    public Guid? ClientId { get; set; }       // <-- Association here
    public Client Client { get; set; }        // Optional navigation property
    public decimal TotalAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal NetAmount { get; set; }     // Total - Discounts + Tax
    public decimal AmountPaid { get; set; }
    public decimal ChangeReturned { get; set; }

    public PaymentMethod PaymentMethod { get; set; } // Enum: Cash, Card, etc.
    public string Notes { get; set; }

    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }

    public List<SaleItem> SaleItems { get; set; } = new();
}
