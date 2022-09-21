using Autofac;

namespace FirstDemo.Web.Areas.Admin.Models
{
    public class BaseModel
    {
        protected ILifetimeScope _scope;

        protected virtual void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
        }
    }
}
