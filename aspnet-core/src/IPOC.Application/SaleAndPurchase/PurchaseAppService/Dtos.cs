using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPOC.SaleAndPurchase.PurchaseAppService;
public class PurchaseDto
{
    public Guid Id { get; set; }
    public DateTime PurchaseDate { get; set; }
    public Guid VendorId { get; set; }
    public decimal TotalAmount { get; set; }
    public List<PurchaseItemDto> Items { get; set; }
}

public class CreateUpdatePurchaseDto
{
    public DateTime PurchaseDate { get; set; }
    public Guid VendorId { get; set; }
    public decimal TotalAmount { get; set; }
    public List<CreateUpdatePurchaseItemDto> Items { get; set; }
}

public class PurchaseItemDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}

public class CreateUpdatePurchaseItemDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
