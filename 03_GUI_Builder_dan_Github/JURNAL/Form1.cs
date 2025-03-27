using System;
using System.Windows.Forms;

namespace jurnal_modul3
{
    public partial class Form1 : Form
    {
        private string input = "";   // Menyimpan angka yang sedang diketik
        private double firstNumber = 0; // Menyimpan angka pertama
        private double secondNumber = 0; // Menyimpan angka kedua
        private double result = 0;   // Menyimpan hasil perhitungan
        private bool isNewInput = true;
        private bool isAdding = false;

        public Form1()
        {
            InitializeComponent();
        }

        // Event handler untuk tombol angka
        private void Number_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (isNewInput)
            {
                input = button.Text;
                isNewInput = false;
            }
            else
            {
                input += button.Text;
            }
            label1.Text = input;
        }

        // Event handler untuk tombol +
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (double.TryParse(input, out firstNumber))
            {
                input = "";
                isNewInput = true;
                isAdding = true;
            }
        }

        // Event handler untuk tombol =
        private void ButtonEquals_Click(object sender, EventArgs e)
        {
            if (double.TryParse(input, out secondNumber))
            {
                if (isAdding)
                {
                    result = firstNumber + secondNumber;
                    label1.Text = $"{firstNumber} + {secondNumber} = {result}";
                    isAdding = false;
                }
                else
                {
                    label1.Text = input; // Jika tidak ada operasi, tetap tampilkan angka terakhir
                }

                input = "";
                isNewInput = true;
            }
        }

        // Event untuk tombol angka (0-9)
        private void button1_Click(object sender, EventArgs e) { Number_Click(sender, e); }
        private void button2_Click(object sender, EventArgs e) { Number_Click(sender, e); }
        private void button3_Click(object sender, EventArgs e) { Number_Click(sender, e); }
        private void button4_Click(object sender, EventArgs e) { Number_Click(sender, e); }
        private void button5_Click(object sender, EventArgs e) { Number_Click(sender, e); }
        private void button6_Click(object sender, EventArgs e) { Number_Click(sender, e); }
        private void button7_Click(object sender, EventArgs e) { Number_Click(sender, e); }
        private void button8_Click(object sender, EventArgs e) { Number_Click(sender, e); }
        private void button9_Click(object sender, EventArgs e) { Number_Click(sender, e); }
        private void button10_Click(object sender, EventArgs e) { Number_Click(sender, e); }

        // Event untuk tombol operasi
        private void button11_Click(object sender, EventArgs e) { ButtonAdd_Click(sender, e); } // +
        private void button12_Click(object sender, EventArgs e) { ButtonEquals_Click(sender, e); } // =

        private void Form1_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}
