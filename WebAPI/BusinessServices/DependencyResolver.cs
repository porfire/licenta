using System.ComponentModel.Composition;
using BusinessServices.Interfaces;
using BusinessServices.Services;
using Resolver;


namespace BusinessServices
{
    [Export(typeof(IComponent))]
    class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IAgentiService, AgentiService>();
            registerComponent.RegisterType<IAgentieService, AgentieService>();
            registerComponent.RegisterType<ICartierService, CartierService>();
            registerComponent.RegisterType<IDetaliiImobilService, DetaliiImobilService>();
            registerComponent.RegisterType<IFotoImobilService, FotoImobilServce>();
            registerComponent.RegisterType<ILocalitateService, LocalitateService>();
            registerComponent.RegisterType<ILoginService, LoginService>();

            registerComponent.RegisterType<IOfertaService, OfertaService>();

            registerComponent.RegisterType<IPersonService, PersonService>();
            registerComponent.RegisterType<IUserRolService, UserRolService>();
            registerComponent.RegisterType<ITokenService, TokenService>();

            registerComponent.RegisterType<IUserService, UserService>();
            registerComponent.RegisterType<IVideoImobilService, VideoImobilSerice>();
        }
    }
}
