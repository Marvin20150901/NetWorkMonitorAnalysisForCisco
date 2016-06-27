using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetWorkMonitorAnalysisForCisco.Startup))]
namespace NetWorkMonitorAnalysisForCisco
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
