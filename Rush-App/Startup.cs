using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rush_App.Startup))]
namespace Rush_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
