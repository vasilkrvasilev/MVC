using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlaceSystem.Startup))]
namespace PlaceSystem
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
