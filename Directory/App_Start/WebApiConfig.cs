﻿// <copyright file="WebApiConfig.cs" company="Adam Miller">
// Copyright (c) Adam Miller. All rights reserved.
// </copyright>

namespace Directory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using Directory.Filters;
    using Directory.Repository;
    using Microsoft.Practices.Unity;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Unity dependency injection
            var container = new UnityContainer();
            container.RegisterType<IPersonRepository, PersonRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // validate models using custom filter
            config.Filters.Add(new ValidateModelAttribute());

            // add global exception handling
            config.Filters.Add(new Directory.Filters.CustomExceptionFilter());

            // Web API routes
            config.MapHttpAttributeRoutes();

            // enable CORS
            var cors = new System.Web.Http.Cors.EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
