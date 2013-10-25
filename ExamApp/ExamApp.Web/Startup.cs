using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExamApp.Web.Startup))]
namespace ExamApp.Web
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
