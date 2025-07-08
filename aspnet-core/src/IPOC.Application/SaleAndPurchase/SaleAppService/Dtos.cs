using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using IPOC.Enums;

namespace IPOC.SaleAndPurchase.SaleAppService;
public class SaleDto : EntityDto<Guid>
{
    public DateTime SaleDate { get; set; }
    public string InvoiceNumber { get; set; }
    public Guid? ClientId { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal NetAmount { get; set; }
    public decimal AmountPaid { get; set; }
    public decimal ChangeReturned { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string Notes { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }

    public List<SaleItemDto> SaleItems { get; set; }
}
public class CreateUpdateSaleDto
{
    public DateTime SaleDate { get; set; }
    public Guid? ClientId { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal NetAmount { get; set; }
    public decimal AmountPaid { get; set; }
    public decimal ChangeReturned { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public string Notes { get; set; }

    public List<CreateUpdateSaleItemDto> SaleItems { get; set; }
}
public class SaleItemDto : EntityDto<Guid>
{
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public string Barcode { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice => (UnitPrice * Quantity) - Discount;
    public string Unit { get; set; }
}

public class CreateUpdateSaleItemDto
{
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; }
    public string Barcode { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public string Unit { get; set; }
}



