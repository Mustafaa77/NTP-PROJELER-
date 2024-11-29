using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Araba_yarisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            basla();
           
        }

        /*
         Program içinde kullanacağımız genel değişkenleri tanımlıyoruz...
        */
        int kazanilan_puan = 0;
        int yol_hizi = 5;
        int araba_hiz = 5;
        bool sol_yon = false;
        bool sag_yon = false;
        int diger_araba_hizi = 5;
        Random rnd = new Random();

        private void basla()
        {
            //başlat butonu ve çaprma efektini pasif yapıyoruz
            button1.Enabled = false;
            carpma.Visible = false;

            //Arabanın ve yolun aşağıya doğru kayma hızı
            diger_araba_hizi = 5;
            yol_hizi = 5;

            kazanilan_puan = 0;

            //Arabamızın koordinatı
            bizim_araba.Left = 166;
            bizim_araba.Top = 293;

            //Kontrol tuşlarını yasif yapıyoruz
            sol_yon = false;
            sag_yon = false;

            //Diğer arabaların koordinatları
            araba1.Left = 66;
            araba1.Top = -120;
            araba2.Left = 294;
            araba2.Top = -185;

            //Zeminde hareket edecek olan yolun koordinatı
            yol1.Left = -3;
            yol1.Top = -222;
            yol2.Left = -2;
            yol2.Top = -638;
                       
            timer1.Start();

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //Süre başladığında puan artışı ve ekrana yazdırma
            kazanilan_puan++;
            puan.Text = kazanilan_puan.ToString();

            //Yolun yukardan aşağı hareketi ve tekrar başa dönme kontrolü   
            yol1.Top += yol_hizi;
            yol2.Top += yol_hizi;
            if (yol1.Top > 630) yol1.Top = -630;
            if (yol2.Top > 630) yol2.Top = -630;

            //Yön tuşları ile arabanın hareketi 
            if (sol_yon) bizim_araba.Left -= araba_hiz;
            if (sag_yon) bizim_araba.Left += araba_hiz;
            if (bizim_araba.Left < 1) { sol_yon = false; }
            else if (bizim_araba.Left + bizim_araba.Width > 380) { sag_yon = false; }
            
            //Diğer arabaların aşağı doğru hareketi ve rastgele bir değer üretilip tekrardan ekrana gelmesi..
            araba1.Top += diger_araba_hizi;
            araba2.Top += diger_araba_hizi;
            if (araba1.Top > panel1.Height)
            {
                araba1_degistir();
                araba1.Left = rnd.Next(2, 160);
                araba1.Top = rnd.Next(100, 200) * -1;
            }

            if (araba2.Top > panel1.Height)
            {
                araba2_degistir();
                araba2.Left = rnd.Next(185, 327);
                araba2.Top = rnd.Next(100, 200) * -1;
            }

            //Arabanın diğer arabaları çarpma kontrolü ve oyun biti fonk. çalıştırılması
            if (bizim_araba.Bounds.IntersectsWith(araba1.Bounds) || bizim_araba.Bounds.IntersectsWith(araba2.Bounds))
            {
                oyunBitti();
            }



        }

        private void oyunBitti()
        {
            //Eğer çarpma olduysa ekranda puan gösterilip tekrar başlayabilmek için buton aktif hale geliyor....   
            timer1.Stop();
            button1.Enabled = true;
            carpma.Visible = true;
            bizim_araba.Controls.Add(carpma);
            carpma.Location = new Point(-8, 5);
            carpma.BringToFront();
            carpma.BackColor = Color.Transparent;
            MessageBox.Show("Tebrikler " + puan.Text + " kazandınız", "Oyun Sonu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private void araba1_degistir()
        {
            //Diğer arabalar ekranda kaybolunca 1-7 arasında rastgele bir değer üretilip 
            //eklenen resimlerin ekrana getirilmesini sağlıyoruz....
         
            int sira = rnd.Next(1, 7);
            switch (sira)
            {
                case 1:
                    araba1.Image = Properties.Resources.araba2;
                    break;
                case 2:
                    araba1.Image = Properties.Resources.araba3;
                    break;
                case 3:
                    araba1.Image = Properties.Resources.araba4;
                    break;
                case 4:
                    araba1.Image = Properties.Resources.araba5;
                    break;
                case 5:
                    araba1.Image = Properties.Resources.araba6;
                    break;
                case 6:
                    araba1.Image = Properties.Resources.araba7;
                    break;
                case 7:
                    araba1.Image = Properties.Resources.araba8;
                    break;
                default:
                    break;

            }
        }

        private void araba2_degistir()
        {
            //Diğer arabalar ekranda kaybolunca 1-7 arasında rastgele bir değer üretilip 
            //eklenen resimlerin ekrana getirilmesini sağlıyoruz....
            int sira = rnd.Next(1, 7);
            switch (sira)
            {
                case 1:
                    araba2.Image = Properties.Resources.araba2;
                    break;
                case 2:
                    araba2.Image = Properties.Resources.araba3;
                    break;
                case 3:
                    araba2.Image = Properties.Resources.araba4;
                    break;
                case 4:
                    araba2.Image = Properties.Resources.araba5;
                    break;
                case 5:
                    araba2.Image = Properties.Resources.araba6;
                    break;
                case 6:
                    araba2.Image = Properties.Resources.araba7;
                    break;
                case 7:
                    araba2.Image = Properties.Resources.araba8;
                    break;
                default:
                    break;

            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Tuş basma olayında sağa veya sola hareketin kontrolü
            if (e.KeyCode == Keys.Left && bizim_araba.Left > 0) sol_yon = true;

            if (e.KeyCode == Keys.Right && bizim_araba.Left + bizim_araba.Width < panel1.Width) sag_yon = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //Tuş bırakılınca arabanın hareketinin bitmesi
            if (e.KeyCode == Keys.Left) sol_yon = false;
            if (e.KeyCode == Keys.Right) sag_yon = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {   //Butona basınca tekrar oyunu başlatıyoruz....
            basla();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }
    }
}
