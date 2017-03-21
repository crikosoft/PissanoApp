using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PissanoApp.Startup))]
namespace PissanoApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
