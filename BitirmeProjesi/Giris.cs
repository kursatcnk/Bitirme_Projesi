using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BitirmeProjesi
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }      
    private void lblkapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "" || txtSifre.Text == "" || txtKullaniciAdi.Text == "Kullanıcı Adı" || txtSifre.Text == "Şifre")
            {
                MessageBox.Show("Kullanıcı adı ve/veya şifre boş geçilemez, lütfen veri girişi yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (GirisDogru(txtKullaniciAdi.Text, txtSifre.Text))
                {
                    new Anasayfa().Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı ve/veya şifrede hatalı giriş yaptınız, lütfen doğru veri girişi yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Veritabanına bağlanılamadı. App.config'teki bağlantı dizesini kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Kullanıcı adı parametreyle aranıyor, şifre veritabanında değil burada doğrulanıyor.
        // Eski MD5 kaydıyla giren kullanıcının şifresi yeni biçime çevriliyor.
        static bool GirisDogru(string kullaniciAdi, string sifre)
        {
            using (var baglanti = new SqlConnection(Globals.DB))
            {
                baglanti.Open();
                int id;
                string kayitli;
                using (var komut = new SqlCommand("SELECT k_id, sifre FROM Kullanici_Giris WHERE kullanici_adi = @ad", baglanti))
                {
                    komut.Parameters.Add("@ad", SqlDbType.NVarChar, 50).Value = kullaniciAdi;
                    using (var okuyucu = komut.ExecuteReader())
                    {
                        if (!okuyucu.Read()) return false;
                        id = okuyucu.GetInt32(0);
                        kayitli = okuyucu.IsDBNull(1) ? null : okuyucu.GetString(1);
                    }
                }

                if (!Sifreleme.Dogrula(sifre, kayitli)) return false;

                if (!Sifreleme.YeniBicimde(kayitli))
                {
                    using (var guncelle = new SqlCommand("UPDATE Kullanici_Giris SET sifre = @sifre WHERE k_id = @id", baglanti))
                    {
                        guncelle.Parameters.Add("@sifre", SqlDbType.NVarChar, 50).Value = Sifreleme.Ozetle(sifre);
                        guncelle.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        guncelle.ExecuteNonQuery();
                    }
                }
                return true;
            }
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = '*';
        }

        private void txtSifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnGiris_Click(null, null);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!(txtKullaniciAdi.Text == "Kullanıcı Adı" || txtSifre.Text == "Şifre" || txtKullaniciAdi.Text == "" || txtSifre.Text == ""))
            {
                try
                {
                    // Kullanıcı kaydı: aynı ad ikinci kez alınamıyor, şifre özetlenerek saklanıyor.
                    using (var baglanti = new SqlConnection(Globals.DB))
                    using (var komut = new SqlCommand(
                        "IF NOT EXISTS (SELECT 1 FROM Kullanici_Giris WHERE kullanici_adi = @ad) INSERT INTO Kullanici_Giris (kullanici_adi, sifre) VALUES (@ad, @sifre)", baglanti))
                    {
                        komut.Parameters.Add("@ad", SqlDbType.NVarChar, 50).Value = txtKullaniciAdi.Text;
                        komut.Parameters.Add("@sifre", SqlDbType.NVarChar, 50).Value = Sifreleme.Ozetle(txtSifre.Text);
                        baglanti.Open();
                        MessageBox.Show(komut.ExecuteNonQuery() > 0 ? "Kayıt başarılı." : "Bu kullanıcı adı zaten kayıtlı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ve/veya şifre boş geçilemez, lütfen veri girişi yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtKullaniciAdi_Leave(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "")
            {              
                txtKullaniciAdi.Text = "Kullanıcı Adı";
                txtKullaniciAdi.ForeColor = Color.White;
            }
        }

        private void txtKullaniciAdi_Enter(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "Kullanıcı Adı")
            {
                txtKullaniciAdi.Text = null;
                txtKullaniciAdi.ForeColor = Color.White;
            }
        }

        private void txtSifre_Enter(object sender, EventArgs e)
        {
            if (txtSifre.Text == "Şifre")
            {
                txtSifre.Text = null;
                txtSifre.PasswordChar = '\0';
                txtSifre.ForeColor = Color.White;
                
            }
        }

        private void txtSifre_Leave(object sender, EventArgs e)
        {
            if (txtSifre.Text == "")
            {
                txtSifre.Text = "Şifre";
                txtSifre.PasswordChar = '\0';
                txtSifre.ForeColor = Color.White;
               
            }
        }

        private void Giris_Load(object sender, EventArgs e)
        {
           
        }

        private void txtKullaniciAdi_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Giris_MouseHover(object sender, EventArgs e)
        {
           
        }
    }
}


