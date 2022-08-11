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
    public partial class UrunBilgileri : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               //sessionlar null
               
                Session["urunid"]=null;
                Session["markaid"] = null;
                Session["marka"] = null;


                UrunGruplarınıDoldur();
           
                bindUrunBilgileri();

                //if(Session["urungrubuid"]!=null)
                //{
                //    ChcbxMarka_CheckedChanged(this, null);
                //}
            }
           
        }

        private void StoreModel()
        {
            DataSet ds = new DataSet();
            ds = DAL.ModelIslem.listModel();
     
            DDLModel.DataSource = ds.Tables[0];
            DDLModel.DataBind();
        }

        private void StoreMarka()
        {
            DataSet ds = new DataSet();
            ds = DAL.MarkaIslemleri.listMarka();
           
            DDLMarka.DataSource = ds.Tables[0];
            DDLMarka.DataBind();
        }

        private void UrunGruplarınıDoldur()
        {
            DataSet urungrupları = new DataSet();
            DAL.UrunIslemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DByolu"].ToString();
            urungrupları = DAL.UrunIslemleri.listUrunGrubu();
            DDLUrunGrubu.DataSource = urungrupları.Tables[0];
            DDLUrunGrubu.DataBind();
        }
       
            private void bindUrunBilgileri()
            {
                DataSet ds = new DataSet();
                DAL.UrunIslemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DBYolu"].ToString();
                ds= DAL.UrunIslemleri.UrunBilgileriCek();
                GridViewUrunBilgileri.DataSource = ds.Tables[0];
                GridViewUrunBilgileri.DataBind();

            }
           protected void btnEkle_Click(object sender, EventArgs e)
            {

                int urungrup = Convert.ToInt32(DDLUrunGrubu.SelectedValue.ToString());
               // int marka = Convert.ToInt32(DDLMarka.SelectedValue.ToString());
                int model = Convert.ToInt32(DDLModel.SelectedValue.ToString());
                string uad=txtUrunAdi.Text;
               txtUrunAdi.Text = DDLUrunGrubu.SelectedItem.Text + '/' + DDLModel.SelectedItem;
                string limit =  txtHaberlimit.Text;

                DAL.UrunIslemleri.UrunEkle(urungrup,model,uad,limit);

                StoreDataBindUrun();

                txtUrunAdi.Text = string.Empty;
                DDLUrunGrubu.Items.Clear();
                DDLMarka.Items.Clear();
                DDLModel.Items.Clear();
                txtHaberlimit.Text = string.Empty;

            }
           protected void btnSil_Click(object sender, EventArgs e)
            {
                int id=(int)Session["urunid"];

               DAL.UrunIslemleri.UrunSil(id);

                StoreDataBindUrun();

                txtUrunAdi.Text = string.Empty;
                DDLUrunGrubu.Items.Clear();
                DDLMarka.Items.Clear();
                DDLModel.Items.Clear();
                txtHaberlimit.Text = string.Empty;
            }

            protected void btnGuncelle_Click(object sender, EventArgs e)
            {
                int urungrup = int.Parse(DDLUrunGrubu.SelectedValue);
                 int umodel = int.Parse(DDLModel.SelectedValue);
                string urunad = txtUrunAdi.Text;
                txtUrunAdi.Text = DDLUrunGrubu.SelectedItem.Text + '/' + DDLModel.SelectedItem;
              //  int umarkaa = int.Parse(DDLMarka.SelectedValue.ToString());
               
                
                int limit = int.Parse(txtHaberlimit.Text);
                int secilen;
                secilen = GridViewUrunBilgileri.SelectedIndex;
                GridViewRow row = GridViewUrunBilgileri.Rows[secilen];

                int id1 = int.Parse(GridViewUrunBilgileri.DataKeys[secilen].Value.ToString());
                ViewState["Urunid"] = id1;

               DAL.UrunIslemleri.UrunGuncelle( urunad,urungrup, umodel,limit,id1);

                StoreDataBindUrun();

                DDLUrunGrubu.SelectedIndex = 0;
                txtUrunAdi.Text = string.Empty;
               
                DDLMarka.Items.Clear();
                DDLModel.Items.Clear();
                txtHaberlimit.Text = string.Empty;
            }

            private void StoreDataBindUrun()
            {
                DataSet ds = new DataSet();
                ds = DAL.UrunIslemleri.UrunBilgileriCek();
                GridViewUrunBilgileri.DataSource = ds.Tables[0];
                GridViewUrunBilgileri.DataBind();
            }

            protected void GridViewUrunBilgileri_SelectedIndexChanged(object sender, EventArgs e)
            {

                DAL.MarkaIslemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DBYolu"].ToString();
                DAL.ModelIslem.ConnectionStr = ConfigurationManager.ConnectionStrings["DBYolu"].ToString();

                int secilen;
                secilen = GridViewUrunBilgileri.SelectedIndex;
                GridViewRow row = GridViewUrunBilgileri.Rows[secilen];
         
                Session["urunid"] = GridViewUrunBilgileri.SelectedDataKey.Value;

                DataSet ds = new DataSet();
                ds = DAL.UrunIslemleri.getUrunBilgisiByid((int)Session["urunid"]);

                DataRow dr =  ds.Tables[0].Rows[0];    

                txtUrunAdi.Text = dr["UrunAdi"].ToString();

                int urunGrupID = Convert.ToInt32(dr["UrunGrupID"].ToString());

                Session["urungrubuid"] = urunGrupID;
                UrunGrubunaGoreMarkaDoldur();

                int markaID = int.Parse(dr["MarkaID"].ToString());
                MarkayaGoreModelDoldur(markaID);

                DDLUrunGrubu.SelectedIndex = DDLUrunGrubu.Items.IndexOf(DDLUrunGrubu.Items.FindByValue(urunGrupID.ToString()));

                DDLMarka.SelectedIndex = DDLMarka.Items.IndexOf(DDLMarka.Items.FindByValue(markaID.ToString()));
                DDLModel.SelectedIndex = DDLModel.Items.IndexOf(DDLModel.Items.FindByValue(dr["ModelID"].ToString()));

                txtHaberlimit.Text = dr["Limit"].ToString();

              //  int urungrup = Convert.ToInt32(dr["UrunGrupID"]);

  
                
            }

            private void DDLModelDoldur()
            {

                DataSet model = new DataSet();
                DAL.ModelIslem.ConnectionStr = ConfigurationManager.ConnectionStrings["DBYolu"].ToString();
                model = DAL.ModelIslem.listModel();
                DDLModel.DataSource = model.Tables[0];
                DDLModel.DataBind();
            }

            private void DDLMarkaDoldur()
            {
                DataSet marka = new DataSet();
                DAL.MarkaIslemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DBYolu"].ToString();
                marka = DAL.MarkaIslemleri.listMarka();
                DDLMarka.DataSource = marka.Tables[0];
                DDLMarka.DataBind();
            }
            protected void DDLMarka_SelectedIndexChanged(object sender, EventArgs e)
            {
                
                    DAL.ModelIslem.ConnectionStr = ConfigurationManager.ConnectionStrings["DByolu"].ToString();
                    int id2 = int.Parse(DDLMarka.SelectedValue);
                    MarkayaGoreModelDoldur(id2);
            }

            private void MarkayaGoreModelDoldur(int id2)
            {
                DataSet model = DAL.ModelIslem.listModelByMarkaID(id2);
                DDLModel.DataSource = model.Tables[0];
                DDLModel.DataBind();

                Session["markaid"] = DDLMarka.SelectedValue;
                Session["marka"] = DDLMarka.SelectedItem.ToString();
            }


        protected void DDLUrunGrubu_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["urungrubuid"] = DDLUrunGrubu.SelectedValue;

            UrunGrubunaGoreMarkaDoldur();        
        }

        private void UrunGrubunaGoreMarkaDoldur(int urunGrupID =0)
        {
            DAL.MarkaIslemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DByolu"].ToString();
            int id = urunGrupID;
            if (id == 0 && Session["urungrubuid"] != null)
            {
                id = Convert.ToInt32(Session["urungrubuid"]);
            }

            DataSet marka = DAL.MarkaIslemleri.listMarkaByUrungrupID(id);
            DDLMarka.Items.Clear();
            DDLMarka.DataSource = marka.Tables[0];
            DDLMarka.DataBind();
        }

        protected void DDLModel_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            string urungrubu = DDLUrunGrubu.SelectedItem.ToString();
            string marka = DDLMarka.SelectedItem.ToString();
            string model = DDLModel.SelectedItem.ToString();

            txtUrunAdi.Text=urungrubu+'_'+marka+'_'+model;
        }

        protected void btnYeniGrup_Click(object sender, EventArgs e)
        {
          Response.Redirect("YeniUrunGrubuEkleme.aspx");
        }

        protected void BtnYeniMarka_Click(object sender, EventArgs e)
        {
         Response.Redirect("YeniMarkaEkleme.aspx");
        }

        protected void BtnYeniModel_Click(object sender, EventArgs e)
        {
            Response.Redirect("YeniModelEkleme.aspx");
            int id=int.Parse(DDLMarka.SelectedValue);
        }

        protected void ChcbxMarka_CheckedChanged(object sender, EventArgs e)
        {
            // If (ChcbxMarka.Checked==true)
            //{
          
            //}
            if(ChcbxMarka.Checked)
            {
                DDLMarkaDoldur();

                //int id = int.Parse(DDLMarka.SelectedValue.ToString());
                //Session["markaid"] = DDLMarka.SelectedValue;
                //Session["marka"] = DDLMarka.SelectedItem.ToString();

            }
            else
            {
                UrunGrubunaGoreMarkaDoldur();
            }
           //if (checkItem != null)
           // {
           //     DropDownList1.ClearSelection();
           //     checkItem.Selected = true;
           // }
        }

        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx");
        }    
    }
}