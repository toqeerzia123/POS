using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace IPOC.ProductManagement.CategoryService;
public class CategoryDto : FullAuditedEntityDto<Guid>
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public List<CategoryImageDto> CategoryImages { get; set; }

    public Guid? ParentCategoryId { get; set; } // null means it's a top-level category
    public Category? ParentCategory { get; set; }
    public ICollection<Category> Subcategories { get; set; }
}

public class CreateUpdateCategoryDto
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public Guid? ParentCategoryId { get; set; } // null means it's a top-level category
    public List<CreateUpdateCategoryImageDto> CategoryImages { get; set; } = new();
}
public class CategoryImageDto : FullAuditedEntityDto<Guid>
{
    public Guid CategoryId { get; set; }
    public string ImageUrl { get; set; }
    public string AltText { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsPrimary { get; set; }
}
public class CreateUpdateCategoryImageDto
{
    public string ImageUrl { get; set; }
    public string AltText { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsPrimary { get; set; }
}

