using System;
using System.Windows.Forms;

namespace XOX
{
    public partial class Form1 : Form
    {
        private bool xTurn = true; // X sırasını belirtir.
        private int moveCount = 0; // Hamle sayısını saymak için.

        public Form1()
        {
            InitializeComponent();
            ResetGame(); // Başlangıçta oyunu sıfırla
        }

        private void ResetGame()
        {
            // Tüm butonları temizle, resetButton hariç
            foreach (Control c in Controls)
            {
                if (c is Button btn && btn.Name != "button10") // resetButton'u hariç tut
                {
                    btn.Text = "";
                    btn.Enabled = true;
                }
            }

            xTurn = true;
            moveCount = 0;
            label_SıraKimde.Text = "Sıra: X";
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            label_SıraKimde.Text = "Sıra: X"; // Oyunun başlangıcında X başlar
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (xTurn)
            {
                btn.Text = "X";
                label_SıraKimde.Text = "Sıra: O";
            }
            else
            {
                btn.Text = "O";
                label_SıraKimde.Text = "Sıra: X";
            }

            btn.Enabled = false; // Tıklanan butonu devre dışı bırak
            xTurn = !xTurn;
            moveCount++;

            CheckForWinner();
        }

        private void CheckForWinner()
        {
            bool winnerFound = false;

            // Kazanan kombinasyonları kontrol et
            if ((button1.Text == button2.Text && button2.Text == button3.Text && button1.Text != "") ||
                (button4.Text == button5.Text && button5.Text == button6.Text && button4.Text != "") ||
                (button7.Text == button8.Text && button8.Text == button9.Text && button7.Text != "") ||
                (button1.Text == button4.Text && button4.Text == button7.Text && button1.Text != "") ||
                (button2.Text == button5.Text && button5.Text == button8.Text && button2.Text != "") ||
                (button3.Text == button6.Text && button6.Text == button9.Text && button3.Text != "") ||
                (button1.Text == button5.Text && button5.Text == button9.Text && button1.Text != "") ||
                (button3.Text == button5.Text && button5.Text == button7.Text && button3.Text != ""))
            {
                winnerFound = true;
            }

            if (winnerFound)
            {
                string winner = xTurn ? "O" : "X"; // Son oynayan kazandı
                MessageBox.Show($"Kazanan: {winner}", "Oyun Bitti");
                
            }
            else if (moveCount == 9)
            {
                MessageBox.Show("Berabere!", "Oyun Bitti");
                
            }
        }

        private void button1_Click(object sender, EventArgs e) => button_Click(sender, e);
        private void button2_Click(object sender, EventArgs e) => button_Click(sender, e);
        private void button3_Click(object sender, EventArgs e) => button_Click(sender, e);
        private void button4_Click(object sender, EventArgs e) => button_Click(sender, e);
        private void button5_Click(object sender, EventArgs e) => button_Click(sender, e);
        private void button6_Click(object sender, EventArgs e) => button_Click(sender, e);
        private void button7_Click(object sender, EventArgs e) => button_Click(sender, e);
        private void button8_Click(object sender, EventArgs e) => button_Click(sender, e);
        private void button9_Click(object sender, EventArgs e) => button_Click(sender, e);

        private void button10_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}
