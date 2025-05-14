using System;
using System.Windows.Forms;

namespace jurnalmodul12_2211104013
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnHitung_Click(object sender, EventArgs e)
        {
            int a, b;
            if (int.TryParse(txtA.Text, out a) && int.TryParse(txtB.Text, out b))
            {
                int hasil = CariNilaiPangkat(a, b);
                lblOutput.Text = "Hasil: " + hasil.ToString();
            }
            else
            {
                lblOutput.Text = "Input tidak valid!";
            }
        }

        public int CariNilaiPangkat(int a, int b)
        {
            // Kasus jika b adalah 0, hasilnya selalu 1
            if (b == 0) return 1;

            // Kasus jika b negatif
            if (b < 0) return -1;

            // Kasus jika a > 100 atau b > 10, kembalikan -2
            if (a > 100 || b > 10)
            {
                return -2;
            }

            // Variabel untuk menyimpan hasil
            long result = 1;

            // Menggunakan iterasi untuk menghitung pangkat
            try
            {
                for (int i = 0; i < b; i++)
                {
                    checked
                    {
                        result *= a;
                    }

                    // Cek overflow secara manual pada tiap langkah
                    if (result > int.MaxValue || result < int.MinValue)
                    {
                        return -2; // Overflow terjadi
                    }
                }
            }
            catch (OverflowException)
            {
                return -2; // Mengembalikan -2 jika overflow
            }

            return (int)result; // Mengembalikan hasil setelah overflow dicegah
        }
    }
}
