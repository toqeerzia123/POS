using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPOC.VendorAndCustomer.VendorLedgerService;
public class VendorLedgerEntryDto
{
    public Guid Id { get; set; }
    public Guid VendorId { get; set; }
    public DateTime EntryDate { get; set; }
    public decimal Amount { get; set; }
    public string TransactionType { get; set; }
    public string ReferenceNumber { get; set; }
    public string Description { get; set; }
}

public class CreateUpdateVendorLedgerEntryDto
{
    public Guid VendorId { get; set; }
    public DateTime EntryDate { get; set; }
    public decimal Amount { get; set; }
    public string TransactionType { get; set; }
    public string ReferenceNumber { get; set; }
    public string Description { get; set; }
}

