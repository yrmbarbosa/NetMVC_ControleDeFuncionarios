using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(App_ControleDeFuncionarios.Startup))]
namespace App_ControleDeFuncionarios
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
