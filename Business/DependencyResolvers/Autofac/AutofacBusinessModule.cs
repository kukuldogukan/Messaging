using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ErrorLogManager>().As<IErrorLogService>();
            builder.RegisterType<EfErrorLogDal>().As<IErrorLogDal>();

            builder.RegisterType<MessageManager>().As<IMessageService>();
            builder.RegisterType<EfMessageDal>().As<IMessageDal>();

            builder.RegisterType<UserActivityManager>().As<IUserActivityService>();
            builder.RegisterType<EfUserActivityDal>().As<IUserActivityDal>();

            builder.RegisterType<UserBlockedUserMappingManager>().As<IUserBlockedUserMappingService>();
            builder.RegisterType<EfUserBlockedUserMappingDal>().As<IUserBlockedUserMappingDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector() 
            }).SingleInstance();
        }
    }
}
