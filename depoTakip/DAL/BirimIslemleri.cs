using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class BirimIslemleri
    {
         
       public static string ConnectionStr { get; set; }
      

       public static DataSet getBirimById(int id)
       {

           SqlConnection conn = new SqlConnection(ConnectionStr);
           string sql = "select * from Birimler where BirimID=@pid";
           SqlCommand komut = new SqlCommand(sql, conn);
           komut.Parameters.AddWithValue("@pid", id);
           SqlDataAdapter adp = new SqlDataAdapter(komut);
           DataSet ds = new DataSet();
           adp.Fill(ds);
          
           return ds;
       }
       public static DataSet BirimCek()
       {

           SqlConnection bag = new SqlConnection(ConnectionStr);
           bag.Open();
           string sorgu = "Select * from Birimler";
           SqlCommand komut = new SqlCommand(sorgu, bag);
           SqlDataAdapter adp = new SqlDataAdapter(komut);
           DataSet sonuc = new DataSet();
           adp.Fill(sonuc);
           bag.Close();
           return sonuc;
       }

       public static void BirimInsert(string ad,bool aktif)
       {
           SqlConnection bag = new SqlConnection(ConnectionStr);
           bag.Open();
           string sql = "insert into Birimler(BirimAdi,Aktiflik) Values(@ad,@aktif)";
           SqlCommand komut = new SqlCommand(sql, bag);
         
           komut.Parameters.AddWithValue("@ad",ad);
           komut.Parameters.AddWithValue("@aktif", aktif);
           komut.ExecuteNonQuery();
           bag.Close();

       }
       public static void BirimDelete(int id)
       {
           SqlConnection con = new SqlConnection(ConnectionStr);
           con.Open();
           string sql = "Delete from Birimler where BirimID=@id";
           SqlCommand komut = new SqlCommand(sql, con);
           komut.Parameters.AddWithValue("@id", id);
           komut.ExecuteNonQuery();
       }
       public static void BirimUpdate(string ad,bool aktif,int id)
       {
           SqlConnection conn = new SqlConnection(ConnectionStr);
           conn.Open();
           string sql = "Update Birimler SET BirimAdi=@ad,Aktiflik=@aktif where BirimID=@id  ";
           SqlCommand kom = new SqlCommand(sql,conn);

           kom.Parameters.AddWithValue("@id ",id);
            kom.Parameters.AddWithValue("@ad",ad);
            kom.Parameters.AddWithValue("@aktif",aktif);

            kom.ExecuteNonQuery();
            conn.Close();
           
    
       }

    }
}
