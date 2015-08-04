using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcApplicationTest.Startup))]
namespace MvcApplicationTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
