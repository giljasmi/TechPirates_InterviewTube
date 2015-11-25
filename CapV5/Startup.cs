using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CapV5.Startup))]
namespace CapV5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
