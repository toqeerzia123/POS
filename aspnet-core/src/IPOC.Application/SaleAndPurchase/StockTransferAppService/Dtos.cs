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
    public string InvoiceNumber { get; set; }
    public string ProductName { get; set; }
    public string ProductCategory { get; set; }
    public Product Product { get; set; }
}
public class StockTransferInvoiceDto
{
    public string InvoiceNo { get; set; }
    public DateTime TransferDate { get; set; }
    public int TotalQuantity { get; set; }
    public string TransferFrom { get; set; }
    public string Status { get; set; }
    public List<StockTransferProductDto> Products { get; set; }
}

public class StockTransferProductDto
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public string ProductCategory { get; set; }
    public int Quantity { get; set; }
}

public class CreateUpdateStockTransferDto
{
    public Guid ProductId { get; set; }
    public Guid FromLocationId { get; set; }
    public Guid ToLocationId { get; set; }
    public int Quantity { get; set; }
    public DateTime TransferDate { get; set; }
    public string InvoiceNumber { get; set; }
    public string Status { get; set; }
}
