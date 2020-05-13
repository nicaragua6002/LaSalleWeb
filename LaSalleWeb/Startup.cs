using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LaSalleWeb.Startup))]
namespace LaSalleWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
