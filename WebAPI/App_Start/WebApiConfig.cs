﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace MvcApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "YoupSearchApi",
                routeTemplate: "{controller}/{action}/{type}",
                defaults: new { type = RouteParameter.Optional }
            );

            // Supprimez les commentaires de la ligne de code suivante pour activer la prise en charge des requêtes pour les actions ayant un type de retour IQueryable ou IQueryable<T>.
            // Pour éviter le traitement de requêtes inattendues ou malveillantes, utilisez les paramètres de validation définis sur QueryableAttribute pour valider les requêtes entrantes.
            // Pour plus d’informations, visitez http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // Pour désactiver le suivi dans votre application, supprimez le commentaire de la ligne de code suivante ou supprimez cette dernière
            //Pour plus d’informations, consultez la page : http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
