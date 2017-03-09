using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CityGoodTaste.Startup))]
namespace CityGoodTaste
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
