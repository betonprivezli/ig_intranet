
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using EnumSample.Models;

namespace EnumSample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Clear the database each time we start; not recommended for production use
            Database.SetInitializer<UsersImpContext>(new DropCreateDatabaseAlways<UsersImpContext>());            
              
            // https://metanit.com/sharp/entityframework/3.9.php
            //Database.SetInitializer<UsersImpContext>(new CreateDatabaseIfNotExists<UsersImpContext>());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
