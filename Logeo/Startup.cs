using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Logeo.Startup))]
namespace Logeo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
