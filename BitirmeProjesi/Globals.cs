using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BitirmeProjesi
{
    class Globals
    {
        // Bağlantı dizesi App.config'te; sunucu adı değişince tek yerden düzeltiliyor.
        public static string DB => ConfigurationManager.ConnectionStrings["GYM"].ConnectionString;

        // Kullanıcının yazdığı her değer parametre olarak gidiyor; sorgu metnine hiçbir zaman eklenmiyor.
        public static int Calistir(string sql, params (string Ad, object Deger)[] parametreler)
        {
            using (var baglanti = new SqlConnection(DB))
            using (var komut = Komut(sql, baglanti, parametreler))
            {
                baglanti.Open();
                return komut.ExecuteNonQuery();
            }
        }

        public static object Deger(string sql, params (string Ad, object Deger)[] parametreler)
        {
            using (var baglanti = new SqlConnection(DB))
            using (var komut = Komut(sql, baglanti, parametreler))
            {
                baglanti.Open();
                return komut.ExecuteScalar();
            }
        }

        public static DataTable Tablo(string sql, params (string Ad, object Deger)[] parametreler)
        {
            using (var baglanti = new SqlConnection(DB))
            using (var komut = Komut(sql, baglanti, parametreler))
            using (var adaptor = new SqlDataAdapter(komut))
            {
                var tablo = new DataTable();
                adaptor.Fill(tablo);
                return tablo;
            }
        }

        static SqlCommand Komut(string sql, SqlConnection baglanti, (string Ad, object Deger)[] parametreler)
        {
            var komut = new SqlCommand(sql, baglanti);
            foreach (var (ad, deger) in parametreler)
                komut.Parameters.AddWithValue(ad, deger ?? System.DBNull.Value);
            return komut;
        }
    }
}
