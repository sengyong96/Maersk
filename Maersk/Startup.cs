using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Maersk.Startup))]
namespace Maersk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
