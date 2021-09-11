using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PMAYProject.Startup))]
namespace PMAYProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
