using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TreeTrackerNet.Startup))]
namespace TreeTrackerNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
