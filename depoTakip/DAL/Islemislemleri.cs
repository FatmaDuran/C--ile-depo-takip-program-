using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Islemislemleri
    {
        public static string ConnectionStr { get; set; }

        public static DataSet listIslemTipi()
        {
            SqlConnection conn = new SqlConnection(ConnectionStr);
            string sql = "select * from IslemTipi";
            SqlCommand komut = new SqlCommand(sql, conn);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            return ds;
        }
        public static DataSet listIslem()
        {
            SqlConnection conn = new SqlConnection(ConnectionStr);
            string sql = "select * from Islem";
            SqlCommand komut = new SqlCommand(sql, conn);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            return ds;
        }
        public static DataSet IslemCek()
        {
            SqlConnection conn = new SqlConnection(ConnectionStr);
          
            string sql = @"  SELECT i.ID, a.IslemAdi,k.KullaniciAdi,
            s.DepoID as Depo,d.DepoAdi,s.UrunID as Urun,u.UrunAdi,ki.AdiSoyadi as VerilenKisi,
            f.FirmaAdi,i.Tarih,i.adet,i.Aciklama FROM Islem  as i 
             inner join IslemTipi as a on i.IslemTipiID = a.IslemTipiID
            inner join Kullanicilar as k on i.KullaniciID=k.KullaniciID
            inner join Stok as s on i.StokID=s.StokID  
            left join Kisiler as ki on i.KisiID=ki.KisiID
            left join Firmalar as f on i.FirmaID=f.FirmaID
            inner join Depolar as d on d.DepoID=s.DepoID
            inner join urunler as u on u.UrunID=s.UrunID";
            
            SqlCommand komut = new SqlCommand(sql, conn);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            adp.Fill(ds);

            return ds;
        }

        public static void AddNewIslem(int islemtipiId, int kulid, int stokid, string tarih, int kisiId, int firmaId, int adet,string aciklama)
        {

            SqlConnection bag = new SqlConnection(ConnectionStr);

            bag.Open();
            string sql = "insert into Islem(IslemTipiID,KullaniciID,StokID,Tarih,KisiID,FirmaID,adet,Aciklama) values(@islemtip,@kulid,@stokid,@trh,@kisid,@firmaid,@adet,@acik) ";
            SqlCommand komut = new SqlCommand(sql, bag);

            komut.Parameters.AddWithValue("@islemtip", islemtipiId);
            komut.Parameters.AddWithValue("@kulid", kulid);
            komut.Parameters.AddWithValue("@stokid", stokid);
            komut.Parameters.AddWithValue("@acik", aciklama);
            komut.Parameters.AddWithValue("@trh", tarih);
            if (kisiId == 0)
            {
                komut.Parameters.AddWithValue("@kisid", DBNull.Value);
            }
            else
            {
                komut.Parameters.AddWithValue("@kisid", kisiId);
            }
            if (firmaId == 0)
            {
                komut.Parameters.AddWithValue("@firmaid", DBNull.Value);
            }
            else
            {
                komut.Parameters.AddWithValue("@firmaid", firmaId);
            }

           // komut.Parameters.AddWithValue("@firmaid", DBNull.Value);
            komut.Parameters.AddWithValue("@adet", adet);
            komut.ExecuteNonQuery();
            bag.Close();


            //            if (uegParser.strPlanetName == "")
            //1
            //               cmd.Parameters.Add(new SqlParameter("@PN", SqlDbType.NVarChar).Value = DBNull.Value);
            //
            //           else
            //
            //               cmd.Parameters.Add(new SqlParameter("@PN", uegParser.strPlanetName));

        }
    }
}
