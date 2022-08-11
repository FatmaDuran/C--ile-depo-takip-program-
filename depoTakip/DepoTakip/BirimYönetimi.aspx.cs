using System;
using System.Web;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Web.UI.WebControls;

namespace DepoTakip
{
    public partial class BirimDüzenle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            DAL.BirimIslemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DByolu"].ToString();
        
             StoreDatabind();

        }

        private void StoreDatabind()
        {
            DataSet ds = new DataSet();
            ds = DAL.BirimIslemleri.BirimCek();
            GridView1Birim.DataSource = ds.Tables[0];
            GridView1Birim.DataBind();
        }

        public void GridView1Birim_SelectedIndexChanged(object sender, EventArgs e)
        {
            int secilen;
            secilen = GridView1Birim.SelectedIndex;
            GridViewRow row = GridView1Birim.Rows[secilen];

            int catid = int.Parse(GridView1Birim.DataKeys[secilen].Value.ToString());
            ViewState["Birimid"] = catid;

            DataSet ds = new DataSet();
            ds = DAL.BirimIslemleri.getBirimById(catid);
            TxbirimAd.Text = ds.Tables[0].Rows[0]["BirimAdi"].ToString();
            cbAktif.Checked = ds.Tables[0].Rows[0]["Aktiflik"].ToString() == "True" ? true : false;
        }
         //  RadioButtonList1.Items.FindByValue(ds.Tables[0].Rows[0]["Aktiflik"].ToString()=="True" ? "1":"0").Selected = ;

        protected void BtnBirimEkle_Click(object sender, EventArgs e)
        {
            // DataSet ds1 = new DataSet();
            //ds1 = DAL.BirimIslemleri.BirimCek();

            string ad = TxbirimAd.Text;
            bool aktif = cbAktif.Checked;

            DAL.BirimIslemleri.BirimInsert(ad, aktif);


            StoreDatabind();

            TxbirimAd.Text = string.Empty;
    
        }

           protected void BtnSil_Click(object sender, EventArgs e)
          {
              int id = (int)ViewState["Birimid"];   //tabloda seçilen id oturum kapatılana kadar tutuldu
              DAL.BirimIslemleri.BirimDelete(id);

              StoreDatabind();

              TxbirimAd.Text = string.Empty;
          }
           protected void BtnGüncelle_Click(object sender, EventArgs e)
          {
              string ad = TxbirimAd.Text;
              bool aktif = cbAktif.Checked;

              int secilen;
              secilen = GridView1Birim.SelectedIndex;
              GridViewRow row = GridView1Birim.Rows[secilen];

              int catid = int.Parse(GridView1Birim.DataKeys[secilen].Value.ToString());
              ViewState["Birimid"] = catid;
            
            
              DAL.BirimIslemleri.BirimUpdate(ad, aktif,catid);

              StoreDatabind();

              TxbirimAd.Text = string.Empty;
              
              
          }

        public int id { get; set; }

        public string ad { get; set; }

        public byte aktif { get; set; }

        public object catid { get; set; }

        protected void ImageBtnGri_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx");
        }

      
    }
}