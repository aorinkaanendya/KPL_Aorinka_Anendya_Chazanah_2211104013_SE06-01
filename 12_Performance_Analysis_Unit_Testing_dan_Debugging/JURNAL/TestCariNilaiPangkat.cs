using System;
using Xunit;
using jurnalmodul12_2211104013; // Menggunakan namespace project utama

namespace jurnalmodul12_2211104013.Tests
{
    public class TestCariNilaiPangkat
    {
        private Form1 form;

        public TestCariNilaiPangkat()
        {
            // Inisialisasi form setiap kali tes dijalankan
            form = new Form1();
        }

        [Fact]
        public void Test_B_Pangkat_0()
        {
            // Tes untuk pangkat 0, hasilnya selalu 1
            Assert.Equal(1, form.CariNilaiPangkat(0, 0));
            Assert.Equal(1, form.CariNilaiPangkat(5, 0));
        }

        [Fact]
        public void Test_B_Negatif()
        {
            // Tes untuk b negatif, harus mengembalikan -1
            Assert.Equal(-1, form.CariNilaiPangkat(2, -1));
        }

        [Fact]
        public void Test_B_LebihDari10()
        {
            // Tes untuk b > 10, harus mengembalikan -2
            Assert.Equal(-2, form.CariNilaiPangkat(2, 11));
        }

        [Fact]
        public void Test_A_LebihDari100()
        {
            // Tes untuk a > 100, harus mengembalikan -2
            Assert.Equal(-2, form.CariNilaiPangkat(101, 5));
        }

        [Fact]
        public void Test_Normal()
        {
            // Tes untuk kasus normal, hasil pangkat yang valid
            Assert.Equal(8, form.CariNilaiPangkat(2, 3));
        }

        [Fact]
        public void Test_Overflow()
        {
            // Tes untuk overflow, harus mengembalikan -3
            Assert.Equal(-2, form.CariNilaiPangkat(100000, 5));
        }
    }
}
