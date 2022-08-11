using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DepoTakip.Utility
{
    public class setting
    {
        public class urun {
           public int urunid {get;set; }
           public string urunadi { get; set; }
           public int urunAdet { get; set; }
        }
        public class depogiriscikis:urun
        {

            public string id { get; set; }

            public int Islemid { get; set; }
            public string IslemText { get; set; }
        
            public int urunid { get; set; }
            //public string urunad { get; set; }
     
           // public int adet { get; set; }

            public int depoId { get; set; }
            public string depoText { get; set; }
            
            public int VerilenKisiId { get; set; }
            public string VerilenKisiText { get; set; }
           
            public int AlınanFirmaId { get; set; }
            public string AlınanFirmaText { get; set; }

            public string Tarih { get; set; }

            public string Aciklama { get; set; }
          
        }

    }
}