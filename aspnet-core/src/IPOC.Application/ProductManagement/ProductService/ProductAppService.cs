using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IPOC.ProductManagement.ProductService;
public class ProductAppService : ApplicationService, IProductAppService
{
    private readonly IRepository<Product, Guid> _productRepository;
    private readonly IWebHostEnvironment _env;

    public ProductAppService(IRepository<Product, Guid> productRepository, IWebHostEnvironment env)
    {
        _productRepository = productRepository;
        _env = env;
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository
            .GetAllIncluding(x => x.Category)
            .Include(x => x.ProductImages)
            .Include(x => x.Category)
                .ThenInclude(c => c.ParentCategory) // This includes ParentCategory (will be null if not set)
            .ToListAsync();
        return ObjectMapper.Map<List<ProductDto>>(products);
    }

    public async Task<ProductDto> GetAsync(Guid id)
    {
        var product = await _productRepository.GetAsync(id);
        return ObjectMapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> GetByProdcuctCodeAsync(string productCode)
    {

        var product = await _productRepository
          .GetAllIncluding(x => x.Category)
          .Include(x => x.Category)
         .Where(x => x.ProductCode == productCode)
          .FirstOrDefaultAsync();
        return ObjectMapper.Map<ProductDto>(product);
    }

    public async Task<ProductDto> CreateAsync([FromForm] CreateUpdateProductDto input)
    {
        var product = ObjectMapper.Map<Product>(input);

        if (input.ProductImages?.Any() == true)
        {
            var productImages = new List<ProductImage>();

            foreach (var imageDto in input.ProductImages)
            {
                string imagePath = await SaveImageToDiskOrBlob(imageDto.ImageUrl);

                productImages.Add(new ProductImage
                {
                    ImageUrl = imagePath,
                    AltText = imageDto.AltText,
                    DisplayOrder = imageDto.DisplayOrder,
                    IsPrimary = imageDto.IsPrimary
                });
            }

            product.ProductImages = productImages;
        }

        await _productRepository.InsertAsync(product);
        return ObjectMapper.Map<ProductDto>(product);
    }
    private async Task<string> SaveImageToDiskOrBlob(IFormFile image)
    {
        var folderPath = Path.Combine(_env.WebRootPath, "uploads", "products");
        Directory.CreateDirectory(folderPath);

        var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(image.FileName)}";
        var filePath = Path.Combine(folderPath, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await image.CopyToAsync(stream);
        }

        // Return relative URL
        return $"/uploads/products/{fileName}";
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

