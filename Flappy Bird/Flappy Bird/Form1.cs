using System;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        // değişkenler
        int obstacleSpeed = 2; // boruların hareket hızı
        int gravity = 0; // kuşun düşme hızı, başlangıçta 0 hareketsiz
        int score = 0; // oyuncunun puanı
        int highScore = 0; // en yüksek skor
        bool gameOver = false; // oyunun bitip bitmediğini kontrol ediyoruz
        bool gameStarted = false; // oyun başladı mı başlamadı mı diye kontrol ediyoruz
        Random rand = new Random(); // rastgele boru yüksekliği üretmek için
        int pipeGap = 150; // üst ve alt boru arasındaki boşluk 

        public Form1()
        {
            InitializeComponent();
            gameTimer.Start(); // oyun zamanlayıcısını başlatıyoruz
            ResetGame(); // oyun başlatılmadan önce her şeyi sıfırlıyoruz
        }

        // zamanlayıcı her tetiklendiğinde bu fonksiyon çalışır, yani oyunun ana döngüsü
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (!gameOver && gameStarted) // oyun başladı ve bitmemişse
            {
                // kuşa yerçekimi ekliyoruz
                birdPlayer.Top += gravity;

                // boruların sola doğru hareket etmesini sağlıyoruz
                obstacleBottom.Left -= obstacleSpeed;
                obstacleTop.Left -= obstacleSpeed;

                // skoru ekrana yansıtıyoruz
                scoreText.Text = score.ToString();

                // eğer borular ekranın dışına çıktıysa, onları yeniden ekrana getiriyoruz
                if (obstacleBottom.Left < -50)
                {
                    // boruların başlangıç noktasına geri gitmesini sağlıyoruz
                    obstacleBottom.Left = 450;
                    obstacleBottom.Height = rand.Next(100, 400 - pipeGap); // alt borunun yüksekliğini rastgele ayarlıyoruz

                    // üst borunun konumunu ve yüksekliğini ayarlıyoruz
                    obstacleTop.Left = 450;
                    obstacleTop.Height = 450 - obstacleBottom.Height - pipeGap; // sabit boşluğa göre yüksekliği ayarlıyorum

                    score++; // bir boruyu geçince skor artıyor

                    // her 5 puanda bir boru hızını artır
                    if (score % 5 == 0)
                    {
                        obstacleSpeed += 2; // boru hızını 2 artırıyoruz
                    }
                }

                // kuşun herhangi bir şeye çarpıp çarpmadığını kontrol ediyoruz
                if (birdPlayer.Bounds.IntersectsWith(obstacleBottom.Bounds) ||
                    birdPlayer.Bounds.IntersectsWith(obstacleTop.Bounds) ||
                    birdPlayer.Bounds.IntersectsWith(ground.Bounds) ||
                    birdPlayer.Top < -25) // ekranın üstüne çıkmasını da önlüyoruz
                {
                    gameOver = true; // oyun bitti
                    gameTimer.Stop(); // zamanlayıcıyı durduruyoruz

                    // en yüksek skoru kontrol edip güncelliyoruz
                    if (score > highScore)
                    {
                        highScore = score;
                    }

                    // en yüksek skoru label2'de gösteriyoruz
                    label2.Text = "" + highScore;

                    MessageBox.Show("Oyun Bitti! Tekrar oynamak için herhangi bir tuşa basın."); // oyun bittiğinde mesaj gösteriyoruz
                }
            }
        }

        // space tuşuna basıldığında bu fonksiyon çalışır
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && !gameOver) // eğer Space tuşuna basılmış ve oyun bitmemişse
            {
                if (!gameStarted)
                {
                    gameStarted = true; // oyun henüz başlamamışsa, başlatıyoruz
                }
                gravity = -4; // kuşu zıplatmak için yer çekimini tersine çeviriyoruz
            }

            if (gameOver)
            {
                ResetGame(); // eğer oyun bittiyse, oyunu sıfırlıyoruz
            }
        }

        // space tuşu bırakıldığında çalışır
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 4; // space tuşu bırakıldığında kuş yeniden düşmeye başlıyor
            }
        }

        // oyunu yeniden başlatmak için kullanılıyor 
        private void ResetGame()
        {
            birdPlayer.Top = 200; // kuşun başlangıç pozisyonuna geri dönüyor
            gravity = 0; // yer çekimi sıfırlanıyor, kuş sabit kalıyor
            score = 0; // skor sıfırlanıyor
            obstacleSpeed = 5; // boru hızı başlangıç değerine geri alınıyor
            gameOver = false; // oyun durumu sıfırlanıyor
            gameStarted = false; // oyun başlangıç durumu sıfırlanıyor
            gameTimer.Start(); // zamanlayıcı yeniden başlatılıyor

            // boruların başlangıç konumlarını ayarlıyoruz (300 olacak şekilde)
            obstacleBottom.Left = 300;
            obstacleTop.Left = 300;

            // alt borunun yüksekliği rastgele ayarlanıyor
            obstacleBottom.Height = rand.Next(100, 450 - pipeGap);

            // üst boru, alt boruya göre ayarlanıyor, arada sabit bir boşluk olacak şekilde
            obstacleTop.Height = 450 - obstacleBottom.Height - pipeGap;
        }

        // form kapatılırken en yüksek skoru sıfırlıyoruz
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            highScore = 0; // en yüksek skor sıfırlanıyor
            label2.Text = "0"; // label'de gösterilen en yüksek skor sıfırlanıyor
        }

        // form yüklendiğinde çalışır
        private void Form1_Load(object sender, EventArgs e)
        {
            ResetGame(); // form yüklendiğinde oyunu sıfırlıyoruz
        }
    }
}
