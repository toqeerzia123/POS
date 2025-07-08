using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace IPOC.Controllers
{
    public abstract class IPOCControllerBase: AbpController
    {
        protected IPOCControllerBase()
        {
            LocalizationSourceName = IPOCConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
