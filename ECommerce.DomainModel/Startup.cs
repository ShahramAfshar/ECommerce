using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ECommerce.DomainModel.StartupOwin))]

namespace ECommerce.DomainModel
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
