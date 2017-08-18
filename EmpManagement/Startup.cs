using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmpManagement.Startup))]
namespace EmpManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
