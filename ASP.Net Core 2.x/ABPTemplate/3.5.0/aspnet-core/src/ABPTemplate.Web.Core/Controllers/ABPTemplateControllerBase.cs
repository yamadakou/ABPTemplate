using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ABPTemplate.Controllers
{
    public abstract class ABPTemplateControllerBase: AbpController
    {
        protected ABPTemplateControllerBase()
        {
            LocalizationSourceName = ABPTemplateConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
