using System.Reflection;
using Autofac;

namespace PetClinicFacade.CompositionModule
{
    public static class CompositionModule
    {
        public static void UsePetClinicFacade(this ContainerBuilder builder)
        {
            var dataAccess = Assembly.Load("PetClinicDAL");

            builder.RegisterAssemblyTypes(dataAccess)
                .Where(t => t.Name.EndsWith("DataHelper"))
                .AsImplementedInterfaces();
        }
    }
}