using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace IPOC.SaleAndPurchase.StockTransferAppService;
public class StockTransferDto : EntityDto<Guid>
{
    public Guid ProductId { get; set; }
    public Guid FromLocationId { get; set; }
    public Guid ToLocationId { get; set; }
    public int Quantity { get; set; }
    public DateTime TransferDate { get; set; }
}

public class CreateUpdateStockTransferDto
{
    public Guid ProductId { get; set; }
    public Guid FromLocationId { get; set; }
    public Guid ToLocationId { get; set; }
    public int Quantity { get; set; }
    public DateTime TransferDate { get; set; }
}
