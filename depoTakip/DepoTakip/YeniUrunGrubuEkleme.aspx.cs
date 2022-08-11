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
    public partial class YeniUrunGrubuEkleme : System.Web.UI.Page
    {   
        public string ConnectionString { get; set; }
      
        protected void Page_Load(object sender, EventArgs e)
        {
            UrunGrubuDoldur();
            
        }

     

        protected void GrdviewUrunGrup_SelectedIndexChanged(object sender, EventArgs e)
        {    

            int secili;
            secili = GrdviewUrunGrup.SelectedIndex;

            GridViewRow row = GrdviewUrunGrup.Rows[secili];
            int urungrupid = int.Parse(GrdviewUrunGrup.DataKeys[secili].Value.ToString());
            ViewState["urungrupid"] = urungrupid;

            DataSet ds = new DataSet();
            ds = DAL.UrunIslemleri.getUrunByid(urungrupid);
            TxtYeniGrup.Text = ds.Tables[0].Rows[0]["UrunGrubu"].ToString();

            //DataRow dr = ((DataTable)GrdviewUrunGrup.DataSource).Rows[secili];

            //TxtYeniGrup.Text = dr["UrunGrubu"].ToString();
            //Session["urunid"] = dr["UrunID"].ToString();
        }

     
        private void UrunGrubuDoldur()
        {
            DataSet urungrupları = new DataSet();
            DAL.UrunIslemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DByolu"].ToString();
            urungrupları = DAL.UrunIslemleri.listUrunGrubu();
            GrdviewUrunGrup.DataSource = urungrupları.Tables[0];
            GrdviewUrunGrup.DataBind();
        }
   protected void Btngrupekle_Click(object sender, EventArgs e)
        {

            string ygrup = TxtYeniGrup.Text;
            DAL.UrunIslemleri.YeniGrupEkle(ygrup);

            UrunGrubuDoldur();

            TxtYeniGrup.Text = string.Empty;
        }

        protected void BtnSil_Click(object sender, EventArgs e)
        {

            int id = (int)ViewState["urungrupid"];   //tabloda seçilen id oturum kapatılana kadar tutuldu
            DAL.UrunIslemleri.DeleteUrunGrubu(id);

            UrunGrubuDoldur();

            TxtYeniGrup.Text = string.Empty;
           
        } 
        protected void BtnGüncelle_Click(object sender, EventArgs e)
        {
            string grup = TxtYeniGrup.Text;

           int urungrupid = (int)ViewState["urungrupid"];

           DAL.UrunIslemleri.UpdateUrunGrubu(grup, urungrupid);

           UrunGrubuDoldur();

           TxtYeniGrup.Text = string.Empty;

              
        }
        protected void BtnGeri_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx");
        }

     
    }
}