using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DDAC_Maersk.Startup))]
namespace DDAC_Maersk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
