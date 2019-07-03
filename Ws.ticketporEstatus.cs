using Newtonsoft.Json;
using Proiecto.BCL.SQLDataSource;
using Proiecto.BCL;
using Proiecto.BCL.SQLDataSource.Helper;
using System;
using System.Data;
using System.Web;
using System.Web.Services;
using businessObjects;

namespace webVersionWS.services.ticketsporEstatus
{
    /// <summary>
    /// Descripción breve de ticket_x_estatus
    /// </summary>
    public class index : IHttpHandler
    {
        // Obtener cadena de conexion y paquete de oracle  por defecto
        static readonly string cs = StringEx.DecodeBase64(ConfigEx.GetConnectionString("WEBVERSION"));
        static readonly string pn = ConfigEx.GetAppSettings<string>("PACKAGE_NAME4");

        ticket_x_estatus totales = new ticket_x_estatus(cs, pn); // Objeto principal global


        public void ProcessRequest(HttpContext context)
        {
            // Siempre vaciar cache...
            context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            context.Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-30));
            context.Response.Cache.SetNoStore();
            context.Response.Cache.SetNoServerCaching();


            // Contar cantidad de parametros recibidos por url
            int parametersCount = context.Request.QueryString.Count;


            totales.tokenUsuario = context.Request["totales"].ToString();
            totales.Estatus = context.Request["Status"].ToString();


            context.Response.ContentType = "text/json";
            context.Response.Write(totales.regresarjson());

            //context.Response.ContentType = "text/json";
            //context.Response.Write(JsonConvert.SerializeObject(
            //        new { Result = "parametersCount", Message = parametersCount.ToString() }, Formatting.Indented));

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
