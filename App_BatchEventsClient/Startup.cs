using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(App_BatchEventsClient.Startup))]
namespace App_BatchEventsClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
