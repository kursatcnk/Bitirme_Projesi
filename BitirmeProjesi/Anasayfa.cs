using System;
using System.Drawing;
using System.Windows.Forms;

namespace BitirmeProjesi
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        Boolean b = true;


        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (b== true)
            {
                menuStrip1.Dock = DockStyle.Left;
                b = false;
                toolStripMenuItem1.Image = Image.FromFile(@"D:\Bitirme Projesi Source\gym icons and images\gym icons and images\Name-48-50px\img3.jpg");
            }
            else
            {
                menuStrip1.Dock = DockStyle.Top;
                b = true;
                toolStripMenuItem1.Image = Image.FromFile(@"D:\Bitirme Projesi Source\gym icons and images\gym icons and images\Name-48-50px\img2.jpg");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripMenuItem1.Image = Image.FromFile(@"D:\Bitirme Projesi Source\gym icons and images\gym icons and images\Name-48-50px\img2.jpg");
        }

        private void yeniÜyeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            YeniUye yu = new YeniUye();
            yu.Show();
        }

        private void yeniEğitmenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            YeniEgitmen yu = new YeniEgitmen();
            yu.Show();
        }

        private void ekipmanEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ekipmanlar ek = new Ekipmanlar();
            ek.Show();
        }

        private void üyeAratToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Uyeler uy = new Uyeler();
            uy.Show();
        }

        private void üyeSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Randevular rs = new Randevular();
            rs.Show();
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            EgitmenGoruntule eg = new EgitmenGoruntule();
            eg.Show(); 
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?","Çıkış Yap",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes)
            {
                this.Close();
                Giris gr = new Giris();
                gr.Show();
            }
        }
    }

    }

