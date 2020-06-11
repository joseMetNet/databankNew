using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DATABANK
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default2",
                url: "{controller}/{action}/{id}/{pstatus}",
                defaults: new { controller = "administrador", action = "deActivateUser", id = UrlParameter.Optional, pstatus = UrlParameter.Optional, httproute = true }
            );
            routes.MapRoute(
                name: "Default3",
                url: "{controller}/{action}/{id}/{pstatus}",
                defaults: new { controller = "administrador", action = "deActivateBodega", id = UrlParameter.Optional, pstatus = UrlParameter.Optional, httproute = true }
            );
            routes.MapRoute(
                name: "Default4",
                url: "{controller}/{action}/{id}/{pstatus}",
                defaults: new { controller = "administrador", action = "deActivateProyecto", id = UrlParameter.Optional, pstatus = UrlParameter.Optional, httproute = true }
            );
            routes.MapRoute(
                name: "Default5",
                url: "{controller}/{action}/{id}/{pstatus}",
                defaults: new { controller = "administrador", action = "deActivateAlmacen", id = UrlParameter.Optional, pstatus = UrlParameter.Optional, httproute = true }
            );
            routes.MapRoute(
                name: "Default6",
                url: "{controller}/{action}/{id}/{pstatus}",
                defaults: new { controller = "administrador", action = "deActivateUserProyecto", id = UrlParameter.Optional, pstatus = UrlParameter.Optional, httproute = true }
            );
            routes.MapRoute(
                name: "Default7",
                url: "{controller}/{action}/{id}/{t}/{g}/{e}/{d}/{im}/{ex}",
                defaults: new { controller = "administrador", action = "savePermiso", id = UrlParameter.Optional, t = UrlParameter.Optional, g = UrlParameter.Optional, e = UrlParameter.Optional, d = UrlParameter.Optional, im = UrlParameter.Optional, ex = UrlParameter.Optional, httproute = true }
            );
            routes.MapRoute(
                name: "Default8",
                url: "{controller}/{action}/{id}/{pstatus}",
                defaults: new { controller = "administrador", action = "deActivateInventario", id = UrlParameter.Optional, pstatus = UrlParameter.Optional, httproute = true }
            );
            routes.MapRoute(
                name: "Default9",
                url: "{controller}/{action}/{id}/{pstatus}",
                defaults: new { controller = "administrador", action = "getDepartamentoMunicipio", id = UrlParameter.Optional, pstatus = UrlParameter.Optional, httproute = true }
            );
        }
    }
}
