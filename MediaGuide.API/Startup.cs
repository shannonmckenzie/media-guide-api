using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MediaGuide.API.Startup))]

namespace MediaGuide.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWebApi(WebApiConfig.Register());
        }
    }
}
