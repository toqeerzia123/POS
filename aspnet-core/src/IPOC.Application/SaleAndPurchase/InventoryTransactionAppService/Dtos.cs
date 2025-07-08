using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPOC.Enums;

namespace IPOC.SaleAndPurchase.InventoryTransactionAppService;
public class InventoryTransactionDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public InventoryTransactionType TransactionType { get; set; }
    public int QuantityChanged { get; set; }
    public DateTime TransactionDate { get; set; }
    public string Reference { get; set; }
    public string Reason { get; set; }
}

public class CreateUpdateInventoryTransactionDto
{
    public Guid ProductId { get; set; }
    public InventoryTransactionType TransactionType { get; set; }
    public int QuantityChanged { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    public string Reference { get; set; }
    public string Reason { get; set; }
}

