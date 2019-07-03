using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Proiecto.BCL.SQLDataSource;
using Proiecto.GC;
using Newtonsoft.Json;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Xml.Serialization;

//namespace webVersionCore.businessObjects.ticket_x_estatus nombre original
namespace businessObjects
{
    [Serializable]

    public sealed partial class ticket_x_estatus

       
    {
        // Objeto de accesoa  datos
        OracleSqlClientEx oData = new OracleSqlClientEx();

        // Cadena de conexion (ya descifrada desde Base64) en formato:
        // Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=0.0.0.0)(PORT=1522)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=********)));User Id=********;Password=********;
        [JsonIgnore]
        public string cs { get; set; }

        // Nombre del paquete donde se encuentran almacenados los Procedimientos Almacenados
        [JsonIgnore]
        public string packageName { get; set; }

        [JsonIgnore]
        public string LastErrorFound = "";

        //[JsonIgnore]
        public DataTable tickets_x_estatusT = new DataTable("tabla.tickets_x_estatus");

        [JsonIgnore]
        public string tokenUsuario { get; set; }
        public string Nro_Documento { get; set; }
        public string Nro_Tickets { get; set; }
        public string Estatus { get; set; }
        public string Descripcion_del_Ticket { get; set; }
        public string Prioridad_del_Ticket { get; set; }
        public string Fecha_de_Creacion_Ticket { get; set; }
        public string Fecha_de_Culminacion { get; set; }
        public string Desarrollador_Asignado { get; set; }

        public ticket_x_estatus()
        {
            // throw new Exception("No use el constructor básico, utilice el constructor con parámetros: new Tickets(connectionString, packageName)");
        }

        /// <summary>
        /// Sobrecarga de constructor
        /// </summary>
        /// <param name="cs">Connection String</param>
        /// <param name="pn">Package Name</param>
        /// 
        public ticket_x_estatus(string cs, string pn)
        {
            oData.ConnectionString = cs;
            this.packageName = pn;
            
        }

        public string regresarjson()
        {
            oData.AddParameter(":p_codigo_usuario", tokenUsuario, OracleDbType.Varchar2);
            oData.AddParameter(":p_status_Ticket", Estatus, OracleDbType.Varchar2);
            oData.AddParameter(":c_requerimientos", null, OracleDbType.RefCursor, ParameterDirection.Output);
            this.tickets_x_estatusT = oData.ExecuteDataTable(this.packageName + ".sp_Ticket_x_status", "tabla.tickets_x_estatus", true);
                                         

            return JsonConvert.SerializeObject(this.tickets_x_estatusT, Formatting.Indented);
            

        }



    }
}
