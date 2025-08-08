using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace IPOC;
public class Category: FullAuditedEntity<Guid>
{

    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
    public ICollection<Product> Products { get; set; }
    public ICollection<CategoryImage> CategoryImages { get; set; }

    // Self-referencing for subcategories
    public Guid? ParentCategoryId { get; set; } // null means it's a top-level category
    public Category? ParentCategory { get; set; }
    public ICollection<Category> Subcategories { get; set; }

}
