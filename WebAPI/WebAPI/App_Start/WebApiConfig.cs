
using CloudinaryDotNet;
using System.Web.Http;
using System.Web.Mvc;
using WebAPI.ActionFilters;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            //config.MapHttpAttributeRoutes();


            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "agentieimobiliara/{controller}/{action}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );
            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "agentieimobiliara/{controller}/{action}",
                defaults: new {id = RouteParameter.Optional}
                );

            Account account = new Account(
            "dsnhxbse3",
            "448362465371562",
            "EIJkgYaRXP6zrXwVnFVxQQZqsN0");
            //Cloudinary cloudinary = new Cloudinary(account);
            var cloudinary = new Cloudinary(account);
            var getResult = cloudinary.GetResource("sample");
        }
    }
}
