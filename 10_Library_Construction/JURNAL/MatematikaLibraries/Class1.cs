using System;
using System.Text;

namespace MathLibrary
{
    public class MatematikaLibraries
    {
        // A. Mencari Faktor Persekutuan Terbesar
        public static int FPB(int input1, int input2)
        {
            while (input2 != 0)
            {
                int temp = input2;
                input2 = input1 % input2;
                input1 = temp;
            }
            return input1;
        }

        // B. Mencari Kelipatan Persekutuan Terkecil
        public static int KPK(int input1, int input2)
        {
            return (input1 * input2) / FPB(input1, input2);
        }

        // C. Mendapatkan hasil turunan dari persamaan sederhana
        public static string Turunan(int[] persamaan)
        {
            StringBuilder result = new StringBuilder();
            int degree = persamaan.Length - 1;

            for (int i = 0; i < persamaan.Length - 1; i++)
            {
                int coef = persamaan[i] * (degree - i);
                if (coef == 0) continue;

                if (result.Length > 0)
                    result.Append(coef > 0 ? " + " : " - ");
                else if (coef < 0)
                    result.Append("-");

                coef = Math.Abs(coef);
                int power = degree - i - 1;

                if (power == 0)
                    result.Append(coef);
                else if (power == 1)
                    result.Append($"{coef}x");
                else
                    result.Append($"{coef}x{power}");
            }

            return result.ToString();
        }

        // D. Mendapatkan hasil integral dari persamaan sederhana
        public static string Integral(int[] persamaan)
        {
            StringBuilder result = new StringBuilder();
            int degree = persamaan.Length;

            for (int i = 0; i < persamaan.Length; i++)
            {
                double coef = (double)persamaan[i] / (degree - i);
                if (coef == 0) continue;

                if (result.Length > 0)
                    result.Append(coef > 0 ? " + " : " - ");
                else if (coef < 0)
                    result.Append("-");

                coef = Math.Abs(coef);
                int power = degree - i;

                if (coef == 1)
                    result.Append($"x{power}");
                else
                    result.Append($"{coef}x{power}");
            }

            result.Append(" + C");
            return result.ToString();
        }
    }
}
