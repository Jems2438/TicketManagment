using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ticketmanagment.WebUI.Startup))]
namespace Ticketmanagment.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
