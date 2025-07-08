using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using IPOC.Configuration.Dto;

namespace IPOC.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : IPOCAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
