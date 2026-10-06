using System;
using System.Security.Cryptography;
using System.Text;

namespace BitirmeProjesi
{
    // Şifreler PBKDF2 (SHA-256, 100.000 tur, rastgele tuz) ile saklanıyor.
    // Biçim "p1$tuz$özet"; sifre sütunu nvarchar(50) olduğu için tuz 12, özet 18 byte (toplam 44 karakter).
    // Eski kayıtlardaki MD5 özetleri girişte doğrulanıyor ve yeni biçime çevriliyor.
    static class Sifreleme
    {
        const string Onek = "p1$";
        const int Tur = 100000;

        public static string Ozetle(string sifre)
        {
            var tuz = new byte[12];
            using (var rng = RandomNumberGenerator.Create()) rng.GetBytes(tuz);
            return Onek + Convert.ToBase64String(tuz) + "$" + Convert.ToBase64String(Turet(sifre, tuz));
        }

        public static bool Dogrula(string sifre, string kayitli)
        {
            if (string.IsNullOrEmpty(kayitli)) return false;
            if (!YeniBicimde(kayitli)) return SabitSureliEsit(Encoding.ASCII.GetBytes(Md5(sifre)), Encoding.ASCII.GetBytes(kayitli.ToLowerInvariant()));

            var parcalar = kayitli.Substring(Onek.Length).Split('$');
            if (parcalar.Length != 2) return false;
            try
            {
                return SabitSureliEsit(Turet(sifre, Convert.FromBase64String(parcalar[0])), Convert.FromBase64String(parcalar[1]));
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static bool YeniBicimde(string kayitli) => kayitli != null && kayitli.StartsWith(Onek, StringComparison.Ordinal);

        static byte[] Turet(string sifre, byte[] tuz)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(sifre, tuz, Tur, HashAlgorithmName.SHA256))
                return pbkdf2.GetBytes(18);
        }

        // Eski kayıtlar için; yeni şifre bu yöntemle saklanmıyor.
        static string Md5(string metin)
        {
            using (var md5 = MD5.Create())
            {
                var sb = new StringBuilder();
                foreach (var b in md5.ComputeHash(Encoding.UTF8.GetBytes(metin))) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        // Karşılaştırma süresi ilk farklı byte'a göre değişmesin.
        static bool SabitSureliEsit(byte[] a, byte[] b)
        {
            var fark = a.Length ^ b.Length;
            for (var i = 0; i < Math.Min(a.Length, b.Length); i++) fark |= a[i] ^ b[i];
            return fark == 0;
        }
    }
}
