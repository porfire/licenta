//using System.Reflection;
//using Autofac;

//namespace WebAPI.Modules
//{
//    public class RepositoryModule : Autofac.Module
//    {
//        protected override void Load(ContainerBuilder builder)
//        {
//            builder.RegisterAssemblyTypes(Assembly.Load("WebAPI.Repository"))
//                   .Where(t => t.Name.EndsWith("Repository"))
//                   .AsImplementedInterfaces()
//                  .InstancePerLifetimeScope();
//        }
//    }
//}