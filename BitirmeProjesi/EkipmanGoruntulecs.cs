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
    public partial class EkipmanGoruntulecs : Form
    {
        public EkipmanGoruntulecs()
        {
            InitializeComponent();
        }

        private void EkipmanGoruntulecs_Load(object sender, EventArgs e)
        {
            timer1.Start(); //FORM AÇILDIĞINDA TIMER'I BAŞLATARAK DATAGRIDWIEVA VERİLERİ AKTARIYOR
        }

        SqlConnection connect = new SqlConnection("Data Source = DESKTOP-SDOQO5O; Initial Catalog = GYM; Integrated Security=SSPI");

        public void Guncelle() 
        {
            SqlCommand komut = new SqlCommand();
            connect.Open();
            komut.Connection = connect;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "guncelleEkipman";
            komut.Parameters.Add("id", SqlDbType.Int).Value = dataGridView1.SelectedCells[0].Value.ToString();
            komut.Parameters.Add("EkipmanAd", SqlDbType.VarChar, 150).Value = textBox1.Text;
            komut.Parameters.Add("EkipmanAciklama", SqlDbType.VarChar, 150).Value = textBox2.Text;
            komut.Parameters.Add("KullanilanKas", SqlDbType.VarChar, 30).Value = textBox3.Text;
            komut.Parameters.Add("GarantiTarihi", SqlDbType.VarChar, 100).Value = textBox4.Text;
            komut.Parameters.Add("Ucret", SqlDbType.VarChar, 150).Value = textBox5.Text;
            komut.Parameters.Add("KullanildigiKlup", SqlDbType.VarChar, 150).Value = comboKulup.Text;
            komut.ExecuteNonQuery();
            connect.Close();

        }
        private void Sil() //DATABASEDEKİ silEkipman ADLI STORED PROCEDURE A ID PARAMETRESİNİ GÖNDEREREK O STORED PROCEDURE'I ÇALIŞTIRIP BÜTÜN TEXTBOXLARIN İÇLERİNDEKİ VERİLERİ TEMİZLİYOR.
        {
            SqlCommand komut = new SqlCommand();
            connect.Open();
            komut.Connection = connect;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "silEkipman";
            komut.Parameters.Add("id", SqlDbType.Int,5).Value = dataGridView1.SelectedCells[0].Value.ToString();
            komut.ExecuteNonQuery();
            connect.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboKulup.ResetText();
           
        }

        private void button4_Click(object sender, EventArgs e) //TİMER SÜREKLİ GÜNCELLEDİĞİNDEN DOLAYI BU DURUMU ENGELLEMEK İÇİN TİMERI DURDURUP BAŞLATAN BİR BUTON OLUŞTURULDU VE DURUMU LABEL İLE TAKİP EDİLDİ.
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




        private void button3_Click(object sender, EventArgs e)
        {
            Guncelle();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboKulup.ResetText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sil();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Ekipmanlar";

            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connect);
            DataSet ds = new DataSet();
            connect.Open();
            dataadapter.Fill(ds, "Ekipmanlar");
            connect.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Ekipmanlar";
            dataGridView1.ClearSelection();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedCells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedCells[2].Value.ToString();
                textBox3.Text = dataGridView1.SelectedCells[3].Value.ToString();
                textBox4.Text = dataGridView1.SelectedCells[4].Value.ToString();
                textBox5.Text = dataGridView1.SelectedCells[5].Value.ToString();
                comboKulup.Text = dataGridView1.SelectedCells[6].Value.ToString();


                
               
            }
            catch
            {
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Ekipmanlar WHERE EkipmanAd Like '%"+ textBox7.Text + "%'";

            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connect);
            DataSet ds = new DataSet();
            connect.Open();
            dataadapter.Fill(ds, "Ekipman");
            connect.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Ekipman";
            dataGridView1.ClearSelection();
       
        }

        private void EkipmanGoruntulecs_FormClosing(object sender, FormClosingEventArgs e)
        {
            Ekipmanlar ekipmanlar = new Ekipmanlar();
            ekipmanlar.Show();
        }
    }
}
   
