using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPOC.VendorAndCustomer.ClientLedgerAppService;

namespace IPOC.Reports;
public class SalesSummaryDto
{
    public DateTime Date { get; set; }
    public decimal TotalSales { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal NetRevenue { get; set; }
}

public class ProductSalesDto
{
    public Guid ProductId { get; set; }
    public int QuantitySold { get; set; }
    public decimal TotalRevenue { get; set; }
}

public class CategorySalesDto
{
    public Guid CategoryId { get; set; }
    public int QuantitySold { get; set; }
    public decimal TotalRevenue { get; set; }
}

public class LocationSalesDto
{
    public string Location { get; set; }
    public decimal NetSales { get; set; }
}

public class ClientLedgerReportDto
{
    public Guid ClientId { get; set; }
    public List<ClientLedgerDto> Entries { get; set; }
    public decimal ClosingBalance { get; set; }
}

public class StockLevelDto
{
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public int Available { get; set; }
    public int Reserved { get; set; }
}



