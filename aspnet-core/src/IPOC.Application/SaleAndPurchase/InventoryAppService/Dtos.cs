using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPOC.SaleAndPurchase.InventoryAppService;
public class InventoryDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public Guid? LocationId { get; set; }
    public int QuantityAvailable { get; set; }
    public int QuantityReserved { get; set; }
    public DateTime LastUpdated { get; set; }
}

public class CreateUpdateInventoryDto
{
    public Guid ProductId { get; set; }
    public Guid? LocationId { get; set; }
    public int QuantityAvailable { get; set; }
    public int QuantityReserved { get; set; }
}

