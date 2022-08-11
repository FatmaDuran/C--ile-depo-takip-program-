using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
   public class StokIslemleri
    {
       public static string ConnectionStr { get; set; }

       public static DataSet getStokByIds(int urunid,int birimid,int depoid )
       {
           SqlConnection conn = new SqlConnection(ConnectionStr);
           string sql = "select * from Stok where UrunID=@uid and BirimID=@Bid and DepoID=@depoid";
           SqlCommand komut = new SqlCommand(sql, conn);
           komut.Parameters.AddWithValue("@uid",urunid );
            komut.Parameters.AddWithValue("@Bid", birimid);
            komut.Parameters.AddWithValue("@depoid", depoid);
           SqlDataAdapter adp = new SqlDataAdapter(komut);
           DataSet ds = new DataSet();
           adp.Fill(ds);

           return ds;
       }
       public static DataSet getadetbystokid(int id)
       {
           SqlConnection conn = new SqlConnection(ConnectionStr);
           string sql = "select adet from Stok where StokID=@sID";
           SqlCommand komut = new SqlCommand(sql, conn);
           komut.Parameters.AddWithValue("@sID", id);
           SqlDataAdapter adp = new SqlDataAdapter(komut);
           DataSet ds = new DataSet();
           adp.Fill(ds);
           return ds;
       }
       public static DataSet listStok(int id)
       {
           SqlConnection bag = new SqlConnection(ConnectionStr);
           bag.Open();
           string sorgu = "Select * from Stok where StokID=@id";
           SqlCommand komut = new SqlCommand(sorgu, bag);
           komut.Parameters.AddWithValue("@id", id);
           SqlDataAdapter adp = new SqlDataAdapter(komut);
           DataSet sonuc = new DataSet();
           adp.Fill(sonuc);
           bag.Close();

           return sonuc;
       }
       public static void UpdateStokByids(int stokid,int adett)
       {
           SqlConnection connection = new SqlConnection(ConnectionStr);
           connection.Open();
           string sql = "UPDATE Stok SET adet=@adet where StokID=@id";
           SqlCommand komut = new SqlCommand(sql, connection);
           komut.Parameters.AddWithValue("@id", stokid);
           komut.Parameters.AddWithValue("@adet", adett);
           komut.ExecuteNonQuery();
           connection.Close();
       }

       public static DataSet StokCek()
       {
           SqlConnection conn = new SqlConnection(ConnectionStr);

           string sql = @"SELECT u.UrunAdi as Urun,u.UrunID,
                       b.BirimAdi as Birim,b.BirimID,
                       d.DepoAdi as Depo,d.DepoID,
                       s.adet as Adet 
                       FROM Stok as s
                       inner join urunler as u on u.UrunID=s.UrunID
                       inner join Birimler as b on b.BirimID=s.BirimID
                       inner join Depolar as d on d.DepoID=s.DepoID";

           SqlCommand komut = new SqlCommand(sql, conn);
           SqlDataAdapter adp = new SqlDataAdapter(komut);
           DataSet ds = new DataSet();
           adp.Fill(ds);
           return ds;
       }
    }
}
