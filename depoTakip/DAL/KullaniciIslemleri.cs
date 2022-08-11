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
    public class KullaniciIslemleri
    {
        //private static object rol;
        //private static object birim;
        public static string ConnectionStr { get; set; }

        public static bool KullaniciKontrol(string kullaniciAdi, string sifre)
        {
           
            SqlConnection conn = new SqlConnection(ConnectionStr);
            conn.Open();
            string sql = "select * from Kullanicilar where KullaniciAdi=@pkullaniciAdi and Sifre=@psifre ";

            SqlCommand komut = new SqlCommand(sql, conn);
           
           
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            komut.Parameters.AddWithValue("@pkullaniciAdi", kullaniciAdi);
            komut.Parameters.AddWithValue("@psifre", sifre);
            DataSet sonuclar = new DataSet();
            adaptor.Fill(sonuclar);
            conn.Close();
           
            return sonuclar.Tables[0].Rows.Count > 0;
        }
        public static int IdAl(string kullaniciadi)
        {
            
            SqlConnection conn = new SqlConnection(ConnectionStr);
          string sql = "select KullaniciID from Kullanicilar where KullaniciAdi=@pkullaniciAdi";
            SqlCommand komut = new SqlCommand(sql, conn);
            komut.Parameters.AddWithValue("@pkullaniciAdi", kullaniciadi);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            int id = Convert.ToInt32(ds.Tables[0].Rows[0]["KullaniciID"]);
            return id;
        }
        public static DataSet KullanicilariCek()
        {

            SqlConnection bag = new SqlConnection(ConnectionStr);
            bag.Open();
            string sorgu = "Select k.KullaniciID,k.KullaniciAdi,k.Sifre, k.Adı as Adı,k.Soyadı,k.Rolü,k.[Mail adresi],b.BirimAdi,b.BirimID  from Kullanicilar as k inner join Birimler as b on b.BirimID=k.BirimID ";
            SqlCommand komut = new SqlCommand(sorgu, bag);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            DataSet sonuc = new DataSet();
            adp.Fill(sonuc);
            bag.Close();
            return sonuc;
        }
        public static void KulBilgileriEkle(string kuladi, string sifre, string ad, string soyad,int rol, string mail,int birim)
        {
            SqlConnection conn = new SqlConnection(ConnectionStr);
            conn.Open();
            string sql = "insert into Kullanicilar(KullaniciAdi,Sifre,Adı,Soyadı,Rolü,[Mail adresi],BirimID) values (@kulAdi,@sifre,@ad,@soyad,@rol,@mail,@birim)";
            SqlCommand komut = new SqlCommand(sql, conn);
            komut.Parameters.AddWithValue("@kulAdi", kuladi);
            komut.Parameters.AddWithValue("@sifre", sifre);
            komut.Parameters.AddWithValue("@ad", ad);
            komut.Parameters.AddWithValue("@soyad", soyad);
            komut.Parameters.AddWithValue("@rol", rol);
            komut.Parameters.AddWithValue("@mail", mail);
            komut.Parameters.AddWithValue("@birim", birim);
            komut.ExecuteNonQuery();
            conn.Close();

        }
        
        public static void KulBilgileriSil(string kuladi)
        {
            SqlConnection connection = new SqlConnection(ConnectionStr);
            connection.Open();
            string sql = "delete from Kullanicilar where KullaniciAdi=@kadi";
            SqlCommand komut = new SqlCommand(sql,connection);
            komut.Parameters.AddWithValue("@kadi",kuladi);
            komut.ExecuteNonQuery();
            connection.Close();
        }
        public static void KulBilgileriGüncelle(string yenikulAdi, string yenisifre, string yeniad, string yenisoyad, int yenirol, string yenimail, int yenibirim)
        {
            SqlConnection baglanti = new SqlConnection(ConnectionStr);
            string sql1 = " UPDATE Kullanicilar SET Sifre=@ysifre,Adı=@yadi,Soyadı=@ysoyadi,Rolü=@yrol,[Mail adresi]=@ymail,BirimID=@ybirim WHERE KullaniciAdi=@ykadi";
            SqlCommand komut = new SqlCommand(sql1, baglanti);
           // komut.Parameters.AddWithValue("@id", id);
            komut.Parameters.AddWithValue("@ykadi", yenikulAdi);
            komut.Parameters.AddWithValue("@ysifre", yenisifre);
            komut.Parameters.AddWithValue("@yadi", yeniad);
            komut.Parameters.AddWithValue("@ysoyadi", yenisoyad);
            komut.Parameters.AddWithValue("@yrol", yenirol);
            komut.Parameters.AddWithValue("@ymail", yenimail);
            komut.Parameters.AddWithValue("@ybirim", yenibirim);
            baglanti.Open();
            komut.ExecuteNonQuery();
          
            baglanti.Close();

        }
    /*    public static bool KulAdiVarMi()
        {
            SqlConnection bag = new SqlConnection();
            bag.Open();
            string sql2 = "select KullaniciAdi from Kullanicilar where KullaniciID=@id";
            SqlCommand komut = new SqlCommand(sql2, bag);
            komut.Parameters.AddWithValue("@id", Kulid);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            adp.Fill(ds, "Kullanicilar");
            return ds;
        }*/
       

    }
}