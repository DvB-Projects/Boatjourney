using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BoatJourney.Startup))]
namespace BoatJourney
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
