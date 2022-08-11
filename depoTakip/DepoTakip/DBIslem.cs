using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DepoTakip
{

    public class DBIslem
    {
        static string by = ConfigurationManager.ConnectionStrings["DBYolu"].ToString();

         /*public static bool KullaniciKontrol(string kullaniciAdi, string sifre)
        {
           string by = ConfigurationManager.ConnectionStrings["DByolu"].ToString();
            SqlConnection conn = new SqlConnection(by);
            string sql = "select * from Kullanicilar where KullaniciAdi=@kulAdi and Sifre=@sifre ";
            SqlCommand komut = new SqlCommand(sql, conn);
            conn.Open();
            bool sonuc = false;
            SqlDataAdapter adaptor = new SqlDataAdapter(komut);
            komut.Parameters.AddWithValue("@kulAdi", kullaniciAdi);
            komut.Parameters.AddWithValue("@sifre", sifre);

            DataSet sonuclar = new DataSet();
            adaptor.Fill(sonuclar);
            conn.Close();

            if (sonuclar.Tables[0].Rows.Count > 0)
                sonuc = true;
            return sonuc;
        }*/
        
      /*  public static DataSet KullaniciCek()
        {
            SqlConnection con = new SqlConnection(by);
            string sorgu= "Select k.Adı,k.Soyadı,k.Rolü,k.[Mail adresi],b.BirimAdi from Kullanicilar as k inner join Birimler as b on b.BolumID=k.BolumID ";
            SqlCommand komut = new SqlCommand(sorgu, con);

            SqlDataAdapter adp = new SqlDataAdapter(komut);

            DataSet sonuc = new DataSet();
            con.Open();
            adp.Fill(sonuc);

            con.Close();

            return sonuc;*/
        }

    }