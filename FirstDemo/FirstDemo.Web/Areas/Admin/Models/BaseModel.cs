using Autofac;
using FirstDemo.Infrastructure.Services;

namespace FirstDemo.Web.Areas.Admin.Models
{
    public class BaseModel
    {
        protected ILifetimeScope _scope;
        public ITimeService _timeService;

        public BaseModel()
        {

        }

        public virtual void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _timeService = _scope.Resolve<ITimeService>();
        }
    }
}
