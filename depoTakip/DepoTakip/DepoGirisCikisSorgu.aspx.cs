using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace DepoTakip
{
    public partial class DepoyaGirisSorgu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DataSet ds = new DataSet();
            DAL.Islemislemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DBYolu"].ToString();
            ds = DAL.Islemislemleri.IslemCek();
            GridViewGirisCikisSorgu.DataSource = ds.Tables[0];
            GridViewGirisCikisSorgu.DataBind();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void GridViewGirisCikisSorgu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}