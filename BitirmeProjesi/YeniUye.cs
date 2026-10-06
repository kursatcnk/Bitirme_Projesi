using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace BitirmeProjesi
{
    public partial class YeniUye : Form
    {
        public YeniUye()
        {
            InitializeComponent();
            
        }

        private void YeniUye_Load(object sender, EventArgs e)
        {
            lblUcret.Visible = false;
            lblUcret2.Visible = false;
            lblDurum.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "" || txtSoyad.Text == "" || radioButton1.Text == "" || radioButton2.Text == "" || dateDogum.Text == "" || txtTelno.Text == "" || txtEmail.Text == "" || txtKimlik.Text == "" || dateKayit.Text == "" || comboidman.Text == "" || txtAdres.Text == "" || comboKlup.Text == "" || comboUyelik.Text == "")
            {

                MessageBox.Show("Eksik veri girdiniz, lütfen tüm bilgilerinizi giriniz.");

                return;

            }
            string Ad = txtAd.Text;
            string Soyad = txtSoyad.Text;
            string Kimlik = txtKimlik.Text;
            string Cinsiyet = "";
            bool ischecked = radioButton1.Checked;

            if (ischecked)
            {
                Cinsiyet = radioButton1.Text;

            }
            else
            {
                Cinsiyet = radioButton2.Text;
            }
            string email = txtEmail.Text; string uyelik = comboUyelik.Text;
            string kulup = comboKlup.Text;
            string dogumtarihi = dateDogum.Text;
            string telefon = (txtTelno.Text);
            string uyelikdurumu = lblDurum.Text;
            string kayit = dateKayit.Text;
            string idman = comboidman.Text;
            string adres = txtAdres.Text;

            string ucret2 = lblUcret2.Text;

            Globals.Calistir(
                "INSERT INTO YeniUye (UyeAdi, UyeSoyAdi, Cinsiyet, DogumTarihi, TelNo, Email, KayitTarihi, IdmanSaati, Adres, UyelikTipi, UyelikKulup, UyelikUcreti, Kimlik, UyelikDurumu) " +
                "VALUES (@ad, @soyad, @cinsiyet, @dogum, @tel, @email, @kayit, @idman, @adres, @tip, @kulup, @ucret, @kimlik, @durum)",
                ("@ad", Ad), ("@soyad", Soyad), ("@cinsiyet", Cinsiyet), ("@dogum", dogumtarihi), ("@tel", telefon), ("@email", email), ("@kayit", kayit),
                ("@idman", idman), ("@adres", adres), ("@tip", uyelik), ("@kulup", kulup), ("@ucret", ucret2), ("@kimlik", Kimlik), ("@durum", uyelikdurumu));

            MessageBox.Show("Yeni Üye Eklendi!");

            // Hoş geldin mesajları. Ayarlar App.config'te; boşsa gönderilmiyor, gönderilemezse kayıt yine geçerli.
            var metin = $"Sayın {Ad} {Soyad}, {kulup} kulübümüze {uyelik} üyeliğiniz başlamıştır. Sağlıklı günler dileriz.";
            var hatalar = new[] { Bildirim.SmsGonder(telefon, metin), Bildirim.EpostaGonder(email, "Üyeliğiniz başladı", metin) }.Where(h => h != null).ToList();
            if (hatalar.Count > 0) MessageBox.Show("Üye kaydedildi ancak hoş geldin mesajı gönderilemedi: " + string.Join(" ", hatalar), "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtTelno.Text);
        }

        private void btnSifirla_Click(object sender, EventArgs e)
        {
            txtAd.Clear();
            txtSoyad.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtTelno.Clear();
            txtEmail.Clear();
            comboidman.ResetText();
            comboUyelik.ResetText();
            txtAdres.Clear();
            dateDogum.Value = DateTime.Now;
            dateKayit.Value = DateTime.Now;
            lblUcret.Visible = false;

        }

        private void txtAdres_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblUcret_Click(object sender, EventArgs e)
        {
        }

        private void comboUyelik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboUyelik.Text == "Aylık")
            {
                lblUcret.Visible = true;
                lblUcret.Text = "Ödenecek Ücret Aylık= 200TL";
                lblUcret2.Text = "200TL";
            }
            else if (comboUyelik.Text == "3 Aylık")
            {
                lblUcret.Visible = true;
                lblUcret.Text = "Ödenecek Ücret Aylık = 150TL";
                lblUcret2.Text = "150TL";
            }
            else if (comboUyelik.Text == "6 Aylık")
            {
                lblUcret.Visible = true;
                lblUcret.Text = "Ödenecek Ücret Aylık = 120TL";
                lblUcret2.Text = "120TL";
            }
            else
            {
                lblUcret.Visible = true;
                lblUcret.Text = "Ödenecek Ücret Aylık = 100TL";
                lblUcret2.Text = "100TL";
            }
        }

        private void comboKlup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtTelno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) //Keychar özelliği ile girilen karakteri alıp ekrana yazdırabiliriz, IsDigit sayı olup olmadığını kontrol ediyor, KeyChar klavyeden girilen veriyi ifade ediyor yani klavyeden girilen verimiz sayı mı anlamına geliyor. e.KeyChar !=8 ile BACKSPACE tuşumuzu tanımlayıp silebilmemizi sağlıyoruz. 8 ise backspace in ascii kodunu temsil etmektedir.
            {
                e.Handled = true;
            }
        }

        private void txtTelno_TextChanged(object sender, EventArgs e)
        {

        }

        private void YeniUye_FormClosing(object sender, FormClosingEventArgs e)
        {
            Anasayfa anaSayfa = new Anasayfa();
            anaSayfa.Show();
        }

        private void lblUcret2_Click(object sender, EventArgs e)
        {

        }
    }
}
