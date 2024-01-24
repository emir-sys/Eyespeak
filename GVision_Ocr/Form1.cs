using Google.Cloud.Vision.V1;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Google.Cloud.Translation.V2;
using Google.Cloud.TextToSpeech.V1;
using System.IO;
using NAudio.Wave;
using GemBox.Pdf;
using System.Runtime.ExceptionServices;

namespace GVision_Ocr
{

    public partial class Form1 : Form
    {
        Bitmap orjinalresim;
        bool Seciyormu;
        int x0, y0, x1, y1;
        //Ses dosyasının oynatılması için NAudio kütüphanesi nesneleri.
        WaveOutEvent MedyaOynatici = new WaveOutEvent();
        WaveChannel32 seskanali;
        WaveStream cikisKanali;
        TimeSpan uzunluk;
        int sure = 0;
        //Google TextToSpeech Kütüphanesi nesneleri
        VoiceSelectionParams sesSecimi;
        TextToSpeechClient resimAnalizNesnesi;
        SynthesisInput OkunacakMetin;
        AudioConfig sesAyarlari;
        Stream SesDosyasi;
        public Form1()
        {
            InitializeComponent();
        }
        public static void Set(string isim, string deger)
        {
            //Google Cloud servisini kullanmamızı sağlayan json dosyamızın yerini
            //Sisteme tanıtmamızı sağlayan fonksiyon
            Environment.SetEnvironmentVariable(isim, deger, EnvironmentVariableTarget.Machine);
            Environment.SetEnvironmentVariable(isim, deger, EnvironmentVariableTarget.User);
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //Kullandığımız PDF to IMG kütüphanesinin ücretsiz lisansı.
            try
            {
                ComponentInfo.SetLicense("FREE-LIMITED-KEY");
                PdfDocument belge;
                if (openFileDialog1.SafeFileName.Contains(".pdf"))
                {
                    // Yüklenen PDF'i IMG dosyasına dönüştürdükten sonra kaydetmemiz gerekiyor
                    // kaydettikten sonra ise picturebox1'e aktarıyoruz.
                    belge = PdfDocument.Load(openFileDialog1.FileName);
                    if (belge != null)
                    {
                        try
                        {
                            belge.Save("DonusturulenBelge.jpg",SaveOptions.Image);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Geçersiz PDF formatı.");
                        }

                        Bitmap b = new Bitmap(Application.StartupPath + @"\DonusturulenBelge.jpg");
                        Bitmap b2 = new Bitmap(b);
                        pbTumu.Image = b2;
                        b.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz PDF formatı.");
                    }
                }
                else
                {
                    pbTumu.Image = new Bitmap(openFileDialog1.FileName);
                }
                orjinalresim = new Bitmap(pbTumu.Image);
                label1.Text = "Analiz Edebilirsiniz.";
                label1.ForeColor = Color.Green;
            }
            catch (Exception)
            {
                MessageBox.Show("Geçersiz PDF formatı.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Set("GOOGLE_APPLICATION_CREDENTIALS", @Application.StartupPath + @"\ocrproject-384722-ba51596c78dd.json");
            }
            catch (Exception)
            {
                MessageBox.Show("Google Anahtar Kurulumu için yönetici olarak çalıştırın.");
            }
            radioErkekSes.Checked = true;
            radioYazi.Checked = true;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (orjinalresim != null)
            {
                Seciyormu = true;
                // Başlangıç noktasını kaydediyoruz.
                x0 = e.X;
                y0 = e.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (orjinalresim != null)
            {
                if (!Seciyormu) return;

                x1 = e.X;
                y1 = e.Y;

                Bitmap bm = new Bitmap(orjinalresim);
                float X = (float)orjinalresim.Size.Width / pbTumu.Width;
                float Y = (float)orjinalresim.Size.Height / pbTumu.Height;
                Pen p = new Pen(Color.Red, 20);
                using (Graphics gr = Graphics.FromImage(bm))
                {
                    //Seçilen alanın gösterilmesi için DrawRectangle ile kenarları kırmızı
                    //yapıyoruz.
                    gr.DrawRectangle(p,
                        Math.Min(x0, x1) * X, Math.Min(y0, y1) * Y,
                        Math.Abs(x0 - x1) * X, Math.Abs(y0 - y1) * Y
                        );
                }

                pbTumu.Image = new Bitmap(bm, new Size(pbTumu.Width, pbTumu.Height));
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (orjinalresim != null)
            {
                if (!Seciyormu) return;
                Seciyormu = false;
                pbTumu.Image = orjinalresim;
                float X = (float)orjinalresim.Size.Width / pbTumu.Width;
                float Y = (float)orjinalresim.Size.Height / pbTumu.Height;
                int wid = (int)(X * Math.Abs(x0 - x1));
                int hgt = (int)(Y * Math.Abs(y0 - y1));
                if ((wid < 1) || (hgt < 1)) return;
                Bitmap alan = new Bitmap(wid, hgt);
                using (Graphics gr = Graphics.FromImage(alan))
                {
                    Rectangle kaynak_secim =
                        new Rectangle((int)(X * Math.Min(x0, x1)), (int)(Y * Math.Min(y0, y1)),
                            wid, hgt);
                    Rectangle dest_rectangle =
                        new Rectangle(0, 0, wid, hgt);
                    gr.DrawImage(orjinalresim, dest_rectangle,
                        kaynak_secim, GraphicsUnit.Pixel);
                }
                pbSecim.Image = alan;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //NAudio kütüphanesinde, okumanın bittiğini bildiren bir özellik yok, bu sebeple timer 
            //kullanarak metin okumanın bitmesini kontrol ediyoruz.
            if ((uzunluk.Seconds + (uzunluk.Minutes * 60)) == sure)
            {
                //Bittiğinde çakışmalar olmaması ve ses dosyasını tekrar kullanabilmemiz için
                //tüm ses nesnelerini kapatıyoruz.
                MedyaOynatici.Dispose();
                seskanali.Close();
                cikisKanali.Close();
                SesDosyasi.Close();

                label1.Text = "disposed";
                btnSeslendir.Enabled = true;
                btnDuraklat.Enabled = false;
                btnDurdur.Enabled = false;
                timer1.Stop();
            }
            else
            {
                sure++;
            }
        }

        private void btnTumunuAnaliz_Click(object sender, EventArgs e)
        {
            if (pbTumu.Image != null)
            {
                Analiz(pbTumu);
            }
            else
            {
                label1.Text = "Lütfen bir resim seçiniz.";
                label1.ForeColor = Color.Red;
            }
        }

        private void btnSecileniAnaliz_Click(object sender, EventArgs e)
        {
            if (pbSecim.Image != null)
            {
                Analiz(pbSecim);
            }
            else
            {
                label1.Text = "Lütfen bir alan seçiniz.";
                label1.ForeColor = Color.Red;
            }
        }

        private void btnDuraklat_click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                MedyaOynatici.Pause();
                btnDuraklat.Text = "Oynat";
                timer1.Stop();
            }
            else
            {
                MedyaOynatici.Play();
                timer1.Start();
                btnDuraklat.Text = "Duraklat";
            }
        }

        private void btnDurdur_Click(object sender, EventArgs e)
        {
            MedyaOynatici.Dispose();
            seskanali.Dispose();
            cikisKanali.Dispose();
            SesDosyasi.Close();
            btnSeslendir.Enabled = true;
            btnDuraklat.Enabled = false;
            btnDurdur.Enabled = false;
            timer1.Stop();
        }
        private void btnSeslendir_Click(object sender, EventArgs e)
        {
            if (tbMetin.Text == "")
            {
                label1.Text = "Önce Analiz Yapmalısınız.";
                label1.ForeColor = Color.Red;
                return;
            }
            sure = 0;
            btnSeslendir.Enabled = false;
            resimAnalizNesnesi = TextToSpeechClient.Create();
            OkunacakMetin = new SynthesisInput
            {
                Text = tbMetin.Text
            };
            sesSecimi = new VoiceSelectionParams
            {
                //Bu iki ayar ile seslendirenin Cinsiyetini ve Seslendirilecek dili belirleyebiliyoruz.
                LanguageCode = "tr-TR",
            };
            if (radioErkekSes.Checked) sesSecimi.SsmlGender = SsmlVoiceGender.Male;
            else sesSecimi.SsmlGender = SsmlVoiceGender.Female;
            sesAyarlari = new AudioConfig
            {
                //Ses dosyasının hangi uzantı ile oluşturulacağını belirliyoruz.
                //Tercihler arasındaki en iyi format Mp3
                AudioEncoding = AudioEncoding.Mp3
            };
            SynthesizeSpeechResponse sonuc = resimAnalizNesnesi.SynthesizeSpeech(OkunacakMetin, sesSecimi, sesAyarlari);
            if (File.Exists("SesDosyasi.mp3")) File.Delete("SesDosyasi.mp3");
            SesDosyasi = File.Create("SesDosyasi.mp3");
            using (SesDosyasi)
            {
                // sonuc.AudioContent bir ByteString'dir Bunu kolayca byte dizisine çevirebiliriz
                // veya Stream'e aktarabiliriz.
                sonuc.AudioContent.WriteTo(SesDosyasi);

            }
            //Textbox içindeki veriler okunup ses dosyasına çevrildikten sonra, ses dosyası çalıştırılıyor.
            cikisKanali = new Mp3FileReader("SesDosyasi.mp3");
            uzunluk = cikisKanali.TotalTime;
            seskanali = new WaveChannel32(cikisKanali);

            MedyaOynatici.Init(seskanali);
            timer1.Start();
            MedyaOynatici.Play();
            btnDuraklat.Enabled = true;
            btnDurdur.Enabled = true;
        }

        private void btnResim_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            openFileDialog1.ShowDialog();
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PDF files (*.pdf) | *.pdf";
            openFileDialog1.ShowDialog();
        }
        void Analiz(PictureBox p)
        {
            try
            {
                //Memorystream ile pictureboxta açık olan resmi geçici olarak hafızaya alıyoruz
                //Bunu daha sonra diğer işlemler için kullanabiliyoruz.
                p.Image.Save("analiz.png", System.Drawing.Imaging.ImageFormat.Png);
                var resimAnalizNesnesi = ImageAnnotatorClient.Create();
                // var image = Google.Cloud.Vision.V1.Image.FromFile(openFileDialog1.FileName);
                var image = Google.Cloud.Vision.V1.Image.FromFile(Application.StartupPath + @"\analiz.png");
                label1.Text = "Analiz Ediliyor..";
                label1.ForeColor = Color.Green;

                if (radioObje.Checked)
                {
                    var sonuc = resimAnalizNesnesi.DetectLabels(image);
                    tbMetin.Text = "";
                    foreach (var satir in sonuc)
                    {
                        if (satir.Description != null)
                        {
                            tbMetin.Text += satir.Description + "\r\n";
                        }
                    }
                }
                else
                {
                    var sonuc = resimAnalizNesnesi.DetectText(image);
                    tbMetin.Text = "";
                    foreach (var satir in sonuc)
                    {
                        if (satir.Description != null)
                        {
                            tbMetin.Text += satir.Description + "\r\n";
                            break;
                        }
                    }
                }
                //İşlem bittikten sonra türkçe çeviri yapıyoruz.
                var ingTurkceCeviri = TranslationClient.Create();
                if (radioObje.Checked)
                    tbMetin.Text = ingTurkceCeviri.TranslateText(tbMetin.Text, "tr").TranslatedText;
                label1.Text = "Analiz İşlemi Başarıyla Tamamlandı.";
                label1.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kimlik Doğrulama Başarısız. Lütfen uygulamayı bir kere yönetici olarak çalıştırın ve bilgisayarınızı yeniden başlatın.");
            }

        }
    }
}
