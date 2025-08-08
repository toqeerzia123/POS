using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
namespace IPOC;
public class BarCode : FullAuditedEntity<Guid>
{
  
    // The actual barcode string (e.g., "1234567890128")
  
    public string BarcodeValue { get; set; }

    // Optional: to support multiple barcodes per product
    public Guid? ProductId { get; set; }
    public Product Product { get; set; }


    public string BarcodeType { get; set; } = "Code128";

    // Flag to know whether it's used or still available
    public bool IsAssigned { get; set; }

}
