using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASYC_AWAT_TEST.Startup))]
namespace ASYC_AWAT_TEST
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
