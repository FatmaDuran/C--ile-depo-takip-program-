using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace DepoTakip
{
    public partial class KisiBilgileri : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bindKullaniciBilgileri();

            if (!IsPostBack)
            {
                string by = ConfigurationManager.ConnectionStrings["DByolu"].ToString();
                SqlConnection con = new SqlConnection(by);
                SqlCommand com = new SqlCommand("SELECT BirimID,BirimAdi FROM Birimler", con);
                try
                {
                    con.Open();
                    SqlDataReader read = com.ExecuteReader();
                    DDLbirim.DataSource = read;
                    DDLbirim.DataValueField = "BirimID";
                    DDLbirim.DataTextField = "BirimAdi";

                    DDLbirim.DataBind();
                    read.Close();
                }
                finally
                {
                    con.Close();
                }
            }
        }
        private void bindKullaniciBilgileri()  //baglantı adresi connectionstr ye eşitlendi DAL de kullanılıyor
        {
            DataSet ds = new DataSet();
            DAL.KullaniciIslemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DByolu"].ToString();
            ds = DAL.KullaniciIslemleri.KullanicilariCek();
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            string kuladii = TxtkulAdi.Text;
            string sifree = Txtsifre.Text;
            string add = TxtAd.Text;
            string soyadd = TxtSoyad.Text;
            int roll = 0;
            int.TryParse(DDLrol.SelectedValue.ToString(), out roll);
            string maill = TxtMail.Text;
       
            if (DDLbirim.SelectedIndex >= 0 && !string.IsNullOrWhiteSpace(DDLbirim.SelectedValue))
            {
                birimm  = int.Parse(DDLbirim.SelectedValue);
            }

            DAL.KullaniciIslemleri.KulBilgileriEkle(kuladii,sifree,add,soyadd,roll,maill,birimm);

            DataSet ds1 = new DataSet();
            ds1 = DAL.KullaniciIslemleri.KullanicilariCek();
            GridView1.DataSource = ds1.Tables[0];
            GridView1.DataBind();

            TxtkulAdi.Text = string.Empty;
            TxtAd.Text = string.Empty;
            TxtSoyad.Text = string.Empty;
            Txtsifre.Text = string.Empty;
            TxtMail.Text = string.Empty;

          
        }
        protected void BtnSil_Click(object sender, EventArgs e)
        {
            string kullaniciadi = TxtkulAdi.Text;
            DAL.KullaniciIslemleri.KulBilgileriSil(kullaniciadi);

            TxtkulAdi.Text = string.Empty;
            TxtAd.Text = string.Empty;
            TxtSoyad.Text = string.Empty;
            Txtsifre.Text = string.Empty;
            TxtMail.Text = string.Empty;

            KullanicilariDoldur();
        }

        private void KullanicilariDoldur()
        {

            DataSet ds2 = new DataSet();
            ds2 = DAL.KullaniciIslemleri.KullanicilariCek();
            GridView1.DataSource = ds2.Tables[0];
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string ykuladii = TxtkulAdi.Text;
            string ysifree = Txtsifre.Text;
            string yadd = TxtAd.Text;
            string ysoyadd = TxtSoyad.Text;
            int yroll = 0;
            int.TryParse(DDLrol.SelectedValue.ToString(), out yroll);
            string ymaill = TxtMail.Text;

            if (DDLbirim.SelectedIndex >= 0 && !string.IsNullOrWhiteSpace(DDLbirim.SelectedValue))
            {
                ybirimm = int.Parse(DDLbirim.SelectedValue);
            }

            DAL.KullaniciIslemleri.KulBilgileriGüncelle(ykuladii, ysifree, yadd, ysoyadd, yroll, ymaill, ybirimm);

            KullanicilariDoldur();

            TxtkulAdi.Text = string.Empty;
            TxtAd.Text = string.Empty;
            TxtSoyad.Text = string.Empty;
            Txtsifre.Text = string.Empty;
            TxtMail.Text = string.Empty;
         //   DDLbirim.SelectedValue = string.Empty;

          
        }
  
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secili;
            int roll = 0;
            int.TryParse(DDLrol.SelectedValue.ToString(), out roll);
            if (DDLbirim.SelectedIndex >= 0 && !string.IsNullOrWhiteSpace(DDLbirim.SelectedValue))
            {
                birimm = int.Parse(DDLbirim.SelectedValue);
            }

           secili = GridView1.SelectedIndex;
            
            GridViewRow row = GridView1.Rows[secili];
            DataRow dr =  ((DataTable)GridView1.DataSource).Rows[secili];
       //   TxtkulAdi.Text = DAL.KullaniciIslemleri.KulAdiBul(((DataTable)GridView1.DataSource).Rows[secili];

           TxtkulAdi.Text=dr["KullaniciAdi"].ToString();
            Txtsifre.Text=dr["Sifre"].ToString();
            TxtAd.Text = dr["Adı"].ToString();
            TxtSoyad.Text = dr["Soyadı"].ToString();
            TxtMail.Text = dr["Mail adresi"].ToString();
            DDLbirim.SelectedValue =dr["BirimID"].ToString();
            DDLrol.SelectedValue = dr["Rolü"].ToString();

        }
    
        public object Ad { get; set; }

        public object sifre { get; set; }

        public object kuladi { get; set; }

        public object soyad { get; set; }

        public object rol { get; set; }

        public object mail { get; set; }

        public object birim { get; set; }

        public string ConnectionStr { get; set; }

        public int birimm { get; set; }

        public int ybirimm { get; set; }

    }
}