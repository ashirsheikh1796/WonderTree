﻿using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WonderTreeTest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = "Get", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Custom",
                routeTemplate: "{controller}/{action}/{id}",
                defaults: new { action = "Get", id = RouteParameter.Optional }
            );

            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            config.Formatters.JsonFormatter.SerializerSettings.Formatting =
                Newtonsoft.Json.Formatting.Indented;
        }
    }
}
