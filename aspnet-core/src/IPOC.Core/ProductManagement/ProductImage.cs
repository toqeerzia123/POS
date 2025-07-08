using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace IPOC;
public class ProductImage:FullAuditedEntity<Guid>
{

    public Guid ProductId { get; set; }
    public string ImageUrl { get; set; }
    public string AltText { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsPrimary { get; set; }
}
