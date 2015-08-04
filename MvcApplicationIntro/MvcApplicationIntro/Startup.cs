using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcApplicationIntro.Startup))]
namespace MvcApplicationIntro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
