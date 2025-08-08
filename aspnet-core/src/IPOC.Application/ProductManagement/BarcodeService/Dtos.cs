using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace IPOC.ProductManagement.BarcodeService;
public class BarCodeDto : EntityDto<Guid>
{
    public string BarcodeValue { get; set; }
    public Guid? ProductId { get; set; }
    public string BarcodeType { get; set; }
    public bool IsAssigned { get; set; }
}
public class TreeNodeDto
{
    public string Key { get; set; }
    public string Label { get; set; }
    public string Data { get; set; }
    public List<TreeNodeDto> Children { get; set; }
}

public class CategoryTreeNodeDto
{
    public string Key { get; set; }
    public string Label { get; set; }
    public object Data { get; set; } // <-- Change this line
    public List<CategoryTreeNodeDto> Children { get; set; }
}

public class CreateUpdateBarCodeDto
{

    public string BarcodeValue { get; set; }

    public Guid? ProductId { get; set; }

    public string BarcodeType { get; set; }
}

