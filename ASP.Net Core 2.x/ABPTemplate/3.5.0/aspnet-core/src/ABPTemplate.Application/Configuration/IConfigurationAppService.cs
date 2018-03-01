using System.Threading.Tasks;
using ABPTemplate.Configuration.Dto;

namespace ABPTemplate.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
