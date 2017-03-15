using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FrontEndASPNETTest.Startup))]
namespace FrontEndASPNETTest
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
