
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EarlySummer.Application
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new Platform.Module.SimpleViewEngine());

            //Autofac
            ContainerBuilder builder = new ContainerBuilder();
            var assembly = Assembly.Load("EarlySummer.BusinessModules");
            builder.RegisterControllers(assembly);
            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
