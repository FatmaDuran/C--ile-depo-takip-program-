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
   public class ModelIslem
    {
        public static string ConnectionStr { get; set; }
        //listMarkalarByUrunId
       public static DataSet listModelByUrunID(int id)
       {
           SqlConnection baglanti = new SqlConnection(ConnectionStr);
           baglanti.Open();

           string sql = "select * from Model as m inner join urunler as u on m.ModelID=u.ModelID where u.UrunID=@urunid ";
           SqlCommand komut = new SqlCommand(sql, baglanti);

           komut.Parameters.AddWithValue("@urunid", id);
           
           SqlDataAdapter adp = new SqlDataAdapter(komut);
           DataSet tablo = new DataSet();
           adp.Fill(tablo);
           baglanti.Close();
           return tablo;
}
     
       public static DataSet listModelByMarkaID(int id)
       {
           SqlConnection bag = new SqlConnection(ConnectionStr);
           bag.Open();

           string sql = "SELECT m.ModelID,m.ModelAdi FROM Model as m inner join Marka as a on m.MarkaID=a.MarkaID where m.MarkaID=@markaid";

           SqlCommand komut = new SqlCommand(sql, bag);

           komut.Parameters.AddWithValue("@markaid", id);

           SqlDataAdapter adp = new SqlDataAdapter(komut);
           DataSet tablo = new DataSet();
           adp.Fill(tablo);
           bag.Close();
           return tablo;
       }
      public static DataSet getModelbyID(int id)
       {
           SqlConnection baglanti = new SqlConnection(ConnectionStr);
           baglanti.Open();

           string sql = "select * from Model where ModelID=@id";
           SqlCommand komut = new SqlCommand(sql, baglanti);
           komut.Parameters.AddWithValue("@id", id);
           SqlDataAdapter adp = new SqlDataAdapter(komut);
           DataSet tablo = new DataSet();
           adp.Fill(tablo);
           baglanti.Close();
           return tablo;
       }
      public static DataSet listModel()
      {
          SqlConnection conn = new SqlConnection(ConnectionStr);
          string sql = "select * from Model";
          SqlCommand komut = new SqlCommand(sql, conn);
          SqlDataAdapter adp = new SqlDataAdapter(komut);
          DataSet ds = new DataSet();
          adp.Fill(ds);

          return ds;
      }
      public static void AddNewModel(string model, int marka)
      {
          SqlConnection con = new SqlConnection(ConnectionStr);
          con.Open();
          string sql = "insert into Model(ModelAdi,MarkaID) values (@model,@marka)";
          SqlCommand kom = new SqlCommand(sql, con);
          kom.Parameters.AddWithValue("@model", model);
          kom.Parameters.AddWithValue("@marka", marka);
          kom.ExecuteNonQuery();
          con.Close();
      }
      public static void DeleteModel(int modelid)
      {
          SqlConnection connection = new SqlConnection(ConnectionStr);
          connection.Open();
          string sql = "delete from Model where ModelID=@modelid";
          //string sql="delete from urunler where ModelID=@modelid";
          SqlCommand komut = new SqlCommand(sql, connection);
          komut.Parameters.AddWithValue("@modelid", modelid);
          komut.ExecuteNonQuery();
          connection.Close();
      }
       public static void UpdateModel(string model,int markaid,int modelid)
      {
          SqlConnection connection = new SqlConnection(ConnectionStr);
          connection.Open();
          string sql = "Update Model SET ModelAdi=@modeladi,MarkaID=@markaid where ModelID=@ID";
          SqlCommand komut = new SqlCommand(sql, connection);
          komut.Parameters.AddWithValue("@modeladi", model);
          komut.Parameters.AddWithValue("@markaid", markaid);
          komut.Parameters.AddWithValue("@ID", modelid);
          komut.ExecuteNonQuery();
          connection.Close();
      }
    }
}
