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

class SimpleDataBase<T>
{
    private List<T> storedData;
    private List<DateTime> inputDates;

    public SimpleDataBase()
    {
        storedData = new List<T>();
        inputDates = new List<DateTime>();
    }

    public void AddNewData(T data)
    {
        storedData.Add(data);
        inputDates.Add(DateTime.UtcNow);
    }

    public void PrintAllData()
    {
        for (int i = 0; i < storedData.Count; i++)
        {
            Console.WriteLine($"Data {i + 1} berisi: {storedData[i]}, yang disimpan pada waktu UTC: {inputDates[i]}");
        }
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

        Console.WriteLine();

        SimpleDataBase<int> database = new SimpleDataBase<int>();

        // Menambahkan tiga data berdasarkan dua digit dari NIM (22, 11, 40)
        database.AddNewData(22);
        database.AddNewData(11);
        database.AddNewData(40);

        // Memanggil PrintAllData() untuk menampilkan data yang disimpan
        database.PrintAllData();
    }
}
