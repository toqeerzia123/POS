using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;

namespace IPOC.ProductManagement.CategoryService;
public class CategoryAppService : ApplicationService, ICategoryAppService
{
    private readonly IRepository<Category, Guid> _categoryRepository;

    public CategoryAppService(IRepository<Category, Guid> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var categories = await _categoryRepository.GetAllListAsync();
        return ObjectMapper.Map<List<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> GetAsync(Guid id)
    {
        var category = await _categoryRepository.GetAsync(id);
        return ObjectMapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> CreateAsync(CreateUpdateCategoryDto input)
    {
        var category = ObjectMapper.Map<Category>(input);

        // Map child images
        if (input.CategoryImages != null && input.CategoryImages.Any())
        {
            category.CategoryImages = input.CategoryImages
                .Select(img => ObjectMapper.Map<CategoryImage>(img))
                .ToList();
        }

        await _categoryRepository.InsertAsync(category);
        return ObjectMapper.Map<CategoryDto>(category);
    }

    public async Task<CategoryDto> UpdateAsync(Guid id, CreateUpdateCategoryDto input)
    {
        var category = await _categoryRepository.GetAsync(id);

        // Clear existing images if needed
        category.CategoryImages.Clear();

        // Map fields
        ObjectMapper.Map(input, category);

        // Map new images
        if (input.CategoryImages != null)
        {
            foreach (var imageDto in input.CategoryImages)
            {
                var image = ObjectMapper.Map<CategoryImage>(imageDto);
                category.CategoryImages.Add(image);
            }
        }

        await _categoryRepository.UpdateAsync(category);
        return ObjectMapper.Map<CategoryDto>(category);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _categoryRepository.DeleteAsync(id);
    }
}

