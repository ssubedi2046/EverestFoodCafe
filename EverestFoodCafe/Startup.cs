using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EverestFoodCafe.Startup))]
namespace EverestFoodCafe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
