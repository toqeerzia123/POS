using System.Threading.Tasks;
using IPOC.Configuration.Dto;

namespace IPOC.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
