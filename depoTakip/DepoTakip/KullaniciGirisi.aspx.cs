using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DepoTakip.Utility;


namespace DepoTakip
{
    public partial class KullaniciGirisi : System.Web.UI.Page
    {
        //static string baglantiYolu = ConfigurationManager.ConnectionStrings["bY"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
      public bool giris = false;

        protected void Button1_Click1(object sender, EventArgs e)
        {

           string by = ConfigurationManager.ConnectionStrings["DByolu"].ToString();

            string kAdi = txtKAdi.Text;
            string sifre = txtSifre.Text;

            string connetionString = null;
            SqlConnection sqlCnn;
            SqlCommand sqlCmd;
            string sql = null;

            connetionString = by;
            sql = "Select * from Kullanicilar where KullaniciAdi='" + kAdi + "' and Sifre='" + sifre + "'";
            sqlCnn = new SqlConnection(connetionString);
            try
            {
                sqlCnn.Open();
                sqlCmd = new SqlCommand(sql, sqlCnn);
                SqlDataReader oku = sqlCmd.ExecuteReader();
                if (oku.Read())
                {
                    //MessageBox.Show(sqlReader.GetValue(0) + " - " + sqlReader.GetValue(1) + " - " + sqlReader.GetValue(2));
                    Session.Add("kullanıcı", kAdi);
                   
                    Session["KullaniciID"] = oku["KullaniciID"].ToString();
                    Session["AdiSoyadi"] = oku["Adı"].ToString() + " " + oku["Soyadı"].ToString();
                    Session["BirimID"] = oku["BirimID"].ToString();
                    Response.Redirect("default.aspx?giris=true");
                }
                else
                {
                    Response.Write("Kulanıcı Adı ya da Şifre Hatalı");
                }
                oku.Close();
                sqlCmd.Dispose();
                sqlCnn.Close();
            }
            catch (Exception ex)
            {
                
                Response.Write("Can not open connection ! ");
            }


          //bool sonuc=  DAL.KullaniciIslemleri.KullaniciKontrol(kAdi, sifre);
           
          //  if(sonuc==true)
          //  {
          //      Session.Add("kullanıcı", kAdi);
          //         Session["giris"] = true;
          //         Session["KullaniciID"] = oku["KullaniciID"].ToString();
          //         Session["AdiSoyadi"] = oku["Adı"].ToString() + " " + oku["Soyadı"].ToString();
          //          Response.Redirect("default.aspx?giris=true");
                

          //  }
          //  else
          //  {
          //      Response.Write("Kulanıcı Adı ya da Şifre Hatalı");
          //  }



            
            //SqlConnection baglanti = new SqlConnection(by);
            //baglanti.Open();
            //string sql = "Select * from Kullanicilar where KullaniciAdi='" + kAdi + "' and Sifre='" + sifre + "'";
            //SqlCommand komut = new SqlCommand(sql, baglanti);
          
            //SqlDataReader oku = komut.ExecuteReader();
            //if(oku.Read())
            //{
            //    Session.Add("kullanıcı", kAdi);
            //    Session["giris"] = true;
                  
            //    //Session["KullaniciID"] = id;
            //    Response.Redirect("default.aspx?giris=true");
            //    giris = true;
            //}
            //else
            //{
            //    Response.Write("KullaniciAdi ya da Şifre Hatalı");
            //}

        }
    }
}