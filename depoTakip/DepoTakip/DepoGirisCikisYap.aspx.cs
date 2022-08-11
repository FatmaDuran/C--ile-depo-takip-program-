using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using DepoTakip.Utility;
using System.Collections.Generic;

namespace DepoTakip
{
    public partial class DepoyaGiris : System.Web.UI.Page
    {
        public static string ConnectionStr { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TxtTarih.Text = DateTime.Now.ToShortDateString();

                IslemTipiDoldur();

                DepoDoldur();

                FirmaDoldur();

                KisiDoldur();

                //GridViewDepoGirisCikis.DataSource = Session["urunler"];
                //GridViewDepoGirisCikis.DataBind();


                //GridViewDepoGirisCikis.DataSource = Session["depo"];           
                //GridViewDepoGirisCikis.DataBind();
            }
        }

        private void KisiDoldur()
        {
            DAL.KisiIslemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DByolu"].ToString();
            DataSet kisiler = DAL.KisiIslemleri.listKisi();
            DDLVerilenKisi.DataSource = kisiler;
            DDLVerilenKisi.DataBind();
        }

        private void IslemTipiDoldur()
        {
            DAL.Islemislemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DByolu"].ToString();
            DataSet islemtipi = DAL.Islemislemleri.listIslemTipi();


            //DataRow dr = islemtipi.Tables[0].NewRow();
            //dr["IslemTipiID"] = "0";
            //dr["IslemAdi"] = "Seçiniz";
            //islemtipi.Tables[0].Rows.InsertAt(dr,0);

            //DataView view = islemtipi.Tables[0].DefaultView;

            //view.Sort = "IslemTipiID ";
            DDLIslemTipi.DataSource = islemtipi;
            DDLIslemTipi.DataBind();
        }

        private void FirmaDoldur()
        {
            DAL.FirmaIslemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DByolu"].ToString();
            DataSet firmaBilgileri = DAL.FirmaIslemleri.listFirma();
            DDLFirmalar.DataSource = firmaBilgileri;
            DDLFirmalar.DataBind();
        }

        private void DepoDoldur()
        {
            DAL.DepoIslemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DByolu"].ToString();
            DataSet depoBilgileri = DAL.DepoIslemleri.listDepo();
            DDLDepolar.DataSource = depoBilgileri;
            DDLDepolar.DataBind();
        }

        protected void DDLDepolar_SelectedIndexChanged(object sender, EventArgs e)
        {
            int birim = Convert.ToInt32(Session["BirimID"].ToString());

            DAL.UrunIslemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DByolu"].ToString();
            DataSet urunler = DAL.UrunIslemleri.listUrunlerByDepoId(int.Parse(DDLDepolar.SelectedValue), birim);

            DDLurunler.DataSource = urunler;
            DDLurunler.DataBind();

        }

        protected void DDLurunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int id = int.Parse(DDLurunler.SelectedValue);

            //DAL.ModelIslem.ConnectionStr= ConfigurationManager.ConnectionStrings["DByolu"].ToString();

            //DataSet model = DAL.ModelIslem.listModelByUrunID(id);
            ////DDLModel.DataSource = model;
            ////DDLModel.DataBind();

        }

        protected void BtnGridviewEkle_Click(object sender, EventArgs e)
        {
            int urunn = 0;

            if (DDLurunler.SelectedIndex >= 0 && !string.IsNullOrWhiteSpace(DDLurunler.SelectedValue))
            {
                urunn = int.Parse(DDLurunler.SelectedValue);
            }

            int adett = Convert.ToInt32(TxtUrunAdet.Text);

            int islemm = int.Parse(DDLIslemTipi.SelectedValue.ToString());
            int depoo = int.Parse(DDLDepolar.SelectedValue.ToString());
            int kisii = int.Parse(DDLVerilenKisi.SelectedValue.ToString());
            int firmaa = int.Parse(DDLFirmalar.SelectedValue.ToString());

            string tarih = TxtTarih.Text;
            string aciklama = TxtAcıklama.Text;

            setting.depogiriscikis depoobj = new setting.depogiriscikis();
            depoobj.id = DateTime.Now.ToString();
            depoobj.Islemid = islemm;
            depoobj.IslemText = DDLIslemTipi.SelectedItem.Text.ToString();
            depoobj.urunid = urunn;
            depoobj.urunadi = DDLurunler.SelectedItem.Text.ToString();
            depoobj.depoId = depoo;
            depoobj.depoText = DDLDepolar.SelectedItem.Text.ToString();


            if (int.Parse(DDLIslemTipi.SelectedItem.Value) == (int)Islem.depoCikis)
            {
                depoobj.VerilenKisiId = kisii;
                depoobj.VerilenKisiText = DDLVerilenKisi.SelectedItem.Text.ToString();
            }

            else
            {
              depoobj.AlınanFirmaText = DDLFirmalar.SelectedItem.Text.ToString();
              depoobj.AlınanFirmaId = firmaa;
            }
           
            depoobj.Tarih = tarih;
            depoobj.Aciklama = aciklama;
            depoobj.urunAdet = adett;

            //List<DepoTakip.Utility.setting.urun> urunler = new List<DepoTakip.Utility.setting.urun>();
            //urunler.Add(urunObj);
            //Session["urunler"] = urunler;

            if (Session["depo"] != null)
            {
                List<DepoTakip.Utility.setting.depogiriscikis> depolar = (List<DepoTakip.Utility.setting.depogiriscikis>)Session["depo"];

                depolar.Add(depoobj);
                Session["depo"] = depolar;
                GridViewDepoGirisCikis.DataSource = depolar;
                GridViewDepoGirisCikis.DataBind();
            }

            else
            {
                List<DepoTakip.Utility.setting.depogiriscikis> depolar = new List<DepoTakip.Utility.setting.depogiriscikis>();
                depolar.Add(depoobj);
                Session["depo"] = depolar;
                GridViewDepoGirisCikis.DataSource = depolar;
                GridViewDepoGirisCikis.DataBind();

            }
        }

        protected void Kaydet_Click(object sender, EventArgs e)
        {
            List<DepoTakip.Utility.setting.depogiriscikis> urunler = null;
            urunler = (List<DepoTakip.Utility.setting.depogiriscikis>)Session["depo"];

            foreach (DepoTakip.Utility.setting.depogiriscikis eleman in urunler)
            {
                //(int) Session["KullaniciID"] = (int)kulid;
                int kulid = int.Parse((string)Session["KullaniciID"]);
                int birimid = int.Parse((string)Session["BirimID"]);

                DAL.StokIslemleri.ConnectionStr = ConfigurationManager.ConnectionStrings["DByolu"].ToString();
                DataSet ds = new DataSet();
                ds = DAL.StokIslemleri.getStokByIds(eleman.urunid, birimid, eleman.depoId);
                int stokid = Convert.ToInt32(ds.Tables[0].Rows[0]["StokID"].ToString());
                int topadet = Convert.ToInt32(ds.Tables[0].Rows[0]["adet"].ToString());
                //int topadet = Convert.ToInt32(DAL.StokIslemleri.getadetbystokid(stokid));
              
                DAL.Islemislemleri.AddNewIslem(eleman.Islemid, kulid, stokid, eleman.Tarih, eleman.VerilenKisiId, eleman.AlınanFirmaId, eleman.urunAdet,eleman.Aciklama);

                Session["stokid"]  =stokid ;
                Session["adet"] =topadet ;

                if (eleman.Islemid == (int)Islem.DepoGiris)
                {

                    int ytopstokadet;
                    ytopstokadet = eleman.urunAdet + topadet;
                    DAL.StokIslemleri.UpdateStokByids(stokid, ytopstokadet);
                    DAL.StokIslemleri.listStok(stokid);

                }
                if (eleman.Islemid == (int)Islem.depoCikis)
                {
                    if (topadet > eleman.urunAdet)
                    {
                        int ycikstokadet;
                        ycikstokadet = topadet - eleman.urunAdet;
                        DAL.StokIslemleri.UpdateStokByids(stokid, ycikstokadet);
                        DAL.StokIslemleri.listStok(stokid);
                    }
                    else
                    {
                        //Console.WriteLine("Urun Yetersiz");
                        Response.Write("<script LANGUAGE='JavaScript' >alert('Urun Yetersiz')</script>");
                    }
                }
            }
        }

        protected void DDLIslemTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(DDLIslemTipi.SelectedValue) == 1)
            {
                DDLFirmalar.Visible = true;
                DDLVerilenKisi.Visible = false;
            }
            else if (Convert.ToInt32(DDLIslemTipi.SelectedValue) == 2)
            {
                DDLFirmalar.Visible = false;
                DDLVerilenKisi.Visible = true;
            }
            else
            {
                DDLVerilenKisi.Visible = true;
                DDLFirmalar.Visible = true;
            }
        }

        protected void GridViewDepoGirisCikis_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void ImageBtnGeri_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("default.aspx");
        }

        protected void GridViewDepoGirisCikis_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // e.Keys[0]
            string id = e.Keys[0].ToString();
            List<setting.depogiriscikis> urunler = (List<setting.depogiriscikis>)Session["depo"];
            urunler.RemoveAll(exp => exp.id.Equals(id));
            Session["depo"] = urunler;
            GridViewDepoGirisCikis.DataSource = urunler;
            GridViewDepoGirisCikis.DataBind();
        }
    }
}