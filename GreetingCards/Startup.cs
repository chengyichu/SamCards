using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GreetingCards.Startup))]
namespace GreetingCards
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
