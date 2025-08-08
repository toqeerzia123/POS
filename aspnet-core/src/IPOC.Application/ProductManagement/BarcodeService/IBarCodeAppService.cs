using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Application.Services;

namespace IPOC.ProductManagement.BarcodeService;
public interface IBarCodeAppService : IApplicationService
{
    Task<List<BarCodeDto>> GetAllAsync();
     Task<List<TreeNodeDto>> GetBarcodesGroupedAsync();
    Task<BarCodeDto> GetAsync(Guid id);
    Task<BarCodeDto> CreateAsync(CreateUpdateBarCodeDto input);
    Task<BarCodeDto> UpdateAsync(Guid id, CreateUpdateBarCodeDto input);
    Task DeleteAsync(Guid id);

    string GenerateBarcode(string value, string price);
    byte[] GenerateBarcodeWithDetails(string productName, string productCode, string price);

}


