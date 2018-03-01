using Abp.Web.Mvc.Views;

namespace ABPTemplate.Web.Views
{
    public abstract class ABPTemplateWebViewPageBase : ABPTemplateWebViewPageBase<dynamic>
    {

    }

    public abstract class ABPTemplateWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected ABPTemplateWebViewPageBase()
        {
            LocalizationSourceName = ABPTemplateConsts.LocalizationSourceName;
        }
    }
}