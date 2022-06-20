
namespace BitirmeProjesi
{
    partial class Randevular
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Randevular));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnRandevuAl = new System.Windows.Forms.Button();
            this.comboRandevuTipi = new System.Windows.Forms.ComboBox();
            this.comboEgitmen = new System.Windows.Forms.ComboBox();
            this.btnPazartesi = new System.Windows.Forms.Button();
            this.btnSali = new System.Windows.Forms.Button();
            this.btnCarsamba = new System.Windows.Forms.Button();
            this.btnPersembe = new System.Windows.Forms.Button();
            this.btnCuma = new System.Windows.Forms.Button();
            this.btnCumartesi = new System.Windows.Forms.Button();
            this.btnPazar = new System.Windows.Forms.Button();
            this.comboPazartesi = new System.Windows.Forms.ComboBox();
            this.comboCarsamba = new System.Windows.Forms.ComboBox();
            this.comboSali = new System.Windows.Forms.ComboBox();
            this.comboCuma = new System.Windows.Forms.ComboBox();
            this.comboPersembe = new System.Windows.Forms.ComboBox();
            this.comboCumartesi = new System.Windows.Forms.ComboBox();
            this.comboPazar = new System.Windows.Forms.ComboBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(693, 302);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btnRandevuAl
            // 
            this.btnRandevuAl.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnRandevuAl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRandevuAl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRandevuAl.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRandevuAl.Location = new System.Drawing.Point(1038, 461);
            this.btnRandevuAl.Name = "btnRandevuAl";
            this.btnRandevuAl.Size = new System.Drawing.Size(203, 48);
            this.btnRandevuAl.TabIndex = 2;
            this.btnRandevuAl.Text = "Randevu Al";
            this.btnRandevuAl.UseVisualStyleBackColor = false;
            this.btnRandevuAl.Click += new System.EventHandler(this.btnRandevuAl_Click);
            // 
            // comboRandevuTipi
            // 
            this.comboRandevuTipi.FormattingEnabled = true;
            this.comboRandevuTipi.Items.AddRange(new object[] {
            "Kilo Alma",
            "Kilo Verme",
            "Sıkılaşma",
            "Fonksiyonel Fitness",
            "GFX"});
            this.comboRandevuTipi.Location = new System.Drawing.Point(1038, 384);
            this.comboRandevuTipi.Name = "comboRandevuTipi";
            this.comboRandevuTipi.Size = new System.Drawing.Size(203, 21);
            this.comboRandevuTipi.TabIndex = 4;
            this.comboRandevuTipi.SelectedIndexChanged += new System.EventHandler(this.comboRandevuTipi_SelectedIndexChanged);
            // 
            // comboEgitmen
            // 
            this.comboEgitmen.FormattingEnabled = true;
            this.comboEgitmen.Location = new System.Drawing.Point(1038, 411);
            this.comboEgitmen.Name = "comboEgitmen";
            this.comboEgitmen.Size = new System.Drawing.Size(203, 21);
            this.comboEgitmen.TabIndex = 6;
            this.comboEgitmen.SelectedIndexChanged += new System.EventHandler(this.comboEgitmen_SelectedIndexChanged);
            // 
            // btnPazartesi
            // 
            this.btnPazartesi.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnPazartesi.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnPazartesi.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnPazartesi.Location = new System.Drawing.Point(20, 19);
            this.btnPazartesi.Name = "btnPazartesi";
            this.btnPazartesi.Size = new System.Drawing.Size(92, 78);
            this.btnPazartesi.TabIndex = 7;
            this.btnPazartesi.Text = "Pazartesi";
            this.btnPazartesi.UseVisualStyleBackColor = false;
            this.btnPazartesi.UseWaitCursor = true;
            this.btnPazartesi.Click += new System.EventHandler(this.btnPazartesi_Click);
            // 
            // btnSali
            // 
            this.btnSali.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSali.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnSali.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnSali.Location = new System.Drawing.Point(118, 19);
            this.btnSali.Name = "btnSali";
            this.btnSali.Size = new System.Drawing.Size(92, 78);
            this.btnSali.TabIndex = 8;
            this.btnSali.Text = "Salı";
            this.btnSali.UseVisualStyleBackColor = false;
            this.btnSali.UseWaitCursor = true;
            this.btnSali.Click += new System.EventHandler(this.btnSali_Click);
            // 
            // btnCarsamba
            // 
            this.btnCarsamba.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnCarsamba.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnCarsamba.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnCarsamba.Location = new System.Drawing.Point(216, 19);
            this.btnCarsamba.Name = "btnCarsamba";
            this.btnCarsamba.Size = new System.Drawing.Size(92, 78);
            this.btnCarsamba.TabIndex = 10;
            this.btnCarsamba.Text = "Çarşamba";
            this.btnCarsamba.UseVisualStyleBackColor = false;
            this.btnCarsamba.UseWaitCursor = true;
            this.btnCarsamba.Click += new System.EventHandler(this.btnCarsamba_Click);
            // 
            // btnPersembe
            // 
            this.btnPersembe.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnPersembe.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnPersembe.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnPersembe.Location = new System.Drawing.Point(314, 19);
            this.btnPersembe.Name = "btnPersembe";
            this.btnPersembe.Size = new System.Drawing.Size(92, 78);
            this.btnPersembe.TabIndex = 9;
            this.btnPersembe.Text = "Perşembe";
            this.btnPersembe.UseVisualStyleBackColor = false;
            this.btnPersembe.UseWaitCursor = true;
            this.btnPersembe.Click += new System.EventHandler(this.btnPersembe_Click);
            // 
            // btnCuma
            // 
            this.btnCuma.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnCuma.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnCuma.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnCuma.Location = new System.Drawing.Point(412, 19);
            this.btnCuma.Name = "btnCuma";
            this.btnCuma.Size = new System.Drawing.Size(92, 78);
            this.btnCuma.TabIndex = 14;
            this.btnCuma.Text = "Cuma";
            this.btnCuma.UseVisualStyleBackColor = false;
            this.btnCuma.UseWaitCursor = true;
            this.btnCuma.Click += new System.EventHandler(this.btnCuma_Click);
            // 
            // btnCumartesi
            // 
            this.btnCumartesi.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnCumartesi.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnCumartesi.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnCumartesi.Location = new System.Drawing.Point(510, 19);
            this.btnCumartesi.Name = "btnCumartesi";
            this.btnCumartesi.Size = new System.Drawing.Size(92, 78);
            this.btnCumartesi.TabIndex = 13;
            this.btnCumartesi.Text = "Cumartesi";
            this.btnCumartesi.UseVisualStyleBackColor = false;
            this.btnCumartesi.UseWaitCursor = true;
            this.btnCumartesi.Click += new System.EventHandler(this.btnCumartesi_Click);
            // 
            // btnPazar
            // 
            this.btnPazar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnPazar.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.btnPazar.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnPazar.Location = new System.Drawing.Point(608, 19);
            this.btnPazar.Name = "btnPazar";
            this.btnPazar.Size = new System.Drawing.Size(92, 78);
            this.btnPazar.TabIndex = 12;
            this.btnPazar.Text = "Pazar";
            this.btnPazar.UseVisualStyleBackColor = false;
            this.btnPazar.UseWaitCursor = true;
            this.btnPazar.Click += new System.EventHandler(this.btnPazar_Click);
            // 
            // comboPazartesi
            // 
            this.comboPazartesi.FormattingEnabled = true;
            this.comboPazartesi.Items.AddRange(new object[] {
            "09:00 - 10:00",
            "12:00 - 13:00",
            "13:00 - 14:00",
            "14:00 - 15:00",
            "16:00 - 17:00",
            "18:00 - 19:00",
            "19:00 - 20:00"});
            this.comboPazartesi.Location = new System.Drawing.Point(20, 103);
            this.comboPazartesi.Name = "comboPazartesi";
            this.comboPazartesi.Size = new System.Drawing.Size(92, 24);
            this.comboPazartesi.TabIndex = 15;
            this.comboPazartesi.UseWaitCursor = true;
            this.comboPazartesi.SelectedIndexChanged += new System.EventHandler(this.comboPazartesi_SelectedIndexChanged);
            // 
            // comboCarsamba
            // 
            this.comboCarsamba.FormattingEnabled = true;
            this.comboCarsamba.Items.AddRange(new object[] {
            "09:00 - 10:00",
            "12:00 - 13:00",
            "13:00 - 14:00",
            "14:00 - 15:00",
            "16:00 - 17:00",
            "18:00 - 19:00",
            "19:00 - 20:00"});
            this.comboCarsamba.Location = new System.Drawing.Point(216, 103);
            this.comboCarsamba.Name = "comboCarsamba";
            this.comboCarsamba.Size = new System.Drawing.Size(92, 24);
            this.comboCarsamba.TabIndex = 17;
            this.comboCarsamba.UseWaitCursor = true;
            this.comboCarsamba.SelectedIndexChanged += new System.EventHandler(this.comboCarsamba_SelectedIndexChanged);
            // 
            // comboSali
            // 
            this.comboSali.FormattingEnabled = true;
            this.comboSali.Items.AddRange(new object[] {
            "09:00 - 10:00",
            "12:00 - 13:00",
            "13:00 - 14:00",
            "14:00 - 15:00",
            "16:00 - 17:00",
            "18:00 - 19:00",
            "19:00 - 20:00"});
            this.comboSali.Location = new System.Drawing.Point(118, 103);
            this.comboSali.Name = "comboSali";
            this.comboSali.Size = new System.Drawing.Size(92, 24);
            this.comboSali.TabIndex = 16;
            this.comboSali.UseWaitCursor = true;
            this.comboSali.SelectedIndexChanged += new System.EventHandler(this.comboSali_SelectedIndexChanged);
            // 
            // comboCuma
            // 
            this.comboCuma.FormattingEnabled = true;
            this.comboCuma.Items.AddRange(new object[] {
            "09:00 - 10:00",
            "12:00 - 13:00",
            "13:00 - 14:00",
            "14:00 - 15:00",
            "16:00 - 17:00",
            "18:00 - 19:00",
            "19:00 - 20:00"});
            this.comboCuma.Location = new System.Drawing.Point(412, 103);
            this.comboCuma.Name = "comboCuma";
            this.comboCuma.Size = new System.Drawing.Size(92, 24);
            this.comboCuma.TabIndex = 19;
            this.comboCuma.UseWaitCursor = true;
            this.comboCuma.SelectedIndexChanged += new System.EventHandler(this.comboCuma_SelectedIndexChanged);
            // 
            // comboPersembe
            // 
            this.comboPersembe.FormattingEnabled = true;
            this.comboPersembe.Items.AddRange(new object[] {
            "09:00 - 10:00",
            "12:00 - 13:00",
            "13:00 - 14:00",
            "14:00 - 15:00",
            "16:00 - 17:00",
            "18:00 - 19:00",
            "19:00 - 20:00"});
            this.comboPersembe.Location = new System.Drawing.Point(314, 103);
            this.comboPersembe.Name = "comboPersembe";
            this.comboPersembe.Size = new System.Drawing.Size(92, 24);
            this.comboPersembe.TabIndex = 18;
            this.comboPersembe.UseWaitCursor = true;
            this.comboPersembe.SelectedIndexChanged += new System.EventHandler(this.comboPersembe_SelectedIndexChanged);
            // 
            // comboCumartesi
            // 
            this.comboCumartesi.FormattingEnabled = true;
            this.comboCumartesi.Items.AddRange(new object[] {
            "09:00 - 10:00",
            "12:00 - 13:00",
            "13:00 - 14:00",
            "14:00 - 15:00",
            "16:00 - 17:00",
            "18:00 - 19:00",
            "19:00 - 20:00"});
            this.comboCumartesi.Location = new System.Drawing.Point(510, 103);
            this.comboCumartesi.Name = "comboCumartesi";
            this.comboCumartesi.Size = new System.Drawing.Size(92, 24);
            this.comboCumartesi.TabIndex = 20;
            this.comboCumartesi.UseWaitCursor = true;
            this.comboCumartesi.SelectedIndexChanged += new System.EventHandler(this.comboCumartesi_SelectedIndexChanged);
            // 
            // comboPazar
            // 
            this.comboPazar.FormattingEnabled = true;
            this.comboPazar.Items.AddRange(new object[] {
            "09:00 - 10:00",
            "12:00 - 13:00",
            "13:00 - 14:00",
            "14:00 - 15:00",
            "16:00 - 17:00",
            "18:00 - 19:00",
            "19:00 - 20:00"});
            this.comboPazar.Location = new System.Drawing.Point(608, 103);
            this.comboPazar.Name = "comboPazar";
            this.comboPazar.Size = new System.Drawing.Size(92, 24);
            this.comboPazar.TabIndex = 21;
            this.comboPazar.UseWaitCursor = true;
            this.comboPazar.SelectedIndexChanged += new System.EventHandler(this.comboPazar_SelectedIndexChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(734, 58);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(752, 302);
            this.dataGridView2.TabIndex = 22;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(910, 387);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "Randevu Tipi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(936, 414);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 18);
            this.label2.TabIndex = 24;
            this.label2.Text = "Eğitmen:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MidnightBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(931, 461);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 48);
            this.button1.TabIndex = 25;
            this.button1.Text = "Randevu Sil";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnPazar);
            this.groupBox1.Controls.Add(this.btnPazartesi);
            this.groupBox1.Controls.Add(this.btnSali);
            this.groupBox1.Controls.Add(this.btnPersembe);
            this.groupBox1.Controls.Add(this.btnCarsamba);
            this.groupBox1.Controls.Add(this.comboPazar);
            this.groupBox1.Controls.Add(this.btnCumartesi);
            this.groupBox1.Controls.Add(this.comboCumartesi);
            this.groupBox1.Controls.Add(this.btnCuma);
            this.groupBox1.Controls.Add(this.comboCuma);
            this.groupBox1.Controls.Add(this.comboPazartesi);
            this.groupBox1.Controls.Add(this.comboPersembe);
            this.groupBox1.Controls.Add(this.comboSali);
            this.groupBox1.Controls.Add(this.comboCarsamba);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Location = new System.Drawing.Point(3, 384);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 132);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tarih Seçimi";
            this.groupBox1.UseWaitCursor = true;
            // 
            // Randevular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1498, 592);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.comboEgitmen);
            this.Controls.Add(this.comboRandevuTipi);
            this.Controls.Add(this.btnRandevuAl);
            this.Controls.Add(this.dataGridView1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Randevular";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Randevu Sistemi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Randevular_FormClosing);
            this.Load += new System.EventHandler(this.Randevular_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRandevuAl;
        private System.Windows.Forms.ComboBox comboRandevuTipi;
        private System.Windows.Forms.ComboBox comboEgitmen;
        private System.Windows.Forms.Button btnPazartesi;
        private System.Windows.Forms.Button btnSali;
        private System.Windows.Forms.Button btnCarsamba;
        private System.Windows.Forms.Button btnPersembe;
        private System.Windows.Forms.Button btnCuma;
        private System.Windows.Forms.Button btnCumartesi;
        private System.Windows.Forms.Button btnPazar;
        private System.Windows.Forms.ComboBox comboPazartesi;
        private System.Windows.Forms.ComboBox comboCarsamba;
        private System.Windows.Forms.ComboBox comboSali;
        private System.Windows.Forms.ComboBox comboCuma;
        private System.Windows.Forms.ComboBox comboPersembe;
        private System.Windows.Forms.ComboBox comboCumartesi;
        private System.Windows.Forms.ComboBox comboPazar;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}