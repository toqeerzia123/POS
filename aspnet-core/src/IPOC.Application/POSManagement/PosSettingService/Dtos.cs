using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace IPOC.POSManagement.PosSettingService;
public class PosSettingDto : FullAuditedEntityDto<Guid>
{
    public Guid LocationId { get; set; }
    public string Name { get; set; }
    public string LogoUrl { get; set; }
    public string FooterText { get; set; }
    public string Address { get; set; }
    public string Version { get; set; }
    public string ThemeColor { get; set; }
    public bool IsActive { get; set; }
}

public class CreateUpdatePosSettingDto
{
    public Guid LocationId { get; set; }
    public string Name { get; set; }
    public string LogoUrl { get; set; }
    public string FooterText { get; set; }
    public string Address { get; set; }
    public string Version { get; set; }
    public string ThemeColor { get; set; }
    public bool IsActive { get; set; }
}

