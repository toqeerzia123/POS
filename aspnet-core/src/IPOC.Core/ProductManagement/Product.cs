using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;


namespace IPOC;
public class Product : FullAuditedEntity<Guid>
{

    public string ProductCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; }
    public string Barcode { get; set; } = string.Empty;
    public Guid CategoryId { get; set; }
    public virtual Category Category { get; set; }  // navigation
    public string Unit { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool IsActive { get; set; } = true;
    public string? Description { get; set; }
    public ICollection<ProductImage> ProductImages { get; set; }
    public ICollection<BarCode> Barcodes { get; set; }
}
