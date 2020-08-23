using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace _2944752011_SOAP
{
    /// <summary>
    /// Summary description for ServicioConsulta
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ServicioConsulta : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public double GetConsultaMontoOrdenes(String NumOrden)
        {
            double total;
            SqlConnection cn = new SqlConnection("Data Source=.\\SQLExpress; Initial Catalog=AdventureWorks2014; Integrated Security=true");
            cn.Open();
            SqlCommand sql = new SqlCommand("select SUM(unitprice * orderqty) from sales.salesorderdetail where salesorderid=" + NumOrden + ";",cn);
            total = Convert.ToDouble(sql.ExecuteScalar());
            cn.Close();
            return total;
        }
    }
}
