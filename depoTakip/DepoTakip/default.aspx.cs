using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DepoTakip
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("DepoyaGirisCikisYap.aspx");
            Response.Redirect("DepoGirisCikisYap.aspx");
        }

       
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("DepoGirisCikisSorgu.aspx");
        }

        
        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("KullaniciBilgileri.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("BirimYönetimi.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {

        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("MevcutSorgulama.aspx");
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            Response.Redirect("UrunBilgileri.aspx");
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            Response.Redirect("KullaniciGirisi.aspx");
        }

    }
}