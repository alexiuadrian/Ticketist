using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ticketist.Startup))]
namespace Ticketist
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
