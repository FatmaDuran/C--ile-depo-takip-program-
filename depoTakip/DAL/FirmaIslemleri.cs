using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class FirmaIslemleri
    {
        public static string ConnectionStr { get; set; }


        public static DataSet listFirma()
        {
            SqlConnection conn = new SqlConnection(ConnectionStr);
            string sql = "select * from Firmalar";
            SqlCommand komut = new SqlCommand(sql, conn);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            return ds;
        }
    }
}
