using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using PetClinicFacade.CompositionModule;
using PetClinicWeb.System.Helpers;
using PetClinicWeb.System.Utils;

namespace PetClinicWeb.App_Start
{
    public static class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.UsePetClinicFacade();
            builder.UsePetClinicWeb();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private static void UsePetClinicWeb(this ContainerBuilder builder)
        {
            builder.RegisterType(typeof(PasswordHelper))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterType(typeof(PetClinicMailer))
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}