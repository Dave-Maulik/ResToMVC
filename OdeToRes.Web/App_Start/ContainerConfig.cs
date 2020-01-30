using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToRes.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OdeToRes.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var buildContainer = new ContainerBuilder();
            //Revise Why we use this Line.
            //After this line Autofact knows about All Controllers (i.e Home , Grettings) just we have to pass
            //all it needs to pass the name of Assembly that contains my all controllers.
            buildContainer.RegisterControllers(typeof(MvcApplication).Assembly);
            // buildContainer.RegisterType<InMemoryResaturantData>().As<IRestaurantData>().SingleInstance();
            buildContainer.RegisterType<SqlRestaurantData>().As<IRestaurantData>().InstancePerRequest();
            buildContainer.RegisterType<OdeToResDbContext>().InstancePerRequest();
            var Dependencycontainer = buildContainer.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Dependencycontainer));
         
        }

        internal static void RegisterAPIContainer(HttpConfiguration httpConfiguration)
        {
            var buildContainer = new ContainerBuilder();
            buildContainer.RegisterApiControllers(typeof(MvcApplication).Assembly);
            buildContainer.RegisterType<InMemoryResaturantData>().As<IRestaurantData>().SingleInstance();
            var Dependencycontainer = buildContainer.Build();
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(Dependencycontainer);
        }

    }

}