using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Helper
{
    public class ConnectionHelper
    {
        public ConnectionHelper()
        {

        }
        public static SqlConnection GetConnection()
        {   
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"].ToString();
            
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }
      
    }
}
