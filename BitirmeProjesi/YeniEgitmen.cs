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

namespace BitirmeProjesi
{
    public partial class YeniEgitmen : Form
    {
        public YeniEgitmen()
        {
            InitializeComponent();
        }

        private void YeniEgitmen_Load(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAd.Text == "" || txtSoyAd.Text == "" || radioButton1.Text == "" || radioButton2.Text == "" || dateDogumTarihi.Text == "" || txtTelNo.Text == "" || txtEmail.Text == "" || dateKayit.Text == "" || comboHizmet.Text == "" || richTxtOzgecmis.Text == "" || txtmaas.Text == "" || comboUzmanlik.Text == "")
            {

                MessageBox.Show("Eksik eğitmen bilgisi girdiniz, lütfen eğitmenin tüm bilgilerini giriniz.");

                return;

            }
            string ad = txtAd.Text;
            string soyad = txtSoyAd.Text;

            string cinsiyet = "";
            string kimlik = txtKimlik.Text;

            bool ischecked = radioButton1.Checked;

            if (ischecked)
            {
                cinsiyet = radioButton1.Text;
            }
            else
            {
                cinsiyet = radioButton2.Text;
            }

            string dogumtarihi = dateDogumTarihi.Text;
            string katilma = dateKayit.Text;
            string telefon = txtTelNo.Text;
            string email = txtEmail.Text;
            string uzmanlik = comboUzmanlik.Text;
            string hizmet = comboHizmet.Text;
            string maas = txtmaas.Text;
            string ozgecmis = richTxtOzgecmis.Text;

            SqlConnection baglanti = new SqlConnection();
         

            baglanti.ConnectionString = Globals.DB; 
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;


            cmd.CommandText = "INSERT into Egitmenler (EgitmenAdi,EgitmenSoyAdi,Cinsiyet,DogumTarihi,TelNo,Email,KatilmaTarihi,UzmanlikAlani,HizmetVerdigiYer,Maas,Ozgecmis,Kimlik) VALUES('" + ad + "','" + soyad + "','" + cinsiyet + "','" + dogumtarihi + "','" + telefon + "','" + email + "','" + katilma + "','" + uzmanlik + "','" + hizmet + "','" + maas + "','" + ozgecmis + "','" + kimlik + "')";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            MessageBox.Show("Yeni Eğitmen Eklendi!");
            txtAd.Clear();
            txtSoyAd.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dateDogumTarihi.Value = DateTime.Now;
            txtTelNo.Clear();
            txtEmail.Clear();
            dateKayit.Value = DateTime.Now;
            comboUzmanlik.SelectedIndex = -1;
            comboHizmet.SelectedIndex = -1;
            txtmaas.Clear();
            richTxtOzgecmis.Clear();

        }

        private void btnSifirla_Click(object sender, EventArgs e)
        {
            txtAd.Clear();
            txtSoyAd.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            dateDogumTarihi.Value = DateTime.Now;
            txtTelNo.Clear();
            txtEmail.Clear();
            dateKayit.Value = DateTime.Now;
            comboUzmanlik.SelectedIndex = -1;
            comboHizmet.SelectedIndex = -1;
            txtmaas.Clear();
            richTxtOzgecmis.Clear();
        }

        private void txtTelNo_KeyPress(object sender, KeyPressEventArgs e) //Keychar özelliği ile girilen karakteri alıp ekrana yazdırabiliriz, IsDigit sayı olup olmadığını kontrol ediyor, KeyChar klavyeden girilen veriyi ifade ediyor yani klavyeden girilen verimiz sayı mı anlamına geliyor. e.KeyChar !=8 ile BACKSPACE tuşumuzu tanımlayıp silebilmemizi sağlıyoruz. 8 ise backspace in ascii kodunu temsil etmektedir.
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtTelNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void YeniEgitmen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Anasayfa anaSayfa = new Anasayfa();
            anaSayfa.Show();
        }
    }
    }


