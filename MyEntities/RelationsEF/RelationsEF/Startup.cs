using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RelationsEF.Startup))]
namespace RelationsEF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
