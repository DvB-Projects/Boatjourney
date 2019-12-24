using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Relaties.Startup))]
namespace Relaties
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
