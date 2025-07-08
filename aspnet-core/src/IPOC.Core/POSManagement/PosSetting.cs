using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace IPOC.POSManagement;
public class PosSetting:FullAuditedEntity<Guid>
{
    public Guid LocationId { get; set; }             // Or POS Id, for multi-POS per location
    public string Name { get; set; }                 // e.g., "Toqeer's SuperMart"
    public string LogoUrl { get; set; }              // Path to logo image
    public string FooterText { get; set; }           // For receipts/invoices
    public string Address { get; set; }
    public string Version { get; set; }
    public string ThemeColor { get; set; }           // Optional: "#ff0000"
    public bool IsActive { get; set; }
}
