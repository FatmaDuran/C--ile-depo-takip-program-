using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class MarkaIslem
    {
        public static string ConnectionStr { get; set; }

        public static DataSet listMarkaByUrunId(int id, int birimId)
        {
            SqlConnection baglanti = new SqlConnection(ConnectionStr);
            baglanti.Open();

            string sql = "select * from urunler as u inner join Stok as s on u.BarkodNo=s.BarkodNo where s.BirimID=@birimId and s.DepoID=@id";
            SqlCommand komut = new SqlCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@birimId", birimId);
            komut.Parameters.AddWithValue("@id", id);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            DataSet tablo = new DataSet();
            adp.Fill(tablo);
            baglanti.Close();
            return tablo;
        }

    }
}
