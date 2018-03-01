using System.Threading.Tasks;
using Abp.Application.Services;
using ABPTemplate.Authorization.Accounts.Dto;

namespace ABPTemplate.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
