using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrackModWebApp.Startup))]
namespace TrackModWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
