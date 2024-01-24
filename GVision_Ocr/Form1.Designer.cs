namespace GVision_Ocr
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.btnResim = new System.Windows.Forms.Button();
            this.tbMetin = new System.Windows.Forms.TextBox();
            this.btnSeslendir = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnTumunuAnaliz = new System.Windows.Forms.Button();
            this.btnPdf = new System.Windows.Forms.Button();
            this.pbSecim = new System.Windows.Forms.PictureBox();
            this.gbSeslendir = new System.Windows.Forms.GroupBox();
            this.radioKadinSes = new System.Windows.Forms.RadioButton();
            this.radioErkekSes = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSecileniAnaliz = new System.Windows.Forms.Button();
            this.gbAnaliz = new System.Windows.Forms.GroupBox();
            this.radioYazi = new System.Windows.Forms.RadioButton();
            this.radioObje = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pbTumu = new System.Windows.Forms.PictureBox();
            this.btnDuraklat = new System.Windows.Forms.Button();
            this.btnDurdur = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecim)).BeginInit();
            this.gbSeslendir.SuspendLayout();
            this.gbAnaliz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTumu)).BeginInit();
            this.SuspendLayout();
            // 
            // btnResim
            // 
            this.btnResim.Location = new System.Drawing.Point(237, 15);
            this.btnResim.Margin = new System.Windows.Forms.Padding(4);
            this.btnResim.Name = "btnResim";
            this.btnResim.Size = new System.Drawing.Size(103, 28);
            this.btnResim.TabIndex = 0;
            this.btnResim.Text = "Resim Yükle";
            this.btnResim.UseVisualStyleBackColor = true;
            this.btnResim.Click += new System.EventHandler(this.btnResim_Click);
            // 
            // tbMetin
            // 
            this.tbMetin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMetin.Location = new System.Drawing.Point(875, 12);
            this.tbMetin.Margin = new System.Windows.Forms.Padding(4);
            this.tbMetin.Multiline = true;
            this.tbMetin.Name = "tbMetin";
            this.tbMetin.Size = new System.Drawing.Size(381, 526);
            this.tbMetin.TabIndex = 2;
            // 
            // btnSeslendir
            // 
            this.btnSeslendir.Location = new System.Drawing.Point(8, 75);
            this.btnSeslendir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSeslendir.Name = "btnSeslendir";
            this.btnSeslendir.Size = new System.Drawing.Size(145, 59);
            this.btnSeslendir.TabIndex = 3;
            this.btnSeslendir.Text = "Seslendir";
            this.btnSeslendir.UseVisualStyleBackColor = true;
            this.btnSeslendir.Click += new System.EventHandler(this.btnSeslendir_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnTumunuAnaliz
            // 
            this.btnTumunuAnaliz.Location = new System.Drawing.Point(8, 75);
            this.btnTumunuAnaliz.Margin = new System.Windows.Forms.Padding(4);
            this.btnTumunuAnaliz.Name = "btnTumunuAnaliz";
            this.btnTumunuAnaliz.Size = new System.Drawing.Size(239, 31);
            this.btnTumunuAnaliz.TabIndex = 4;
            this.btnTumunuAnaliz.Text = "Tümünü Analiz Et";
            this.btnTumunuAnaliz.UseVisualStyleBackColor = true;
            this.btnTumunuAnaliz.Click += new System.EventHandler(this.btnTumunuAnaliz_Click);
            // 
            // btnPdf
            // 
            this.btnPdf.Location = new System.Drawing.Point(348, 15);
            this.btnPdf.Margin = new System.Windows.Forms.Padding(4);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(92, 28);
            this.btnPdf.TabIndex = 5;
            this.btnPdf.Text = "PDF Yükle";
            this.btnPdf.UseVisualStyleBackColor = true;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // pbSecim
            // 
            this.pbSecim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pbSecim.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbSecim.Location = new System.Drawing.Point(16, 245);
            this.pbSecim.Margin = new System.Windows.Forms.Padding(4);
            this.pbSecim.Name = "pbSecim";
            this.pbSecim.Size = new System.Drawing.Size(423, 293);
            this.pbSecim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSecim.TabIndex = 6;
            this.pbSecim.TabStop = false;
            // 
            // gbSeslendir
            // 
            this.gbSeslendir.Controls.Add(this.radioKadinSes);
            this.gbSeslendir.Controls.Add(this.radioErkekSes);
            this.gbSeslendir.Controls.Add(this.btnSeslendir);
            this.gbSeslendir.Location = new System.Drawing.Point(279, 47);
            this.gbSeslendir.Margin = new System.Windows.Forms.Padding(4);
            this.gbSeslendir.Name = "gbSeslendir";
            this.gbSeslendir.Padding = new System.Windows.Forms.Padding(4);
            this.gbSeslendir.Size = new System.Drawing.Size(161, 142);
            this.gbSeslendir.TabIndex = 7;
            this.gbSeslendir.TabStop = false;
            this.gbSeslendir.Text = "Seslendirme";
            // 
            // radioKadinSes
            // 
            this.radioKadinSes.AutoSize = true;
            this.radioKadinSes.Location = new System.Drawing.Point(84, 32);
            this.radioKadinSes.Margin = new System.Windows.Forms.Padding(4);
            this.radioKadinSes.Name = "radioKadinSes";
            this.radioKadinSes.Size = new System.Drawing.Size(62, 20);
            this.radioKadinSes.TabIndex = 1;
            this.radioKadinSes.Text = "Kadın";
            this.radioKadinSes.UseVisualStyleBackColor = true;
            // 
            // radioErkekSes
            // 
            this.radioErkekSes.AutoSize = true;
            this.radioErkekSes.Location = new System.Drawing.Point(4, 32);
            this.radioErkekSes.Margin = new System.Windows.Forms.Padding(4);
            this.radioErkekSes.Name = "radioErkekSes";
            this.radioErkekSes.Size = new System.Drawing.Size(63, 20);
            this.radioErkekSes.TabIndex = 0;
            this.radioErkekSes.Text = "Erkek";
            this.radioErkekSes.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSecileniAnaliz
            // 
            this.btnSecileniAnaliz.Location = new System.Drawing.Point(8, 111);
            this.btnSecileniAnaliz.Margin = new System.Windows.Forms.Padding(4);
            this.btnSecileniAnaliz.Name = "btnSecileniAnaliz";
            this.btnSecileniAnaliz.Size = new System.Drawing.Size(239, 31);
            this.btnSecileniAnaliz.TabIndex = 9;
            this.btnSecileniAnaliz.Text = "Seçileni Analiz Et";
            this.btnSecileniAnaliz.UseVisualStyleBackColor = true;
            this.btnSecileniAnaliz.Click += new System.EventHandler(this.btnSecileniAnaliz_Click);
            // 
            // gbAnaliz
            // 
            this.gbAnaliz.Controls.Add(this.radioYazi);
            this.gbAnaliz.Controls.Add(this.btnSecileniAnaliz);
            this.gbAnaliz.Controls.Add(this.radioObje);
            this.gbAnaliz.Controls.Add(this.btnTumunuAnaliz);
            this.gbAnaliz.Location = new System.Drawing.Point(16, 47);
            this.gbAnaliz.Margin = new System.Windows.Forms.Padding(4);
            this.gbAnaliz.Name = "gbAnaliz";
            this.gbAnaliz.Padding = new System.Windows.Forms.Padding(4);
            this.gbAnaliz.Size = new System.Drawing.Size(255, 149);
            this.gbAnaliz.TabIndex = 8;
            this.gbAnaliz.TabStop = false;
            this.gbAnaliz.Text = "Analiz";
            // 
            // radioYazi
            // 
            this.radioYazi.AutoSize = true;
            this.radioYazi.Location = new System.Drawing.Point(8, 47);
            this.radioYazi.Margin = new System.Windows.Forms.Padding(4);
            this.radioYazi.Name = "radioYazi";
            this.radioYazi.Size = new System.Drawing.Size(110, 20);
            this.radioYazi.TabIndex = 1;
            this.radioYazi.Text = "Yazı Algılama";
            this.radioYazi.UseVisualStyleBackColor = true;
            // 
            // radioObje
            // 
            this.radioObje.AutoSize = true;
            this.radioObje.Location = new System.Drawing.Point(8, 23);
            this.radioObje.Margin = new System.Windows.Forms.Padding(4);
            this.radioObje.Name = "radioObje";
            this.radioObje.Size = new System.Drawing.Size(113, 20);
            this.radioObje.TabIndex = 0;
            this.radioObje.Text = "Obje Algılama";
            this.radioObje.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 207);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 10;
            // 
            // pbTumu
            // 
            this.pbTumu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTumu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbTumu.Location = new System.Drawing.Point(448, 15);
            this.pbTumu.Margin = new System.Windows.Forms.Padding(4);
            this.pbTumu.Name = "pbTumu";
            this.pbTumu.Size = new System.Drawing.Size(417, 523);
            this.pbTumu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTumu.TabIndex = 1;
            this.pbTumu.TabStop = false;
            this.pbTumu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pbTumu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pbTumu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // btnDuraklat
            // 
            this.btnDuraklat.Enabled = false;
            this.btnDuraklat.Location = new System.Drawing.Point(279, 207);
            this.btnDuraklat.Margin = new System.Windows.Forms.Padding(4);
            this.btnDuraklat.Name = "btnDuraklat";
            this.btnDuraklat.Size = new System.Drawing.Size(76, 28);
            this.btnDuraklat.TabIndex = 11;
            this.btnDuraklat.Text = "Duraklat";
            this.btnDuraklat.UseVisualStyleBackColor = true;
            this.btnDuraklat.Click += new System.EventHandler(this.btnDuraklat_click);
            // 
            // btnDurdur
            // 
            this.btnDurdur.Enabled = false;
            this.btnDurdur.Location = new System.Drawing.Point(363, 207);
            this.btnDurdur.Margin = new System.Windows.Forms.Padding(4);
            this.btnDurdur.Name = "btnDurdur";
            this.btnDurdur.Size = new System.Drawing.Size(69, 28);
            this.btnDurdur.TabIndex = 12;
            this.btnDurdur.Text = "Durdur";
            this.btnDurdur.UseVisualStyleBackColor = true;
            this.btnDurdur.Click += new System.EventHandler(this.btnDurdur_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 554);
            this.Controls.Add(this.btnDurdur);
            this.Controls.Add(this.btnDuraklat);
            this.Controls.Add(this.pbTumu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbAnaliz);
            this.Controls.Add(this.gbSeslendir);
            this.Controls.Add(this.pbSecim);
            this.Controls.Add(this.btnPdf);
            this.Controls.Add(this.tbMetin);
            this.Controls.Add(this.btnResim);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "EyeSpeak";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSecim)).EndInit();
            this.gbSeslendir.ResumeLayout(false);
            this.gbSeslendir.PerformLayout();
            this.gbAnaliz.ResumeLayout(false);
            this.gbAnaliz.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTumu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnResim;
        private System.Windows.Forms.TextBox tbMetin;
        private System.Windows.Forms.Button btnSeslendir;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnTumunuAnaliz;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.PictureBox pbSecim;
        private System.Windows.Forms.GroupBox gbSeslendir;
        private System.Windows.Forms.RadioButton radioKadinSes;
        private System.Windows.Forms.RadioButton radioErkekSes;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSecileniAnaliz;
        private System.Windows.Forms.GroupBox gbAnaliz;
        private System.Windows.Forms.RadioButton radioYazi;
        private System.Windows.Forms.RadioButton radioObje;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbTumu;
        private System.Windows.Forms.Button btnDuraklat;
        private System.Windows.Forms.Button btnDurdur;
    }
}

