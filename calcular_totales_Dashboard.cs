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

//namespace webVersionCore.businessObjects.calcular_totales_Dashboard  Original

namespace businessObjects
{

    [Serializable]
    public sealed partial class sp_calcular_totales
    {
        // Objeto de accesoa  datos
        OracleSqlClientEx oData = new OracleSqlClientEx(); //static

        // Cadena de conexion (ya descifrada desde Base64) en formato:
        // Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=0.0.0.0)(PORT=1522)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=********)));User Id=********;Password=********;
        [JsonIgnore]
        public string cs { get; set; }

        // Nombre del paquete donde se encuentran almacenados los Procedimientos Almacenados
        [JsonIgnore]
        public string packageName { get; set; }

        [JsonIgnore]
        public string LastErrorFound = "";

        // propiedades
        //[Key()]
        //[Required()]
        //public VARCHAR2 p_codigo_usuario { get; set; }


        [JsonIgnore]
        public DataTable ccc = new DataTable("tablaDasborad");//static

        [JsonIgnore]
        public string tokenUsuario { get; set; }
        public string Total_Tickets_Desarrollo { get; set; }
        public string Total_Tickets_Calidad { get; set; }
        public string Total_Tickets_PostProduccion { get; set; }
        public string Total_Tickets_General { get; set; }
        public string Total_Tick_Asg_Rec_Users { get; set}



        public sp_calcular_totales()
        {
            // throw new Exception("No use el constructor básico, utilice el constructor con parámetros: new Tickets(connectionString, packageName)");
        }

        /// <summary>
        /// Sobrecarga de constructor
        /// </summary>
        /// <param name="cs">Connection String</param>
        /// <param name="pn">Package Name</param>
        /// 
        public sp_calcular_totales(string cs, string pn)
        {
            oData.ConnectionString = cs;
            this.packageName = pn;
            //this.clear(); // Tomar valores de los atributos por defecto...
        }


      public  string regresarjson()
        {
            oData.AddParameter(":p_codigo_usuario", tokenUsuario, OracleDbType.Varchar2);
            oData.AddParameter(":c_cursor_TCard_Dashboard", null, OracleDbType.RefCursor, ParameterDirection.Output);
            this.ccc = oData.ExecuteDataTable(this.packageName + ".sp_calcular_totales_Dashboard", "tablaDasborad", true);


            //return Proiecto.BCL.SQLDataSource.Helper.Utils.DataTableToJson(ccc);


            this.Total_Tickets_Desarrollo = ccc.Rows[0]["Total_Tickets_Desarrollo"].ToString();
            this.Total_Tickets_Calidad = ccc.Rows[0]["Total_Tickets_Calidad"].ToString();
            this.Total_Tickets_PostProduccion = ccc.Rows[0]["Total_Tickets_PostProduccion"].ToString();
            this.Total_Tickets_General = ccc.Rows[0]["Total_Tickets_General"].ToString();
            this.Total_Tickets_General = ccc.Rows[0]["Total_Tick_Asg_Rec_Users"].ToString();


            return JsonConvert.SerializeObject(this, Formatting.Indented);
            //return Proiecto.BCL.SQLDataSource.Helper.Utils.DataTableToJson(ccc);
        }


    }




}
