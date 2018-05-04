using System.Web.Mvc;

namespace PetClinicWeb.System.Extensions
{
    public static class GlobalExtensions
    {
        public static string LocalResources(this WebViewPage page, string key)
        {
            return page.ViewContext.HttpContext.GetLocalResourceObject(page.VirtualPath, key) as string;
        }

        public static string LocalResources(this WebViewPage page, string key, params object[] args)
        {
            return string.Format(page.ViewContext.HttpContext.GetLocalResourceObject(page.VirtualPath, key) as string,
                args);
        }
    }
}