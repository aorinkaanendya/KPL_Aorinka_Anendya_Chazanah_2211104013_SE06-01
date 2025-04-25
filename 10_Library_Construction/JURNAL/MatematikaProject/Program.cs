using System;
using MathLibrary; 

namespace MatematikaConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Program Matematika ===\n");

            // A. FPB
            int fpb = MatematikaLibraries.FPB(60, 45);
            Console.WriteLine($"FPB dari 60 dan 45 adalah: {fpb}");

            // B. KPK
            int kpk = MatematikaLibraries.KPK(12, 8);
            Console.WriteLine($"KPK dari 12 dan 8 adalah: {kpk}");

            // C. Turunan
            int[] persamaan1 = { 1, 4, -12, 9 };
            string turunan = MatematikaLibraries.Turunan(persamaan1);
            Console.WriteLine($"Turunan dari x^3 + 4x^2 - 12x + 9 adalah: {turunan}");

            // D. Integral
            int[] persamaan2 = { 4, 6, -12, 9 };
            string integral = MatematikaLibraries.Integral(persamaan2);
            Console.WriteLine($"Integral dari 4x^3 + 6x^2 - 12x + 9 adalah: {integral}");

            Console.WriteLine("\nProgram selesai. Tekan sembarang tombol untuk keluar...");
            Console.ReadKey();
        }
    }
}
