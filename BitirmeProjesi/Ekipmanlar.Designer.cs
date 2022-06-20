
namespace BitirmeProjesi
{
    partial class Ekipmanlar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ekipmanlar));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtekipmanAdi = new System.Windows.Forms.TextBox();
            this.txtUcret = new System.Windows.Forms.TextBox();
            this.txtAciklama = new System.Windows.Forms.RichTextBox();
            this.dateGaranti = new System.Windows.Forms.DateTimePicker();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnGoruntule = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.txtKullanilankas = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboKlup = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(141, 176);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ekipman Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(136, 256);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ekipman Açıklaması";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(136, 366);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kullanılan Kas Grubu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(135, 436);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Garanti Tarihi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(135, 497);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ücret";
            // 
            // txtekipmanAdi
            // 
            this.txtekipmanAdi.Location = new System.Drawing.Point(356, 167);
            this.txtekipmanAdi.Margin = new System.Windows.Forms.Padding(4);
            this.txtekipmanAdi.Name = "txtekipmanAdi";
            this.txtekipmanAdi.Size = new System.Drawing.Size(168, 22);
            this.txtekipmanAdi.TabIndex = 5;
            // 
            // txtUcret
            // 
            this.txtUcret.Location = new System.Drawing.Point(356, 489);
            this.txtUcret.Margin = new System.Windows.Forms.Padding(4);
            this.txtUcret.Name = "txtUcret";
            this.txtUcret.Size = new System.Drawing.Size(168, 22);
            this.txtUcret.TabIndex = 6;
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(356, 215);
            this.txtAciklama.Margin = new System.Windows.Forms.Padding(4);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(427, 117);
            this.txtAciklama.TabIndex = 7;
            this.txtAciklama.Text = "";
            this.txtAciklama.TextChanged += new System.EventHandler(this.txtAciklama_TextChanged);
            // 
            // dateGaranti
            // 
            this.dateGaranti.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateGaranti.Location = new System.Drawing.Point(356, 428);
            this.dateGaranti.Margin = new System.Windows.Forms.Padding(4);
            this.dateGaranti.Name = "dateGaranti";
            this.dateGaranti.Size = new System.Drawing.Size(298, 22);
            this.dateGaranti.TabIndex = 8;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKaydet.Location = new System.Drawing.Point(356, 638);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(4);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(112, 28);
            this.btnKaydet.TabIndex = 9;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnGoruntule
            // 
            this.btnGoruntule.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoruntule.Location = new System.Drawing.Point(626, 638);
            this.btnGoruntule.Margin = new System.Windows.Forms.Padding(4);
            this.btnGoruntule.Name = "btnGoruntule";
            this.btnGoruntule.Size = new System.Drawing.Size(171, 28);
            this.btnGoruntule.TabIndex = 10;
            this.btnGoruntule.Text = "Ekipmanları Görüntüle";
            this.btnGoruntule.UseVisualStyleBackColor = true;
            this.btnGoruntule.Click += new System.EventHandler(this.btnGoruntule_Click_1);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTemizle.Location = new System.Drawing.Point(490, 638);
            this.btnTemizle.Margin = new System.Windows.Forms.Padding(4);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(112, 28);
            this.btnTemizle.TabIndex = 11;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // txtKullanilankas
            // 
            this.txtKullanilankas.Location = new System.Drawing.Point(356, 362);
            this.txtKullanilankas.Margin = new System.Windows.Forms.Padding(4);
            this.txtKullanilankas.Name = "txtKullanilankas";
            this.txtKullanilankas.Size = new System.Drawing.Size(168, 22);
            this.txtKullanilankas.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(135, 566);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Teslimat Edilecek Klüp";
            // 
            // comboKlup
            // 
            this.comboKlup.FormattingEnabled = true;
            this.comboKlup.Items.AddRange(new object[] {
            "Kadıköy",
            "Kartal",
            "Maltepe"});
            this.comboKlup.Location = new System.Drawing.Point(356, 556);
            this.comboKlup.Margin = new System.Windows.Forms.Padding(4);
            this.comboKlup.Name = "comboKlup";
            this.comboKlup.Size = new System.Drawing.Size(180, 24);
            this.comboKlup.TabIndex = 14;
            // 
            // Ekipmanlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1340, 715);
            this.Controls.Add(this.comboKlup);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtKullanilankas);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.btnGoruntule);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.dateGaranti);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.txtUcret);
            this.Controls.Add(this.txtekipmanAdi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Ekipmanlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ekipmanlar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ekipmanlar_FormClosing);
            this.Load += new System.EventHandler(this.Ekipmanlar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtekipmanAdi;
        private System.Windows.Forms.TextBox txtUcret;
        private System.Windows.Forms.RichTextBox txtAciklama;
        private System.Windows.Forms.DateTimePicker dateGaranti;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Button btnGoruntule;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.TextBox txtKullanilankas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboKlup;
    }
}