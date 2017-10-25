using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cmcglynn_financialPortal.Startup))]
namespace cmcglynn_financialPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
