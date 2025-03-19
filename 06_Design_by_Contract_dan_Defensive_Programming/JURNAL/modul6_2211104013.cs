using System;
using System.Collections.Generic;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (string.IsNullOrEmpty(title) || title.Length > 200)
            throw new ArgumentException("Judul video tidak boleh null dan maksimal 200 karakter.");

        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0 || count > 25000000)
            throw new ArgumentOutOfRangeException("Play count tidak boleh negatif dan maksimal 25.000.000.");

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

    public int GetPlayCount()
    {
        return playCount;
    }

    public string GetTitle()
    {
        return title;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Play Count: {playCount}");
    }
}

class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    public string Username { get; private set; }

    public SayaTubeUser(string username)
    {
        if (string.IsNullOrEmpty(username) || username.Length > 100)
            throw new ArgumentException("Username tidak boleh null dan maksimal 100 karakter.");

        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.Username = username;
        this.uploadedVideos = new List<SayaTubeVideo>();
    }

    public void AddVideo(SayaTubeVideo video)
    {
        if (video == null)
            throw new ArgumentNullException("Video yang ditambahkan tidak boleh null.");

        if (video.GetPlayCount() >= int.MaxValue)
            throw new ArgumentException("Play count video melebihi batas maksimum integer.");

        uploadedVideos.Add(video);
    }

    public int GetTotalVideoPlayCount()
    {
        int total = 0;
        foreach (var video in uploadedVideos)
        {
            total += video.GetPlayCount();
        }
        return total;
    }

    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine($"User: {Username}");
        int maxPrint = Math.Min(uploadedVideos.Count, 8); // Maksimal print 8 video
        for (int i = 0; i < maxPrint; i++)
        {
            Console.WriteLine($"Video {i + 1}: {uploadedVideos[i].GetTitle()}");
        }
    }
}

class Program
{
    static void Main()
    {
        try
        {
            SayaTubeUser user = new SayaTubeUser("Aorinka");

            string[] movieTitles = {
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

            foreach (var title in movieTitles)
            {
                SayaTubeVideo video = new SayaTubeVideo(title);
                user.AddVideo(video);
            }

            user.PrintAllVideoPlaycount();

            // Uji exception dengan loop untuk memicu overflow
            SayaTubeVideo testVideo = new SayaTubeVideo("Video Test Overflow");
            for (int i = 0; i < 10; i++) // 10 kali untuk mempercepat overflow
            {
                testVideo.IncreasePlayCount(25000000);
            }

            testVideo.PrintVideoDetails();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Terjadi error: {ex.Message}");
        }
    }
}
