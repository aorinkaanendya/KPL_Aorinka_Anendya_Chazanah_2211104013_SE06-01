namespace tpmodul12_2211104013_aorin
{
    public class BilanganHelper  // <-- tambahkan public
    {
        public static string CariTandaBilangan(int a)
        {
            if (a < 0) return "Negatif";
            if (a > 0) return "Positif";
            return "Nol";
        }
    }
}
