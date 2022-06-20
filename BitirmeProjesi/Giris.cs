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
using System.Security.Cryptography;//şifrelemek için kullandığımız kütüphane
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

        SqlConnection connect = new SqlConnection("Data Source = DESKTOP-SDOQO5O; Initial Catalog = GYM; Integrated Security=SSPI");
        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (txtKullaniciAdi.Text == "" || txtSifre.Text == "" || txtKullaniciAdi.Text == "Kullanıcı Adı" || txtSifre.Text == "Şifre")
            {
                MessageBox.Show("Kullanıcı adı ve/veya şifre boş geçilemez, lütfen veri girişi yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                try
                {
                    try
                    {
                        connect.Close();
                    }
                    catch { }
                    bool girisOnay = false;
                    connect.Open();
                  
                    
                    string sql = "SELECT kullanici_adi,sifre from Kullanici_Giris WHERE kullanici_adi='" + txtKullaniciAdi.Text + "' AND sifre='" + MD5Sifrele(txtSifre.Text) + "'"; //MD5Sifrele
                    SqlCommand command = new SqlCommand(sql, connect);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Anasayfa fr = new Anasayfa();
                            fr.Show();
                            this.Hide();
                            girisOnay = true;
                        }
                    }
                    if (!girisOnay) MessageBox.Show("Kullanıcı adı ve/veya şifrede hatalı giriş yaptınız, lütfen doğru veri girişi yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                catch
                {
                    MessageBox.Show("Kullanıcı adı ve/veya şifrede hatalı giriş yaptınız, lütfen doğru veri girişi yapınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
        public static string MD5Sifrele(string sifrelenecekMetin)//md5 şifreleme yapan metod
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();//md5 şifreleme için md5service nesnesi oluşturuyoruz
            byte[] dizi = Encoding.UTF8.GetBytes(sifrelenecekMetin);//gelen metini utf8 olarak bytelara çeviriyoruz
            dizi = md5.ComputeHash(dizi);//dizi şeklinde olan byte değişkenimizi şifreliyoruz
            StringBuilder sb = new StringBuilder();//şifrelenmiş byte metnimizi stringbuilder ile stringe çevirmemizi sağlıcak nesnemiz
            foreach (byte ba in dizi)//diziyi foreachle döndürüyoruz
            {
                sb.Append(ba.ToString("x2").ToLower());//append ile arka arkaya ekliyoruz
            }
            return sb.ToString();//stringbuilderi geri değer olarak döndürüyoruz ve şifrelenmiş oluyor
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(txtKullaniciAdi.Text == "Kullanıcı Adı" || txtSifre.Text == "Şifre"))
            {
                try
                {  //Kullanıcı Kayıt
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connect;
                    cmd.CommandText = "INSERT into Kullanici_Giris (kullanici_adi, sifre) VALUES('" + txtKullaniciAdi.Text + "','" + MD5Sifrele(txtSifre.Text) + "')";
                    connect.Open();
                    if (cmd.ExecuteNonQuery() != 0)
                        MessageBox.Show("Kayıt Başarılı");
                    connect.Close();
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


