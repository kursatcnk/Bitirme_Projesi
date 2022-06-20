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
    public partial class Uyeler : Form
    {
        public Uyeler()
        {
            InitializeComponent();
        }

        private void Uyeler_Load(object sender, EventArgs e)
        {
            timer1.Start();
            
        }

        SqlConnection connect = new SqlConnection("Data Source = DESKTOP-SDOQO5O; Initial Catalog = GYM; Integrated Security=SSPI");

         public void Guncelle() // guncelleUye PROCEDURE'UNA GEREKLİ VERİLERİ GÖNDEREREK ÇALIŞTIRIYOR.
        {
            try
            {
                SqlCommand komut = new SqlCommand();
                connect.Open();
                komut.Connection = connect;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "guncelleUye";
                komut.Parameters.Add("id", SqlDbType.Int).Value = dataGridView1.SelectedCells[0].Value.ToString();
                komut.Parameters.Add("UyeAdi", SqlDbType.VarChar, 150).Value = textBox1.Text;
                komut.Parameters.Add("UyeSoyAdi", SqlDbType.VarChar, 150).Value = textBox2.Text;
                komut.Parameters.Add("Cinsiyet", SqlDbType.VarChar, 20).Value = comboCinsiyet.Text;
                komut.Parameters.Add("DogumTarihi", SqlDbType.VarChar, 100).Value = textBox4.Text;
                komut.Parameters.Add("TelNo", SqlDbType.VarChar, 50).Value = textBox5.Text;
                komut.Parameters.Add("Email", SqlDbType.VarChar, 150).Value = textBox7.Text;
                komut.Parameters.Add("KayitTarihi", SqlDbType.VarChar, 100).Value = textBox8.Text;
                komut.Parameters.Add("IdmanSaati", SqlDbType.VarChar, 120).Value = comboidman.Text;
                komut.Parameters.Add("Adres", SqlDbType.VarChar, 250).Value = richTextBox1.Text;
                komut.Parameters.Add("UyelikTipi", SqlDbType.VarChar, 120).Value = comboTip.Text;
                komut.Parameters.Add("UyelikKulup", SqlDbType.VarChar, 150).Value = comboUyelik.Text;
                komut.Parameters.Add("UyelikUcreti", SqlDbType.VarChar, 150).Value = textBox10.Text;
                komut.Parameters.Add("Kimlik", SqlDbType.VarChar, 150).Value = textBox3.Text;
                komut.Parameters.Add("UyelikDurumu", SqlDbType.VarChar, 150).Value = comboBox1.Text;
                komut.ExecuteNonQuery();
                connect.Close();
            }
            catch 
            {
                MessageBox.Show("Listeden işlem yapacağınız kişiyi seçin!");
            }
            
        }
        private void Sil() //DATABASEDEKİ silUye ADLI STORED PROCEDURE A ID PARAMETRESİNİ GÖNDEREREK O STORED PROCEDURE'I ÇALIŞTIRIP BÜTÜN TEXTBOXLARIN İÇLERİNDEKİ VERİLERİ TEMİZLİYOR.
        {
            try
            {
                SqlCommand komut = new SqlCommand();
                connect.Open();
                komut.Connection = connect;
                komut.CommandType = CommandType.StoredProcedure;
                komut.CommandText = "silUye";
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
            textBox1.Clear();
            textBox2.Clear();
            comboCinsiyet.ResetText();
            textBox4.Clear();
            textBox5.Clear();
            textBox7.Clear();
            textBox8.Clear();
            comboidman.ResetText();
            richTextBox1.Clear();
            comboUyelik.ResetText();
            comboBox1.ResetText();
            textBox10.Clear();
            comboTip.ResetText();
            textBox3.Clear();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM YeniUye";

            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connect);
            DataSet ds = new DataSet();
            connect.Open();
            dataadapter.Fill(ds, "YeniUye");
            connect.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "YeniUye";
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

            try
            {
                textBox1.Text = dataGridView1.SelectedCells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedCells[2].Value.ToString();
                comboCinsiyet.Text = dataGridView1.SelectedCells[3].Value.ToString();
                textBox4.Text = dataGridView1.SelectedCells[4].Value.ToString();
                textBox5.Text = dataGridView1.SelectedCells[5].Value.ToString();
                textBox7.Text = dataGridView1.SelectedCells[6].Value.ToString();
                textBox8.Text = dataGridView1.SelectedCells[7].Value.ToString();
                comboidman.Text = dataGridView1.SelectedCells[8].Value.ToString();
                richTextBox1.Text = dataGridView1.SelectedCells[9].Value.ToString();
                comboTip.Text = dataGridView1.SelectedCells[10].Value.ToString();
                comboUyelik.Text = dataGridView1.SelectedCells[11].Value.ToString();
                textBox10.Text = dataGridView1.SelectedCells[12].Value.ToString();
                textBox3.Text = dataGridView1.SelectedCells[13].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedCells[14].Value.ToString();
                
            }
            catch
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM YeniUye WHERE UyeAdi Like '%" + textBox12.Text + "%'";

            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connect);
            DataSet ds = new DataSet();
            connect.Open();
            dataadapter.Fill(ds, "YeniUye");
            connect.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "YeniUye";
            dataGridView1.ClearSelection();

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void Uyeler_FormClosing(object sender, FormClosingEventArgs e)
        {
            Anasayfa anaSayfa = new Anasayfa();
            anaSayfa.Show();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
