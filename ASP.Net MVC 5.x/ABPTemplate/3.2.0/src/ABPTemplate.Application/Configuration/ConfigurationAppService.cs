using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ABPTemplate.Configuration.Dto;

namespace ABPTemplate.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ABPTemplateAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
