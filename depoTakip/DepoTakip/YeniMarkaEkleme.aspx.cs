using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepoTakip
{
    public partial class YeniMarkaEkleme : System.Web.UI.Page
    {
        public static string ConnectionStr { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            MarkaDoldur();
        }

        private void MarkaDoldur()
        {
            DataSet marka = new DataSet();
            DAL.UrunIslemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DByolu"].ToString();
            marka = DAL.MarkaIslemleri.listMarka();
            GridViewMarka.DataSource = marka.Tables[0];
            GridViewMarka.DataBind();

        }

        protected void GridViewMarka_SelectedIndexChanged(object sender, EventArgs e)
        {

            int secili;
            secili = GridViewMarka.SelectedIndex;

            GridViewRow row = GridViewMarka.Rows[secili];
           // DataRow dr = ((DataTable)GridViewMarka.DataSource).Rows[secili];

            int markaid = int.Parse(GridViewMarka.DataKeys[secili].Value.ToString());
            ViewState["markaid"] = markaid;

          //  TxtMarka.Text = dr["MarkaAdi"].ToString();

            DataSet ds = new DataSet();
            ds = DAL.MarkaIslemleri.getMarkabyID(markaid);
            TxtMarka.Text = ds.Tables[0].Rows[0]["MarkaAdi"].ToString();
        }


        protected void BTNMarkaEkle_Click(object sender, EventArgs e)
        {
            string ymarka = TxtMarka.Text;

            DAL.MarkaIslemleri.AddNewMarka(ymarka);

            MarkaDoldur();
        
            TxtMarka.Text = string.Empty;
        }

        protected void BtnSil_Click(object sender, EventArgs e)
        {
            //int id = (int)ViewState["urungrupid"];   //tabloda seçilen id oturum kapatılana kadar tutuldu
            //DAL.UrunIslemleri.DeleteUrunGrubu(id);

            //UrunGrubuDoldur();

            //TxtYeniGrup.Text = string.Empty;
            DAL.MarkaIslemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DBYolu"].ToString();

            int id = (int)ViewState["markaid"];

            DAL.MarkaIslemleri.DeleteMarka(id);

            MarkaDoldur();

            TxtMarka.Text = string.Empty;
        }

        protected void BtnGüncelle_Click(object sender, EventArgs e)
        {
            string marka = TxtMarka.Text;

            int markaid = (int)ViewState["markaid"];

            DAL.MarkaIslemleri.UpdateMarka(marka, markaid);

            MarkaDoldur();

            TxtMarka.Text = string.Empty;
        }
    }
}