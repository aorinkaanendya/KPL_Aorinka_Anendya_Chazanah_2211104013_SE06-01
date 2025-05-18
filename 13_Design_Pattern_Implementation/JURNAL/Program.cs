public class Program
{
    public static void Main(string[] args)
    {
        // A. Buat dua variable dengan tipe PusatDataSingleton
        PusatDataSingleton data1 = PusatDataSingleton.GetDataSingleton();
        PusatDataSingleton data2 = PusatDataSingleton.GetDataSingleton();

        // B. Tambah data pada data1
        data1.AddSebuahData("Fadhila Agil Permana");
        data1.AddSebuahData("Aorinka Anendya Chazanah");
        data1.AddSebuahData("Muhammad Abdul Aziz");
        data1.AddSebuahData("Muhammad Luthfi Hamdani");
        data1.AddSebuahData("Asisten Praktikum: Kak Imedla & Naufal");

        // C. Print semua data dari data2
        Console.WriteLine("Data dari data2 sebelum dihapus:");
        data2.PrintSemuaData();

        // D. Hapus data asisten praktikum (index ke-2)
        data2.HapusSebuahData(2);

        // E. Print data lagi dari data1
        Console.WriteLine("\nData dari data1 setelah penghapusan:");
        data1.PrintSemuaData();

        // F. Print jumlah elemen di data1 dan data2
        Console.WriteLine($"\nJumlah data di data1: {data1.GetSemuaData().Count}");
        Console.WriteLine($"Jumlah data di data2: {data2.GetSemuaData().Count}");
    }
}
