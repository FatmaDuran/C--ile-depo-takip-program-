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
    public partial class MevcutSorgulama : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataSet ds = new DataSet();
            //DAL.Islemislemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DBYolu"].ToString();
            //ds = DAL.Islemislemleri.IslemCek();
            //GridViewGirisCikisSorgu.DataSource = ds.Tables[0];
            //GridViewGirisCikisSorgu.DataBind();

            DataSet ds = new DataSet();
            DAL.StokIslemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DBYolu"].ToString();
            ds = DAL.StokIslemleri.StokCek();
            GridViewMevcutSorgu.DataSource = ds.Tables[0];
            GridViewMevcutSorgu.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}