using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(Tab30.Startup))]

namespace Tab30
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}