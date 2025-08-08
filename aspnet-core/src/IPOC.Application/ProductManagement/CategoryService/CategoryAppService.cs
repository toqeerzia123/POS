using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using BarcodeStandard;
using Castle.MicroKernel.Registration;
using IPOC.ProductManagement.BarcodeService;
using Microsoft.EntityFrameworkCore;
using SkiaSharp;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.SkiaSharp;
using ZXing.SkiaSharp.Rendering;


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

    public async Task<List<CategoryDto>> GetAllParentsAsync()
    {
        var categories = await _categoryRepository
        .GetAll()
        .Where(x => x.ParentCategoryId == null)
        .ToListAsync();
        return ObjectMapper.Map<List<CategoryDto>>(categories);
    }
    public async Task<List<CategoryDto>> GetClieldAsync(Guid parentId)
    {
        var categories = await _categoryRepository
        .GetAll()
        .Where(x => x.ParentCategoryId == parentId)
        .ToListAsync();
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
    public async Task<List<CategoryTreeNodeDto>> GetAllCategoryTreeAsync()
    {
        try
        {
            var categories = await _categoryRepository.GetAllListAsync();

            // Group categories by ParentCategoryId (null = root categories)
            var categoryLookup = categories
                .GroupBy(c => c.ParentCategoryId)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Recursive function to build tree
            List<CategoryTreeNodeDto> BuildTree(Guid? parentId)
            {
                if (!categoryLookup.TryGetValue(parentId, out var children))
                    return new List<CategoryTreeNodeDto>();

                return children.Select(cat => new CategoryTreeNodeDto
                {
                    Key = cat.Id.ToString(),
                    Label = cat.Name ?? "[Unnamed Category]",
                    Data = cat.Description,
                    Children = BuildTree(cat.Id)
                }).ToList();
            }

            // Build and return the root tree
            return BuildTree(null);
            // Start from root (null parent)

        }
        catch (Exception ex)
        {

            throw;
        }
       
    }



}

