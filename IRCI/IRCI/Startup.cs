using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IRCI.Startup))]
namespace IRCI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
