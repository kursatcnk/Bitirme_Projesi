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
    public partial class Ekipmanlar : Form
    {
        public Ekipmanlar()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtekipmanAdi.Text == "" || txtAciklama.Text == "" ||  dateGaranti.Text == "" || txtKullanilankas.Text == "" || txtUcret.Text == "" || comboKlup.Text == "")
            {

                MessageBox.Show("Eksik ekipman bilgisi girdiniz, lütfen tüm ekipman bilgilerini giriniz.");

                return;

            }
            string ekipmanad = txtekipmanAdi.Text;
            string aciklama = txtAciklama.Text;
            string kasgrubu = txtKullanilankas.Text;
            string garanti = dateGaranti.Text;
            string ucret = txtUcret.Text;

            string teslimat = comboKlup.Text;

            SqlConnection baglanti = new SqlConnection();


            baglanti.ConnectionString = Globals.DB;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;


            cmd.CommandText = "INSERT into Ekipmanlar (EkipmanAd,EkipmanAciklama,KullanilanKas,GarantiTarihi,Ucret,KullanildigiKlup) VALUES('" + ekipmanad+ "','" + aciklama + "','" + kasgrubu + "','" + garanti + "','" + ucret + "','" + teslimat + "')";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            MessageBox.Show("Yeni Ekipman Eklendi!");
            txtekipmanAdi.Clear();
            txtAciklama.Clear();
            txtKullanilankas.Clear();
            txtUcret.Clear();
            dateGaranti.Value = DateTime.Now;
            comboKlup.SelectedIndex = - 1;
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtekipmanAdi.Clear();
            txtAciklama.Clear();
            txtKullanilankas.Clear();
            txtUcret.Clear();
            dateGaranti.Value = DateTime.Now;
            comboKlup.SelectedIndex = -1;




        }

        private void btnGoruntule_Click(object sender, EventArgs e)
        {

        }

        private void btnGoruntule_Click_1(object sender, EventArgs e)
        {
            this.Close();
            EkipmanGoruntulecs ek = new EkipmanGoruntulecs();
            ek.Show();
        }

        private void Ekipmanlar_Load(object sender, EventArgs e)
        {

        }

        private void txtAciklama_TextChanged(object sender, EventArgs e)
        {

        }

        private void Ekipmanlar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Anasayfa anaSayfa = new Anasayfa();
            anaSayfa.Show();
        }
    }
}
