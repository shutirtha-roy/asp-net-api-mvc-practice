using Autofac;
using FirstDemo.Web.Models;

namespace FirstDemo.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CourseModel>().As<ICourseModel>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CourseModel>().AsSelf();


            base.Load(builder);
        }
    }
}
