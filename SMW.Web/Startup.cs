using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SMW.Web.Startup))]
namespace SMW.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
