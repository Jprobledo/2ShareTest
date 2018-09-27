using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopPesentation.Startup))]
namespace ShopPesentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
