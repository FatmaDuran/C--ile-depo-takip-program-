using System;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace DAL
{
    public class KisiIslemleri
    {
        public static string ConnectionStr { get; set; }


        public static DataSet listKisi()
        { 
            SqlConnection conn = new SqlConnection(ConnectionStr);
            string sql = "select * from Kisiler";
            SqlCommand komut = new SqlCommand(sql, conn);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            return ds;
        }
    }
}
