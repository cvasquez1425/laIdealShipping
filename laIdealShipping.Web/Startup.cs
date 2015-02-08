using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(laIdealShipping.Web.Startup))]
namespace laIdealShipping.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
