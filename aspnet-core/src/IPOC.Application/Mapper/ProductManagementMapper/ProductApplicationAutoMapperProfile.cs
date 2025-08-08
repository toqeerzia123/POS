using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IPOC.ProductManagement.BarcodeService;
using IPOC.ProductManagement.CategoryService;
using IPOC.ProductManagement.ProductService;

namespace IPOC.Mapper.ProductManagementMapper;
public class CategoryApplicationAutoMapperProfile : Profile
{
    public CategoryApplicationAutoMapperProfile()
    {
        //Category
        CreateMap<Category, CategoryDto>().ForMember(dest => dest.ParentCategory, opt => opt.MapFrom(src => src.ParentCategory));
        CreateMap<CategoryImage, CategoryImageDto>();
        CreateMap<CreateUpdateCategoryDto, Category>();
        CreateMap<CreateUpdateCategoryImageDto, CategoryImage>();

        // Product
        CreateMap<Product, ProductDto>();
        CreateMap<ProductImage, ProductImageDto>();
        CreateMap<CreateUpdateProductDto, Product>();
        CreateMap<CreateUpdateProductImageDto, ProductImage>();

        // Barcode
        CreateMap<BarCode, BarCodeDto>();
        CreateMap<BarCodeDto, BarCode>();
        CreateMap<CreateUpdateBarCodeDto, BarCode>();
    }
}
