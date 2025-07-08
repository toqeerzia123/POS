using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;

namespace IPOC.ProductManagement.ProductService;
public class ProductAppService : ApplicationService, IProductAppService
{
    private readonly IRepository<Product, Guid> _productRepository;

    public ProductAppService(IRepository<Product, Guid> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllListAsync();
        return ObjectMapper.Map<List<ProductDto>>(products);
    }

    public async Task<ProductDto> GetAsync(Guid id)
    {
        var product = await _productRepository.GetAsync(id);
        return ObjectMapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
    {
        var product = ObjectMapper.Map<Product>(input);

        if (input.ProductImages?.Any() == true)
        {
            product.ProductImages = input.ProductImages
                .Select(i => ObjectMapper.Map<ProductImage>(i))
                .ToList();
        }

        await _productRepository.InsertAsync(product);
        return ObjectMapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> UpdateAsync(Guid id, CreateUpdateProductDto input)
    {
        var product = await _productRepository.GetAsync(id);

        // clear existing child images
        product.ProductImages.Clear();

        // map basic properties
        ObjectMapper.Map(input, product);

        // add new images
        if (input.ProductImages?.Any() == true)
        {
            foreach (var imageDto in input.ProductImages)
            {
                var image = ObjectMapper.Map<ProductImage>(imageDto);
                product.ProductImages.Add(image);
            }
        }

        await _productRepository.UpdateAsync(product);
        return ObjectMapper.Map<ProductDto>(product);
    }

 

    public async Task DeleteAsync(Guid id)
    {
        await _productRepository.DeleteAsync(id);
    }
}

