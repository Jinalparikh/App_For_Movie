using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Movie_RentalApp.Startup))]
namespace Movie_RentalApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
