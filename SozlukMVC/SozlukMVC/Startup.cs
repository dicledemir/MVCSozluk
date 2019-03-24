using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SozlukMVC.Startup))]
namespace SozlukMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
