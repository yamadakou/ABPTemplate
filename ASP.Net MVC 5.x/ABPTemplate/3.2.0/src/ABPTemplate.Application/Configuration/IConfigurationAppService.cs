using System.Threading.Tasks;
using Abp.Application.Services;
using ABPTemplate.Configuration.Dto;

namespace ABPTemplate.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}