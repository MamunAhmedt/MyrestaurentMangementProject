using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Resturant_Management.Startup))]
namespace Resturant_Management
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
