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
    public partial class Randevular : Form
    {
        SqlConnection connect = new SqlConnection(Globals.DB);
        DateTime today, next = DateTime.Today;//bugünü ve bir sonraki randevu gününü(örn bi sonraki pzt gibi) tutacağımız global değişkenler
        string secilenEgitmedId = "";//seçtiğimiz eğitmenin adına göre idsini global olarak tutuyoruz ve randevu alırken eğitmen idsini bu değişken ile gönderiyoruz
        string secilenUyeId = "";
        string r_id = "0";
        string secilenRandevuTipi = "";
        string randevuTarih = "";//Randevu tarihi için tanımlanan global değişken 
        int daysUntil = 0;//bir sonraki randevu gününe(örn bi sonraki pzt gibi) kalan gün sayısını tutan global değişken.
        List<int> egitmenid = new List<int>();//LİST MODERN VERSİYON DİZİDİR, DİZİDEN TEK FARKI EKLEME ÇIKARMA İŞLEMİ YAPILABİLİR.
        //eğitmenidleri databaseden cekip listede tutuyoruz. Bu sayede yeni bir eğitmen eklendiğinde dizinin uzunluğu ile uğraşmamış oluyoruz.
        public Randevular()
        {
            InitializeComponent();
        }

        private void Randevular_Load(object sender, EventArgs e)
        {   //bütün comboboxları deaktif yaparak önce kullanıcıdan gün seçmesini sağlıyoruz
            comboPazartesi.Enabled = false;
            comboSali.Enabled = false;
            comboCarsamba.Enabled = false;
            comboPersembe.Enabled = false;
            comboCuma.Enabled = false;
            comboCumartesi.Enabled = false;
            comboPazar.Enabled = false;

            //Uyeleri grid1e cekiyoruz
            string sql = "SELECT * FROM YeniUye";
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connect);
            DataSet ds = new DataSet();
            connect.Open();
            dataadapter.Fill(ds, "YeniUye");
            connect.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "YeniUye";
            dataGridView1.ClearSelection();
            randevulariCek(); //randevu guncelleyen fonksiyonumuzu çağırıyoruz
            dataGridView2.Columns[0].HeaderText = "Randevu ID";
            dataGridView2.Columns[1].HeaderText = "Üye Adı";
            dataGridView2.Columns[3].HeaderText = "Randevu Türü";
            dataGridView2.Columns[4].HeaderText = "Randevu Tarihi";
            dataGridView2.Columns[2].HeaderText = "Eğitmen Adı Soyadı"; 
        }

        public void randevulariCek()//randevu listesini guncelleyen fonksiyonumuz
        {

            string sql = "SELECT r_id,uye_id,egitmen_id ,randevu_tip,randevu_tarih FROM Randevular_Yeni"; //Randevu tarihlerini ekranda gösteriyoruz
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connect);
            DataSet ds = new DataSet();
            connect.Close();
            connect.Open();
            dataadapter.Fill(ds, "Randevular");
            connect.Close();
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "Randevular";
            dataGridView2.ClearSelection();
            comboEgitmen.Enabled = false;
            //randevuları tablodan çekip grid2ye aktarıyoruz. uye_id ve egitmen_idleri satir satir cekip sql sorgularıyla uye adi ve egitmen adlarıyla güncellemiş oluyoruz
            //tabloya uye_id ve egitmen_id geliyor fakat biz bunları uye adi ve egitmen adi olarak guncelliyoruz. Daha rahat anlaşılması için
            int satir = dataGridView2.Rows.Count;//satir sayisi
            int sutun = dataGridView2.Columns.Count;//sütun sayisi
            if (satir > 0&&sutun>0)//satir ve sutun sayısı 0dan büyükse yani veri varsa grid2deki egitmen idleri ve uye idlerini kullanarak isimlerle güncelliyoruyz
            {
                for (int i = 0; i < satir-1; i++)
                { 
                    string uye_id = dataGridView2[1, i].Value.ToString();//gridden satir satir idyi degiskene atadık 
                    string egitmen_id = dataGridView2[2, i].Value.ToString();//gridden satir satir idyi degiskene atadık 

                    var uyeAdi = Globals.Deger("SELECT UyeAdi FROM YeniUye WHERE UyeID = @id", ("@id", uye_id));
                    if (uyeAdi != null) dataGridView2[1, i].Value = uyeAdi.ToString();//griddeki satirin değerini değiştiriyoruz.

                    var egitmenAdi = Globals.Deger("SELECT EgitmenAdi + ' ' + EgitmenSoyAdi FROM Egitmenler WHERE EgitmenID = @id", ("@id", egitmen_id));
                    if (egitmenAdi != null) dataGridView2[2, i].Value = egitmenAdi.ToString();

                }
            }
        }

        private void comboEgitmen_SelectedIndexChanged(object sender, EventArgs e)
        {
            int[] _egitmenid = egitmenid.ToArray(); 
            secilenEgitmedId = _egitmenid[comboEgitmen.SelectedIndex].ToString();//Seçilen eğitmenin idsini alıyoruz ve global id değişkenimize atamış oluyoruz.
        }

        private void btnRandevuAl_Click(object sender, EventArgs e)
        {
           
            if (secilenEgitmedId != "" && secilenUyeId != "" && secilenRandevuTipi != "" && randevuTarih != "")
            {
                bool randevuDurum = randevuKontrol();//radevunun var olup olmadığını kontrol ediyoruz var ise eklemiyor yoksa ekliyor
                if(randevuDurum)
                {
                    string query = "INSERT INTO Randevular_Yeni (uye_id,randevu_tip,randevu_tarih,egitmen_id) VALUES (@id,@r_tip,@r_tarih, @e_id)";
                    connect.Close();
                    connect.Open();
                    SqlCommand command = new SqlCommand(query, connect);
                    command.Parameters.AddWithValue("@id", secilenUyeId);
                    command.Parameters.AddWithValue("@r_tip", secilenRandevuTipi);
                    command.Parameters.AddWithValue("@r_tarih", randevuTarih);
                    command.Parameters.AddWithValue("@e_id", secilenEgitmedId);

                    int succes = command.ExecuteNonQuery();
                    if (succes == 1)
                    {
                        connect.Close();
                        var uyeGsm = Convert.ToString(Globals.Deger("SELECT TelNo FROM YeniUye WHERE UyeID = @id", ("@id", secilenUyeId)));
                        var hocaAdi = Convert.ToString(Globals.Deger("SELECT EgitmenAdi + ' ' + EgitmenSoyAdi FROM Egitmenler WHERE EgitmenID = @id", ("@id", secilenEgitmedId)));
                        var smsHatasi = Bildirim.SmsGonder(uyeGsm, $"{secilenRandevuTipi} randevunuz {randevuTarih} tarihinde {hocaAdi} hoca için alınmıştır.");

                        MessageBox.Show(smsHatasi == null ? "Randevu Alındı!" : "Randevu alındı ancak SMS gönderilemedi: " + smsHatasi);
                        randevulariCek();
                        comboPazartesi.ResetText();
                        comboSali.ResetText();
                        comboCarsamba.ResetText();
                        comboPersembe.ResetText();
                        comboCuma.ResetText();
                        comboCumartesi.ResetText();
                        comboPazar.ResetText();
                        comboRandevuTipi.ResetText();
                        comboEgitmen.ResetText();
                    }
                    else
                        MessageBox.Show("Randevu Başarısız!");
                }
                else {
                    MessageBox.Show("Randevu Mevcut. Lütfen listeden kontrol edip başka tarihe veya başka hocaya randevu seçiniz!");
                }
            }

        }

        private bool randevuKontrol()//randevu kontrolünü sağlayan fonksiyon
        { 
            // Aynı eğitmene aynı saatte ikinci randevu verilmiyor; farklı eğitmenler aynı saatte çalışabiliyor.
            var mevcut = Globals.Deger("SELECT COUNT(*) FROM Randevular_Yeni WHERE randevu_tarih = @tarih AND egitmen_id = @egitmen",
                ("@tarih", randevuTarih), ("@egitmen", secilenEgitmedId));
            return Convert.ToInt32(mevcut) == 0;
        }

        int gun = 0;//haftanın hangi gününün seçildiğini belirten değişkenimiz
        //1=Pzt    7=cuma. Bu sayede pazartesini seçen birisi önümüzdeki pazartesine tarih alması için işlemler yapılıyor
        private void btnPazartesi_Click(object sender, EventArgs e)
        {
            //pazartesine basıldığı zaman pazartesi combobox'ını aktif yapıp diğer gün butonlarını deaktif yapıyor
            if (!btnCarsamba.Enabled)//carsamba yazmamızın sebebi: pazartesi haricinde bir gün olan çarşambanın buton aktifliğini kontrol
                                     //ederek aktif değilse ve tıklandıysa bütün günlerin butonlarını aktif yapıp seçime imkan sağlıyor
                                     //aktif ise ve tıklandıysa tıklanan günün combobox'ını aktif yapıyor ve saat seçmemizi sağlıyor
                                     //aynı zamanda diğer günleri seçtirmeyerek kullanıcı hatalarını önlemiş oluyoruz
                                     //diğer bütün günler için aynı işlemi tekrarladık
                                     //kendisinden farklı bir gün butonunun aktifliğini kontrol ederek gün seçmemizi sağlıyor kısaca
            {
                comboPazartesi.Enabled = false;
                comboSali.Enabled = false;
                comboCarsamba.Enabled = false;
                comboPersembe.Enabled = false;
                comboCuma.Enabled = false;
                comboCumartesi.Enabled = false;
                comboPazar.Enabled = false;


                btnPazartesi.Enabled = true;
                btnSali.Enabled = true;
                btnCarsamba.Enabled = true;
                btnPersembe.Enabled = true;
                btnCuma.Enabled = true;
                btnCumartesi.Enabled = true;
                btnPazar.Enabled = true;
            }
            else
            {
                gun = 1;
                comboPazartesi.Enabled = true;
                comboSali.Enabled = false;
                comboCarsamba.Enabled = false;
                comboPersembe.Enabled = false;
                comboCuma.Enabled = false;
                comboCumartesi.Enabled = false;
                comboPazar.Enabled = false;


                btnPazartesi.Enabled = true;
                btnSali.Enabled = false;
                btnCarsamba.Enabled = false;
                btnPersembe.Enabled = false;
                btnCuma.Enabled = false;
                btnCumartesi.Enabled = false;
                btnPazar.Enabled = false;
            }
        }

        private void btnSali_Click(object sender, EventArgs e)
        {
            if (!btnCarsamba.Enabled)
            {
                comboPazartesi.Enabled = false;
                comboSali.Enabled = false;
                comboCarsamba.Enabled = false;
                comboPersembe.Enabled = false;
                comboCuma.Enabled = false;
                comboCumartesi.Enabled = false;
                comboPazar.Enabled = false;


                btnPazartesi.Enabled = true;
                btnSali.Enabled = true;
                btnCarsamba.Enabled = true;
                btnPersembe.Enabled = true;
                btnCuma.Enabled = true;
                btnCumartesi.Enabled = true;
                btnPazar.Enabled = true;
            }
            else {
                comboPazartesi.Enabled = false;
                comboSali.Enabled = true;
                comboCarsamba.Enabled = false;
                comboPersembe.Enabled = false;
                comboCuma.Enabled = false;
                comboCumartesi.Enabled = false;
                comboPazar.Enabled = false;
                gun = 2;

                btnPazartesi.Enabled = false;
                btnSali.Enabled = true;
                btnCarsamba.Enabled = false;
                btnPersembe.Enabled = false;
                btnCuma.Enabled = false;
                btnCumartesi.Enabled = false;
                btnPazar.Enabled = false;
            }
        }

        private void btnCarsamba_Click(object sender, EventArgs e)
        {
            if (!btnSali.Enabled)
            {
                comboPazartesi.Enabled = false;
                comboSali.Enabled = false;
                comboCarsamba.Enabled = false;
                comboPersembe.Enabled = false;
                comboCuma.Enabled = false;
                comboCumartesi.Enabled = false;
                comboPazar.Enabled = false;


                btnPazartesi.Enabled = true;
                btnSali.Enabled = true;
                btnCarsamba.Enabled = true;
                btnPersembe.Enabled = true;
                btnCuma.Enabled = true;
                btnCumartesi.Enabled = true;
                btnPazar.Enabled = true;
            }
            else
            {
                comboPazartesi.Enabled = false;
                comboSali.Enabled = false;
                comboCarsamba.Enabled = true;
                comboPersembe.Enabled = false;
                comboCuma.Enabled = false;
                comboCumartesi.Enabled = false;
                comboPazar.Enabled = false;
                gun = 3;

                btnPazartesi.Enabled = false;
                btnSali.Enabled = false;
                btnCarsamba.Enabled = true;
                btnPersembe.Enabled = false;
                btnCuma.Enabled = false;
                btnCumartesi.Enabled = false;
                btnPazar.Enabled = false;
            }
        }

        private void btnPersembe_Click(object sender, EventArgs e)
        {
            if (!btnCarsamba.Enabled)
            {
                comboPazartesi.Enabled = false;
                comboSali.Enabled = false;
                comboCarsamba.Enabled = false;
                comboPersembe.Enabled = false;
                comboCuma.Enabled = false;
                comboCumartesi.Enabled = false;
                comboPazar.Enabled = false;


                btnPazartesi.Enabled = true;
                btnSali.Enabled = true;
                btnCarsamba.Enabled = true;
                btnPersembe.Enabled = true;
                btnCuma.Enabled = true;
                btnCumartesi.Enabled = true;
                btnPazar.Enabled = true;
            }
            else
            {
                comboPazartesi.Enabled = false;
                comboSali.Enabled = false;
                comboCarsamba.Enabled = false;
                comboPersembe.Enabled = true;
                comboCuma.Enabled = false;
                comboCumartesi.Enabled = false;
                comboPazar.Enabled = false;
                gun = 4;

                btnPazartesi.Enabled = false;
                btnSali.Enabled = false;
                btnCarsamba.Enabled = false;
                btnPersembe.Enabled = true;
                btnCuma.Enabled = false;
                btnCumartesi.Enabled = false;
                btnPazar.Enabled = false;
            }
        }

        private void btnCuma_Click(object sender, EventArgs e)
        {
            if (!btnCarsamba.Enabled)
            {
                comboPazartesi.Enabled = false;
                comboSali.Enabled = false;
                comboCarsamba.Enabled = false;
                comboPersembe.Enabled = false;
                comboCuma.Enabled = false;
                comboCumartesi.Enabled = false;
                comboPazar.Enabled = false;


                btnPazartesi.Enabled = true;
                btnSali.Enabled = true;
                btnCarsamba.Enabled = true;
                btnPersembe.Enabled = true;
                btnCuma.Enabled = true;
                btnCumartesi.Enabled = true;
                btnPazar.Enabled = true;
            }
            else
            {
                comboPazartesi.Enabled = false;
                comboSali.Enabled = false;
                comboCarsamba.Enabled = false;
                comboPersembe.Enabled = false;
                comboCuma.Enabled = true;
                comboCumartesi.Enabled = false;
                comboPazar.Enabled = false;
                gun = 5;

                btnPazartesi.Enabled = false;
                btnSali.Enabled = false;
                btnCarsamba.Enabled = false;
                btnPersembe.Enabled = false;
                btnCuma.Enabled = true;
                btnCumartesi.Enabled = false;
                btnPazar.Enabled = false;
            }

        }

        private void btnCumartesi_Click(object sender, EventArgs e)
        {
            if (!btnSali.Enabled)
            {
                comboPazartesi.Enabled = false;
                comboSali.Enabled = false;
                comboCarsamba.Enabled = false;
                comboPersembe.Enabled = false;
                comboCuma.Enabled = false;
                comboCumartesi.Enabled = false;
                comboPazar.Enabled = false;

                btnPazartesi.Enabled = true;
                btnSali.Enabled = true;
                btnCarsamba.Enabled = true;
                btnPersembe.Enabled = true;
                btnCuma.Enabled = true;
                btnCumartesi.Enabled = true;
                btnPazar.Enabled = true;
            }
            else
            {
                comboPazartesi.Enabled = false;
                comboSali.Enabled = false;
                comboCarsamba.Enabled = false;
                comboPersembe.Enabled = false;
                comboCuma.Enabled = false;
                comboCumartesi.Enabled = true;
                comboPazar.Enabled = false;
                gun = 6;

                btnPazartesi.Enabled = false;
                btnSali.Enabled = false;
                btnCarsamba.Enabled = false;
                btnPersembe.Enabled = false;
                btnCuma.Enabled = false;
                btnCumartesi.Enabled = true;
                btnPazar.Enabled = false;
            }
        }

        private void btnPazar_Click(object sender, EventArgs e)
        {
            if (!btnCarsamba.Enabled)
            {
                comboPazartesi.Enabled = false;
                comboSali.Enabled = false;
                comboCarsamba.Enabled = false;
                comboPersembe.Enabled = false;
                comboCuma.Enabled = false;
                comboCumartesi.Enabled = false;
                comboPazar.Enabled = false;


                btnPazartesi.Enabled = true;
                btnSali.Enabled = true;
                btnCarsamba.Enabled = true;
                btnPersembe.Enabled = true;
                btnCuma.Enabled = true;
                btnCumartesi.Enabled = true;
                btnPazar.Enabled = true;
            }
            else
            {
                comboPazartesi.Enabled = false;
                comboSali.Enabled = false;
                comboCarsamba.Enabled = false;
                comboPersembe.Enabled = false;
                comboCuma.Enabled = false;
                comboCumartesi.Enabled = false;
                comboPazar.Enabled = true;
                gun = 7;

                btnPazartesi.Enabled = false;
                btnSali.Enabled = false;
                btnCarsamba.Enabled = false;
                btnPersembe.Enabled = false;
                btnCuma.Enabled = false;
                btnCumartesi.Enabled = false;
                btnPazar.Enabled = true;
            }
        }
       
        private void biSonrakiGunTarihi()
        {   

            //KISA IF ==  şart ? true : false
            switch (gun)
                {
                    case 1:
                        today = DateTime.Today;//bugünü tutan değişken
                        daysUntil = ((int)DayOfWeek.Monday - (int)today.DayOfWeek + 7) % 7;//Önümüzdeki pazartesi gününe kalan günü hesaplayan aritmetik işlem
                          //işlem:pazartesiden bugünün haftanın kaçıncı günü olduğunu bulup çıkartıyor daha sonra 7 ekleyip 7ye mod alıyor bu sayade bir sonraki pazartesi gününe kalan günü hesaplamış oluyoruz.
                    
                    next = today.AddDays(daysUntil != 0 ? daysUntil : 7);//kısa if
                    //if kullanmamızın sebebi eğer kalangün 0 ise 7 gün ekleyip aynı güne randevu almayı engellemiş oluyoruz
                        break;
                    case 2:
                        today = DateTime.Today;
                        daysUntil = ((int)DayOfWeek.Tuesday - (int)today.DayOfWeek + 7) % 7;
                        next = today.AddDays(daysUntil > 0 ? daysUntil : 7);
                        break;
                    case 3:
                        today = DateTime.Today;
                        daysUntil = ((int)DayOfWeek.Wednesday - (int)today.DayOfWeek + 7) % 7;
                        next = today.AddDays(daysUntil > 0 ? daysUntil : 7); 
                        break;
                    case 4:
                        today = DateTime.Today;
                        daysUntil = ((int)DayOfWeek.Thursday - (int)today.DayOfWeek + 7) % 7;
                        next = today.AddDays(daysUntil > 0 ? daysUntil : 7);
                        break;
                    case 5:
                        today = DateTime.Today;
                        daysUntil = ((int)DayOfWeek.Friday - (int)today.DayOfWeek + 7) % 7;
                        next = today.AddDays(daysUntil > 0 ? daysUntil : 7);
                        break;
                    case 6:
                        today = DateTime.Today;
                        daysUntil = ((int)DayOfWeek.Saturday - (int)today.DayOfWeek + 7) % 7;
                        next = today.AddDays(daysUntil > 0 ? daysUntil : 7);
                        break;
                    case 7:
                        today = DateTime.Today;
                        daysUntil = ((int)DayOfWeek.Sunday - (int)today.DayOfWeek + 7) % 7;
                        next = today.AddDays(daysUntil > 0 ? daysUntil : 7);
                        break;
                    default:
                        break;
                }
        }
        private void comboPazartesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            biSonrakiGunTarihi();//bi sonraki günü next değişkenine atan fonksiyon
            randevuTarih = next.ToShortDateString() + " " + comboPazartesi.Items[comboPazartesi.SelectedIndex].ToString().Substring(0, 2) + ":00";
            //randevu tarihini tutan değişkenin değerini comboboxtan gelen saat ile yazmış oluyoruz.
          
        } 

        private void comboSali_SelectedIndexChanged(object sender, EventArgs e)
        {
            biSonrakiGunTarihi();
            randevuTarih = next.ToShortDateString() + " " + comboSali.Items[comboSali.SelectedIndex].ToString().Substring(0, 2) + ":00";
            
        }

        private void comboCarsamba_SelectedIndexChanged(object sender, EventArgs e)
        {
            biSonrakiGunTarihi();
            randevuTarih = next.ToShortDateString() + " " + comboCarsamba.Items[comboCarsamba.SelectedIndex].ToString().Substring(0, 2) + ":00";
        
        }

        private void comboPersembe_SelectedIndexChanged(object sender, EventArgs e)
        {
            biSonrakiGunTarihi();
            randevuTarih = next.ToShortDateString() + " " + comboPersembe.Items[comboPersembe.SelectedIndex].ToString().Substring(0, 2) + ":00";
            
        }

        private void comboCuma_SelectedIndexChanged(object sender, EventArgs e)
        {
            biSonrakiGunTarihi();
            randevuTarih = next.ToShortDateString() + " " + comboCuma.Items[comboCuma.SelectedIndex].ToString().Substring(0, 2) + ":00";
            
        }

        private void comboCumartesi_SelectedIndexChanged(object sender, EventArgs e)
        {
            biSonrakiGunTarihi();
            randevuTarih = next.ToShortDateString() + " " + comboCumartesi.Items[comboCumartesi.SelectedIndex].ToString().Substring(0, 2) + ":00";
            
        }

        private void comboPazar_SelectedIndexChanged(object sender, EventArgs e)
        {
            biSonrakiGunTarihi();
            randevuTarih = next.ToShortDateString() + " " + comboPazar.Items[comboPazar.SelectedIndex].ToString().Substring(0, 2) + ":00";
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenUyeId= dataGridView1[0, e.RowIndex].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(r_id) || r_id == "0")
            {
                MessageBox.Show("Silmek için listeden bir randevu seçin.");
                return;
            }
            // Mesaj artık silme gerçekten olduktan sonra gösteriliyor.
            var silinen = Globals.Calistir("DELETE FROM Randevular_Yeni WHERE r_id = @id", ("@id", r_id));
            MessageBox.Show(silinen > 0 ? "Randevunuz Başarıyla Silinmiştir." : "Randevu bulunamadı.");
            randevulariCek();
            r_id = "0";
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            r_id = dataGridView2[0, e.RowIndex].Value.ToString(); 
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Randevular_FormClosing(object sender, FormClosingEventArgs e)
        {
            Anasayfa anaSayfa = new Anasayfa();
            anaSayfa.Show();
        }

        private void comboRandevuTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboEgitmen.Items.Clear();
            comboEgitmen.Enabled = true;
            secilenRandevuTipi = comboRandevuTipi.Items[comboRandevuTipi.SelectedIndex].ToString();
            //Eğitmenleri databaseden çekerek eğitmenidlerini listeye eğitmen adlarını combobox'a aktarıyoruz
            using (SqlConnection connection = new SqlConnection(Globals.DB))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Egitmenler WHERE UzmanlikAlani = @alan", connection);
                command.Parameters.AddWithValue("@alan", secilenRandevuTipi);
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        egitmenid.Add(Int32.Parse(reader[0].ToString()));//EĞİTMEN LİSTESİNE EĞİTMEN IDSİNİ EKLEME İŞLEMİ YAPILDI.
                        comboEgitmen.Items.Add(reader[1].ToString()); //DataReader kullanmamızın sebebi teker teker okuma yapıp değişkenlere atama yapacağımız için DR kullanmak rahatlık oluyor.
                    }
                }
            }
        }
    }
}
