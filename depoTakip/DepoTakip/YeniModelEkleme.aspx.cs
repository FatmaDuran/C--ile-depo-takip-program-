using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepoTakip
{
    public partial class YeniModelEkleme : System.Web.UI.Page
    {
        public static string ConnectionStr { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            MarkaDoldur();
          //  int id=Convert.ToInt32(Session ["urungrubuid"].ToString());
           DDL2marka.SelectedValue = Session["markaid"].ToString();
             
            if(Session["markaid"]!=null)
            {
                ModelDoldur();
            }
           else
            {
                Console.WriteLine("Lütfen Marka Seçiniz");//gelmiyor ddl2marka.selectedvalue=sess..... nereye yazılmalı.
            }
        }

        private void ModelDoldur()
        {

            DataSet model = new DataSet();
            DAL.UrunIslemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DByolu"].ToString();
            model = DAL.ModelIslem.listModel();
            GridViewModel.DataSource = model.Tables[0];
            GridViewModel.DataBind();
        }

        private void MarkaDoldur()
        {
            DAL.MarkaIslemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DByolu"].ToString();
            DataSet marka = DAL.MarkaIslemleri.listMarka();
            DDL2marka.DataSource = marka.Tables[0];
            DDL2marka.DataBind();
        }

        protected void GridViewModel_SelectedIndexChanged(object sender, EventArgs e)
        {

            int secili;
            secili = GridViewModel.SelectedIndex;

            GridViewRow row = GridViewModel.Rows[secili];
            int modelid = int.Parse(GridViewModel.DataKeys[secili].Value.ToString());
            ViewState["modelid"] = modelid;
            DataSet ds = new DataSet();
            ds = DAL.ModelIslem.getModelbyID(modelid);

            TxtModel.Text = ds.Tables[0].Rows[0]["ModelAdi"].ToString();

           // DataRow dr = ((DataTable)GridViewModel.DataSource).Rows[secili];

            //int markaid = int.Parse(GridViewMarka.DataKeys[secili].Value.ToString());
            //Session["markaid"] = markaid;

           // TxtModel.Text = dr["ModelAdi"].ToString();

        }
     
        protected void BtnEkle_Click(object sender, EventArgs e)
        {

            int marka = Convert.ToInt32(DDL2marka.SelectedValue.ToString());
            string ymodel = TxtModel.Text;
          
            //DAL.UrunIslemleri.AddNewModel(ymodel,marka);
            DAL.ModelIslem.AddNewModel(ymodel, marka);

            ModelDoldur();

            TxtModel.Text = string.Empty;
        }

        protected void BtnSil_Click(object sender, EventArgs e)
        {
            //int marka = Convert.ToInt32(DDL2marka.SelectedValue.ToString());
            //string ymodel = TxtModel.Text;
            int id=(int)ViewState["modelid"];

            DAL.ModelIslem.DeleteModel(id);

            ModelDoldur();

            TxtModel.Text = string.Empty;
            
        }
       protected void BtnGüncelle_Click(object sender, EventArgs e)
        {
            string model = TxtModel.Text;
           int markaid=int.Parse(DDL2marka.SelectedValue.ToString());
           int modelid=(int)ViewState["modelid"];

           DAL.ModelIslem.UpdateModel(model, markaid, modelid);

           ModelDoldur();

           TxtModel.Text = string.Empty;
           DDL2marka.Items.Clear();

        }

        protected void ImgBtnGeri_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx");
        }
  

       
    }
}