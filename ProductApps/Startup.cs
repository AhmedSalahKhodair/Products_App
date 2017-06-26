using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductApps.Startup))]
namespace ProductApps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
