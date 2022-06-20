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
    public partial class EgitmenGoruntule : Form
    {
        public EgitmenGoruntule()
        {
            InitializeComponent();
        }

        private void EgitmenGoruntule_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        SqlConnection connect = new SqlConnection("Data Source = DESKTOP-SDOQO5O; Initial Catalog = GYM; Integrated Security=SSPI");
        public void Guncelle() // MUSTERİGUNCELLE PROCEDURE'UNA GEREKLİ VERİLERİ GÖNDEREREK ÇALIŞTIRIYOR.
        {
            try
            {
                SqlCommand komut = new SqlCommand();
                connect.Open();
                komut.Connection = connect;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "guncelleEgitmen";
                komut.Parameters.Add("id", SqlDbType.Int).Value = dataGridView1.SelectedCells[0].Value.ToString();
                komut.Parameters.Add("EgitmenAdi", SqlDbType.VarChar, 150).Value = txtAd.Text;
                komut.Parameters.Add("EgitmenSoyAdi", SqlDbType.VarChar, 150).Value = txtSoyAd.Text;
                komut.Parameters.Add("Cinsiyet", SqlDbType.VarChar, 20).Value = comboCinsiyet.Text;
                komut.Parameters.Add("DogumTarihi", SqlDbType.VarChar, 100).Value = txtDogumTarihi.Text;
                komut.Parameters.Add("TelNo", SqlDbType.VarChar, 50).Value = txtTelefon.Text;
                komut.Parameters.Add("Email", SqlDbType.VarChar, 150).Value = txtEmail.Text;
                komut.Parameters.Add("KatilmaTarihi", SqlDbType.VarChar, 100).Value = txtKayit.Text;
                komut.Parameters.Add("UzmanlikAlani", SqlDbType.VarChar, 120).Value = comboUzmanlik.Text;
                komut.Parameters.Add("HizmetVerdigiYer", SqlDbType.VarChar, 250).Value = comboHizmet.Text;
                komut.Parameters.Add("Maas", SqlDbType.VarChar, 120).Value = txtMaas.Text;
                komut.Parameters.Add("Ozgecmis", SqlDbType.VarChar, 150).Value = richTxtOzgecmis.Text;
                komut.Parameters.Add("Kimlik", SqlDbType.VarChar, 150).Value = textBox1.Text;
                komut.ExecuteNonQuery();
                connect.Close();
            }
            catch
            {
                MessageBox.Show("Listeden işlem yapacağınız kişiyi seçin!");
            }

        }
        private void Sil()
        {
            try
            {
                SqlCommand komut = new SqlCommand();
                connect.Open();
                komut.Connection = connect;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "silEgitmen";
                komut.Parameters.Add("id", SqlDbType.Int, 5).Value = dataGridView1.SelectedCells[0].Value.ToString();
                komut.ExecuteNonQuery();
                temizle();
            }
            catch
            {
                MessageBox.Show("Listeden işlem yapacağınız kişiyi seçin!");
            }
        }

        public void temizle()
        {
            connect.Close();
            txtAd.Clear();
            txtSoyAd.Clear();
            comboCinsiyet.ResetText();
            txtDogumTarihi.Clear();
            txtTelefon.Clear();
            txtEmail.Clear();
            txtKayit.Clear();
            comboUzmanlik.ResetText();
            comboHizmet.ResetText();
            txtMaas.Clear();
            richTxtOzgecmis.Clear();
            textBox1.Clear();
       
      
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Egitmenler";

            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connect);
            DataSet ds = new DataSet();
            connect.Open();
            dataadapter.Fill(ds, "Egitmenler");
            connect.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Egitmenler";
            dataGridView1.ClearSelection();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Guncelle();
            temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();

                label13.Text = "Durduruldu";

            }
            else
            {
                timer1.Start();
                label13.Text = "Çalışıyor";
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Sil();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtAd.Text = dataGridView1.SelectedCells[1].Value.ToString();
                txtSoyAd.Text = dataGridView1.SelectedCells[2].Value.ToString();
                comboCinsiyet.Text = dataGridView1.SelectedCells[3].Value.ToString();
                txtDogumTarihi.Text = dataGridView1.SelectedCells[4].Value.ToString();
                txtTelefon.Text = dataGridView1.SelectedCells[5].Value.ToString();
                txtEmail.Text = dataGridView1.SelectedCells[6].Value.ToString();
                txtKayit.Text = dataGridView1.SelectedCells[7].Value.ToString();
                comboUzmanlik.Text = dataGridView1.SelectedCells[8].Value.ToString();
                comboHizmet.Text = dataGridView1.SelectedCells[9].Value.ToString();
                txtMaas.Text = dataGridView1.SelectedCells[10].Value.ToString();
                richTxtOzgecmis.Text = dataGridView1.SelectedCells[11].Value.ToString();
                textBox1.Text = dataGridView1.SelectedCells[12].Value.ToString();
              

            }
            catch
            {
            }
        
    }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Egitmenler WHERE EgitmenAdi Like '%" + textBox12.Text + "%'";

            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connect);
            DataSet ds = new DataSet();
            connect.Open();
            dataadapter.Fill(ds, "Egitmenler");
            connect.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Egitmenler";
            dataGridView1.ClearSelection();
        }

        private void EgitmenGoruntule_FormClosing(object sender, FormClosingEventArgs e)
        {
            Anasayfa anaSayfa = new Anasayfa();
            anaSayfa.Show();
        }
    }
}
