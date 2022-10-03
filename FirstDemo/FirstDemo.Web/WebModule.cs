﻿using Autofac;
using FirstDemo.Web.Areas.Admin.Models;
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

            builder.RegisterType<CourseCreateModel>().AsSelf();

            builder.RegisterType<CourseEditModel>().AsSelf();

            builder.RegisterType<CourseListModel>().AsSelf();

            base.Load(builder);
        }
    }
}
