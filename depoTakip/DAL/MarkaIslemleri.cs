using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class MarkaIslemleri
    {
       public static string ConnectionStr { get; set; }

       public static DataSet listMarka()
       {
         
           SqlConnection conn = new SqlConnection(ConnectionStr);
           conn.Open();
           string sql = "select * from Marka";
           SqlCommand komut = new SqlCommand(sql, conn);
           SqlDataAdapter adp = new SqlDataAdapter(komut);
           DataSet ds = new DataSet();
           adp.Fill(ds);
           conn.Close();
           return ds;
       }
       public static DataSet listMarkaByUrungrupID(int id)
       {
           SqlConnection bag = new SqlConnection(ConnectionStr);
           bag.Open();

           string sql = "select mk.* from Marka mk where mk.MarkaID in ( select distinct ma.MarkaID from urunler u inner join Model m on u.ModelID = m.ModelID inner join Marka ma on m.MarkaID = ma.MarkaID where UrunGrupID=@id)";
           SqlCommand komut = new SqlCommand(sql, bag);

           komut.Parameters.AddWithValue("@id", id);

           SqlDataAdapter adp = new SqlDataAdapter(komut);
           DataSet tablo = new DataSet();
           adp.Fill(tablo);
           bag.Close();
           return tablo;
       }
       public static DataSet getMarkabyID(int id)
       {
           SqlConnection baglanti = new SqlConnection(ConnectionStr);
           baglanti.Open();

           string sql = "select * from Marka where MarkaID=@id";
           SqlCommand komut = new SqlCommand(sql, baglanti);
           komut.Parameters.AddWithValue("@id", id);
           SqlDataAdapter adp = new SqlDataAdapter(komut);
           DataSet tablo = new DataSet();
           adp.Fill(tablo);
           baglanti.Close();
           return tablo;

       }
       public static void AddNewMarka(string marka)
       {
           SqlConnection con = new SqlConnection(ConnectionStr);
           con.Open();
           string sql = "insert into Marka(MarkaAdi) values (@marka)";
           SqlCommand kom = new SqlCommand(sql, con);
           kom.Parameters.AddWithValue("@marka", marka);
           kom.ExecuteNonQuery();
           con.Close();
       }
       public static void DeleteMarka(int markaid)
       {
           SqlConnection connection = new SqlConnection(ConnectionStr);
           connection.Open();
           string sql = "delete from Marka where MarkaID=@markaid";
           SqlCommand komut = new SqlCommand(sql, connection);
           komut.Parameters.AddWithValue("@markaid", markaid);
           komut.ExecuteNonQuery();
           connection.Close();

       }

       public static void UpdateMarka(string marka, int id)
       {
           SqlConnection connection = new SqlConnection(ConnectionStr);
           connection.Open();
           string sql = "Update Marka SET MarkaAdi=@marka where MarkaID=@ID";
           SqlCommand komut = new SqlCommand(sql, connection);
           komut.Parameters.AddWithValue("@marka", marka);
           komut.Parameters.AddWithValue("@ID", id);
           komut.ExecuteNonQuery();
           connection.Close();
       }
    }
   
}
