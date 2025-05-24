using System;
using System.Collections.Generic;

// Kelas ini merepresentasikan sebuah video dengan properti id, judul, dan jumlah play.
class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    // Konstruktor video. Memastikan judul valid dan memberikan ID acak.
    public SayaTubeVideo(string title)
    {
        if (string.IsNullOrEmpty(title) || title.Length > 200)
            throw new ArgumentException("Judul video tidak boleh null dan maksimal 200 karakter.");

        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    // Method untuk menambah play count video dengan validasi dan pengecekan overflow.
    public void IncreasePlayCount(int count)
    {
        if (count < 0 || count > 25000000)
            throw new ArgumentOutOfRangeException(nameof(count), "Play count tidak boleh negatif dan maksimal 25.000.000.");

        try
        {
            checked
            {
                playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: Terjadi overflow saat menambah play count.");
        }
    }

    // Mengembalikan jumlah play count dari video.
    public int GetPlayCount()
    {
        return playCount;
    }

    // Mengembalikan judul video.
    public string GetTitle()
    {
        return title;
    }

    // Mencetak detail video ke konsol.
    public void PrintVideoDetails()
    {
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Play Count: {playCount}");
    }
}

// Kelas ini merepresentasikan user yang memiliki daftar video yang diunggah.
class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    public string Username { get; private set; }

    // Konstruktor user dengan validasi panjang username dan ID acak.
    public SayaTubeUser(string username)
    {
        if (string.IsNullOrEmpty(username) || username.Length > 100)
            throw new ArgumentException("Username tidak boleh null dan maksimal 100 karakter.");

        Random random = new Random();
        this.id = random.Next(10000, 99999);
        Username = username;
        uploadedVideos = new List<SayaTubeVideo>();
    }

    // Menambahkan objek video ke daftar uploadedVideos.
    public void AddVideo(SayaTubeVideo video)
    {
        if (video == null)
            throw new ArgumentNullException(nameof(video), "Video yang ditambahkan tidak boleh null.");

        if (video.GetPlayCount() >= int.MaxValue)
            throw new ArgumentException("Play count video melebihi batas maksimum integer.");

        uploadedVideos.Add(video);
    }

    // Menghitung total play count dari semua video yang diunggah.
    public int GetTotalVideoPlayCount()
    {
        int total = 0;

        foreach (SayaTubeVideo video in uploadedVideos)
        {
            total += video.GetPlayCount();
        }

        return total;
    }

    // Mencetak maksimal 8 video yang telah diunggah oleh user.
    public void PrintAllVideoPlayCount()
    {
        Console.WriteLine($"User: {Username}");

        int maxPrint = Math.Min(uploadedVideos.Count, 8);
        for (int i = 0; i < maxPrint; i++)
        {
            Console.WriteLine($"Video {i + 1}: {uploadedVideos[i].GetTitle()}");
        }
    }
}

// Kelas utama untuk menjalankan program.
class Program
{
    static void Main()
    {
        try
        {
            // Membuat user baru
            SayaTubeUser user = new SayaTubeUser("Aorinka");

            // Daftar judul film yang akan dimasukkan sebagai video
            string[] movieTitles =
            {
                "Review Film Miracle in Cell oleh Aorinka",
                "Review Film Laskar Pelangi oleh Aorinka",
                "Review Film Dilan 1990 oleh Aorinka",
                "Review Film Keluarga Cemara oleh Aorinka",
                "Review Film Ada Apa Dengan Cinta oleh Aorinka",
                "Review Film Susah Sinyal oleh Aorinka",
                "Review Film Agak Laen oleh Aorinka",
                "Review Film Home Sweet Loan oleh Aorinka",
                "Review Film Dua Hati Biru oleh Aorinka",
                "Review Film 13 Bom di Jakarta oleh Aorinka"
            };

            // Menambahkan video ke dalam akun user
            foreach (string title in movieTitles)
            {
                SayaTubeVideo video = new SayaTubeVideo(title);
                user.AddVideo(video);
            }

            // Menampilkan daftar video milik user
            user.PrintAllVideoPlayCount();

            // Pengujian overflow play count
            SayaTubeVideo testVideo = new SayaTubeVideo("Video Test Overflow");
            for (int i = 0; i < 10; i++)
            {
                testVideo.IncreasePlayCount(25000000);
            }

            // Menampilkan detail video test
            testVideo.PrintVideoDetails();
        }
        catch (Exception ex)
        {
            // Menangani error yang terjadi
            Console.WriteLine($"Terjadi error: {ex.Message}");
        }
    }
}
