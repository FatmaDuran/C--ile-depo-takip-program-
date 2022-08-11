using System;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
//using System.Web.HttpContext.Current.Session;

namespace DAL
{
   public class UrunIslemleri
    {
        public static string ConnectionStr { get; set; }
       
        public static DataSet UrunBilgileriCek()
        {
            SqlConnection baglanti = new SqlConnection(ConnectionStr);
            baglanti.Open();
            string sql = "SELECT u.UrunID,ug.UrunGrupID,a.MarkaID,m.ModelID,ug.UrunGrubu,m.ModelAdi as Model,a.MarkaAdi as Marka,u.UrunAdi,u.HaberLimiti as Limit  FROM Model as m inner join urunler as u on m.ModelID=u.ModelID inner join Marka as a on a.MarkaID=m.MarkaID inner join UrunGrubu as ug on u.UrunGrupID=ug.UrunGrupID ";
          //  string sql = "SELECT u.UrunID,u.UrunGrubu,m.ModelAdi as Model,a.MarkaAdi as Marka,u.UrunAdi,u.HaberLimiti as Limit  FROM Model as m inner join urunler as u on m.ModelID=u.ModelID inner join Marka as a on a.MarkaID=m.MarkaID inner join UrunGrubu as ug on u.UrunGrupID=ug.UrunGrupID ";
        //    string sql="SELECT u.UrunID ,m.ModelAdi as Model,a.MarkaAdi as Marka,u.UrunAdi,g.UrunGrubu,u.HaberLimiti as Limit  FROM Model as m inner join urunler as u on m.ModelID=u.ModelID inner join Marka as a on a.MarkaID=m.MarkaID inner join UrunGrubu as g on u.UrunGrupID=g.UrunGrupID";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            DataSet tablo = new DataSet();
            adp.Fill(tablo);
            baglanti.Close();
            return tablo;
        }
       public static DataSet getUrunBilgisiByid(int urunid)
       {
           SqlConnection baglanti = new SqlConnection(ConnectionStr);
           baglanti.Open();
           string sql = "SELECT u.UrunID,ug.UrunGrupID,a.MarkaID,m.ModelID,ug.UrunGrubu,m.ModelAdi as Model,a.MarkaAdi as Marka,u.UrunAdi,u.HaberLimiti as Limit  FROM Model as m inner join urunler as u on m.ModelID=u.ModelID inner join Marka as a on a.MarkaID=m.MarkaID inner join UrunGrubu as ug on u.UrunGrupID=ug.UrunGrupID where UrunID=@id";
          SqlCommand komut = new SqlCommand(sql, baglanti);
          komut.Parameters.AddWithValue("@id", urunid);
           SqlDataAdapter adp = new SqlDataAdapter(komut);
           DataSet tablo = new DataSet();
           adp.Fill(tablo);
           baglanti.Close();
           return tablo;
       }
        public static DataSet listUrunlerByDepoId(int id, int birimId)
        {
            SqlConnection baglanti = new SqlConnection(ConnectionStr);
            baglanti.Open();

            string sql = "select * from urunler as u inner join Stok as s on u.UrunID=s.UrunID where s.BirimID=@birimId and s.DepoID=@id";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@birimId", birimId);
            komut.Parameters.AddWithValue("@id", id);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            DataSet tablo = new DataSet();
            adp.Fill(tablo);
            baglanti.Close();
            return tablo;


        }
       public static DataSet getUrunByid(int id)
        {
            SqlConnection baglanti = new SqlConnection(ConnectionStr);
            baglanti.Open();

            string sql = "select * from UrunGrubu where UrunGrupID=@id";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@id", id);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            DataSet tablo = new DataSet();
            adp.Fill(tablo);
            baglanti.Close();
            return tablo;
        }
       public static void UrunEkle(int grup, int model, string ad, string limit)
        {
    
            SqlConnection bag = new SqlConnection(ConnectionStr);
            bag.Open();
            string sql = "insert into urunler(UrunAdi,ModelID,HaberLimiti,UrunGrupID) values (@uad,@umodel,@ulimit,@grup)   ";
            SqlCommand komut = new SqlCommand(sql, bag);

           komut.Parameters.AddWithValue("@uad",ad);
           komut.Parameters.AddWithValue("@umodel",model);
           komut.Parameters.AddWithValue("@ulimit", limit);
           komut.Parameters.AddWithValue("@grup", grup);
           komut.ExecuteNonQuery();
           bag.Close();
        }
     public static void UrunSil(int id)
       {
           SqlConnection con = new SqlConnection(ConnectionStr);
           con.Open();
           string sorgu = "delete from urunler where UrunID=@id";
           SqlCommand kmt = new SqlCommand(sorgu,con);
           kmt.Parameters.AddWithValue("@id",id);
           kmt.ExecuteNonQuery();
           con.Close();
       }
     public static void UrunGuncelle(string yad, int grupid, int ymodel, int limit, int id)
       {
           SqlConnection connection = new SqlConnection(ConnectionStr);
           connection.Open();
           string sql3 = "UPDATE urunler SET UrunAdi=@yuad,ModelID=@yumo,UrunGrupID=@grupid,HaberLimiti=@hlimit where UrunID=@id";
           SqlCommand komut = new SqlCommand(sql3, connection);

            komut.Parameters.AddWithValue("@id",id );
           komut.Parameters.AddWithValue("@yuad",yad);
           komut.Parameters.AddWithValue("@grupid", grupid);
           komut.Parameters.AddWithValue("@yumo",ymodel);
         komut.Parameters.AddWithValue("@hlimit", limit);

           komut.ExecuteNonQuery();
           connection.Close();
       }
       public static DataSet listUrunGrubu()
       {

           SqlConnection conn = new SqlConnection(ConnectionStr);
           string sql = "select * from UrunGrubu";
           SqlCommand komut = new SqlCommand(sql, conn);
           SqlDataAdapter adp = new SqlDataAdapter(komut);
           DataSet ds = new DataSet();
           adp.Fill(ds);

           return ds;
       }


       public static void YeniGrupEkle(string grup)
       {


           SqlConnection con = new SqlConnection(ConnectionStr);
           con.Open();
           string sql = "insert into UrunGrubu(UrunGrubu) values (@grup)";
           SqlCommand kom = new SqlCommand(sql, con);
           //kom.Parameters.AddWithValue("@id", id);
           kom.Parameters.AddWithValue("@grup", grup);
           kom.ExecuteNonQuery();
           con.Close();
       }

       
       public static void DeleteUrunGrubu(int grupid)
       {
           SqlConnection connection = new SqlConnection(ConnectionStr);
           connection.Open();
           string sql = "delete from UrunGrubu where UrunGrupID=@grupid";
           SqlCommand komut = new SqlCommand(sql, connection);
            komut.Parameters.AddWithValue("@grupid", grupid);
          komut.ExecuteNonQuery();
          connection.Close();
       
       }
      
     
       public static void UpdateUrunGrubu(string uGrubu,int id)
       {
           SqlConnection connection = new SqlConnection(ConnectionStr);
           connection.Open();
           string sql = "Update UrunGrubu SET UrunGrubu=@uGrup where UrunGrupID=@ID";
           SqlCommand komut = new SqlCommand(sql, connection);
           komut.Parameters.AddWithValue("@uGrup", uGrubu);
           komut.Parameters.AddWithValue("@ID", id);
           komut.ExecuteNonQuery();
           connection.Close();
       }
   
    }
}
