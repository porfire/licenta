//using System.Data.Entity;
//using Autofac;
//using WebAPI.DAL;
//using WebAPI.DAL.Interfaces;

//namespace WebAPI.Modules
//{
//    public class EFModule:Autofac.Module
//    {
//        protected override void Load(ContainerBuilder builder)
//        {
//            builder.RegisterModule(new RepositoryModule());

//            builder.RegisterType(typeof(DbContext)).As(typeof(DbContext)).InstancePerLifetimeScope();
//            builder.RegisterType(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork)).InstancePerRequest();

//        }
//    }
//}