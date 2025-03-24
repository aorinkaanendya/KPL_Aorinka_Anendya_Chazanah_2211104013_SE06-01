using System;

class Program
{
    static void Main()
    {
        CovidConfig config = new CovidConfig();
        Console.WriteLine($"Satuan suhu saat ini: {config.SatuanSuhu}");
        Console.Write("Berapa suhu badan anda saat ini? Dalam nilai " + config.SatuanSuhu + ": ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman? ");
        int hariDeman = Convert.ToInt32(Console.ReadLine());

        bool suhuValid = (config.SatuanSuhu == "celcius" && suhu >= 36.5 && suhu <= 37.5) ||
                         (config.SatuanSuhu == "fahrenheit" && suhu >= 97.7 && suhu <= 99.5);
        bool hariValid = hariDeman < config.BatasHariDeman;

        Console.WriteLine(suhuValid && hariValid ? config.PesanDiterima : config.PesanDitolak);

        Console.Write("Apakah Anda ingin mengubah satuan suhu? (y/n): ");
        if (Console.ReadLine().ToLower() == "y")
        {
            config.UbahSatuan();
            Console.WriteLine("Satuan suhu telah diubah menjadi: " + config.SatuanSuhu);
        }
    }
}
