using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlowSagicorInsurance.Startup))]
namespace FlowSagicorInsurance
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
