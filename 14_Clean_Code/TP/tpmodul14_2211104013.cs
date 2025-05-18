using System;

// Kelas untuk menyapa user secara generik
public class HaloGeneric
{
    public static void SapaUser<T>(T nama)
    {
        Console.WriteLine($"Halo user {nama}");
    }
}

// Kelas generic untuk menyimpan dan mencetak data
public class DataGeneric<T>
{
    public T Data { get; set; }

    // Konstruktor untuk menginisialisasi data
    public DataGeneric(T data)
    {
        Data = data;
    }

    // Method untuk mencetak data yang tersimpan
    public void PrintData()
    {
        Console.WriteLine($"Data yang tersimpan adalah: {Data}");
    }
}

public class Program
{
    public static void Main()
    {
        // Menyapa user
        HaloGeneric.SapaUser<string>("Aorinka");

        // Menyimpan dan mencetak data NIM
        DataGeneric<string> dataNim = new DataGeneric<string>("2211104013");
        dataNim.PrintData();
    }
}
