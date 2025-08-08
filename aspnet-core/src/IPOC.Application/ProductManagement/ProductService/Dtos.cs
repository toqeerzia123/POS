using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using IPOC.ProductManagement.CategoryService;
using Microsoft.AspNetCore.Http;

namespace IPOC.ProductManagement.ProductService;
public class CreateUpdateProductDto
{
    public string ProductCode { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Barcode { get; set; }
    public Guid CategoryId { get; set; }
    public string Unit { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public string? Description { get; set; }
    public List<CreateUpdateProductImageDto> ProductImages { get; set; } = new();
}
public class ProductDto : FullAuditedEntityDto<Guid>
{
    public string ProductCode { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Barcode { get; set; }
    public Guid CategoryId { get; set; }
    public string Unit { get; set; }
    public CategoryDto Category { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public string? Description { get; set; }

    public List<ProductImageDto> ProductImages { get; set; }
}

public class ProductImageDto : FullAuditedEntityDto<Guid>
{
    public Guid ProductId { get; set; }
    public string ImageUrl { get; set; }
    public string AltText { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsPrimary { get; set; }
}
public class CreateUpdateProductImageDto
{
    public IFormFile ImageUrl { get; set; }
    public string AltText { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsPrimary { get; set; }
}


