using System;

class Penjumlahan
{
    public T JumlahTigaAngka<T>(T a, T b, T c) where T : struct
    {
        dynamic x = a;
        dynamic y = b;
        dynamic z = c;
        return (T)(x + y + z);
    }
}

class Program
{
    static void Main()
    {
        Penjumlahan obj = new Penjumlahan();
        double angka1 = 22.0,
            angka2 = 11.0,
            angka3 = 10.0; // Menggunakan double karena NIM berakhiran 3
        double hasil = obj.JumlahTigaAngka(angka1, angka2, angka3);
        Console.WriteLine("NIM saya yaitu 2211104013");
        Console.WriteLine($"Hasil penjumlahan: {hasil}");
    }
}
