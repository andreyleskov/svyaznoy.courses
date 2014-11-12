using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WDataVisualization.Startup))]
namespace WDataVisualization
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
