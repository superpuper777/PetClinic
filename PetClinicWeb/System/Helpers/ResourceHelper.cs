using System;
using System.Web;

namespace PetClinicWeb.System.Helpers
{
    public class ResourcesHelper
    {
        public static string GetGlobalResource(string resourceName, string key)
        {
            return HttpContext.GetGlobalResourceObject(resourceName, key) as string;
        }

        public static string GetGlobalModelResource(string modelName, string key)
        {
            return HttpContext.GetGlobalResourceObject(modelName, key) as string;
        }

        public static string GetLocalResource(Type type, string key)
        {
            if (type == null || !IsPetClinicNamespace(type.FullName) || string.IsNullOrEmpty(key))
            {
                return string.Empty;
            }
            if (type.FullName != null)
            {
                var virtualPath = string.Concat("~/", type.FullName.Substring(4).Replace(".", "/"));
                var resourceObject = HttpContext.GetLocalResourceObject(virtualPath, key);
                return resourceObject?.ToString() ?? string.Empty;
            }
            return string.Empty;
        }

        private static bool IsPetClinicNamespace(string namespaceValue)
        {
            return !string.IsNullOrEmpty(namespaceValue) && namespaceValue.Length > 13 &&
                   namespaceValue.StartsWith("PetClinicWeb.");
        }
    }
}