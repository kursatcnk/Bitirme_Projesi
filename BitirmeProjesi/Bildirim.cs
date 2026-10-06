using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace BitirmeProjesi
{
    // Yeni üyeye SMS ve e-posta. Kullanıcı adı, şifre ve gönderen bilgileri koda değil App.config'teki appSettings'e yazılıyor.
    // Bir ayar boşsa o kanal atlanıyor. Hata metni döner; başarılıysa null.
    static class Bildirim
    {
        static string Ayar(string ad) => ConfigurationManager.AppSettings[ad];

        public static string SmsGonder(string telefon, string metin)
        {
            var kullanici = Ayar("Sms.KullaniciAdi");
            var sifre = Ayar("Sms.Sifre");
            var gonderen = Ayar("Sms.Gonderen");
            if (string.IsNullOrWhiteSpace(kullanici) || string.IsNullOrWhiteSpace(sifre)) return null;

            // Her değer adrese eklenmeden önce kodlanıyor; isimdeki & ya da boşluk isteği bozmasın.
            var adres = "https://api.iletimerkezi.com/v1/send-sms/get/" +
                "?username=" + Uri.EscapeDataString(kullanici) +
                "&password=" + Uri.EscapeDataString(sifre) +
                "&text=" + Uri.EscapeDataString(metin) +
                "&receipents=" + Uri.EscapeDataString(telefon) +
                "&sender=" + Uri.EscapeDataString(gonderen ?? "");
            try
            {
                using (var istemci = new WebClient()) istemci.DownloadString(adres);
                return null;
            }
            catch (WebException ex)
            {
                return "SMS: " + ex.Message;
            }
        }

        public static string EpostaGonder(string alici, string konu, string metin)
        {
            var kullanici = Ayar("Eposta.KullaniciAdi");
            var sifre = Ayar("Eposta.Sifre");
            if (string.IsNullOrWhiteSpace(kullanici) || string.IsNullOrWhiteSpace(sifre)) return null;

            try
            {
                using (var istemci = new SmtpClient(Ayar("Eposta.Sunucu") ?? "smtp.gmail.com", int.TryParse(Ayar("Eposta.Port"), out var port) ? port : 587))
                using (var mesaj = new MailMessage(kullanici, alici, konu, "<h3>" + WebUtility.HtmlEncode(metin) + "</h3>") { IsBodyHtml = true })
                {
                    istemci.EnableSsl = true;
                    istemci.UseDefaultCredentials = false;
                    istemci.Credentials = new NetworkCredential(kullanici, sifre);
                    istemci.Send(mesaj);
                }
                return null;
            }
            catch (Exception ex) when (ex is SmtpException || ex is FormatException)
            {
                return "E-posta: " + ex.Message;
            }
        }
    }
}
