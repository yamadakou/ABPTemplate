using System.Threading.Tasks;
using Abp.Application.Services;
using ABPTemplate.Sessions.Dto;

namespace ABPTemplate.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
