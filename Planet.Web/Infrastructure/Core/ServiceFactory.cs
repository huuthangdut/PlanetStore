using System.Web;
using System.Web.Mvc;

namespace Planet.Web.Infrastructure.Core
{
    //Cách gọi tầng service trong class nào đó mà không phải là controller mvc !
    public static class ServiceFactory
    {
        public static T Get<T>()
        {
            if (HttpContext.Current != null)
            {
                var key = string.Concat("factory-", typeof(T).Name);
                if (!HttpContext.Current.Items.Contains(key))
                {
                    var resolvedService = DependencyResolver.Current.GetService<T>();
                    HttpContext.Current.Items.Add(key, resolvedService);
                }
                return (T)HttpContext.Current.Items[key];
            }
            return DependencyResolver.Current.GetService<T>();
        }
    }
}