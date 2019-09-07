using Microsoft.Owin;
using Owin;
using Store.App_Start;

[assembly: OwinStartup(typeof(Startup), "Configuration")]    


namespace Store.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            IdentityConfig conf = new IdentityConfig();
            conf.Configuration(app);
        }
    }
}