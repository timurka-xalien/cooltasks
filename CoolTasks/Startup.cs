using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CoolTasks.Startup))]
namespace CoolTasks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
