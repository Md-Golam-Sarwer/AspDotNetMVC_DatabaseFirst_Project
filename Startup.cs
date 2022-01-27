using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeInformationSystem.Startup))]
namespace EmployeeInformationSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
