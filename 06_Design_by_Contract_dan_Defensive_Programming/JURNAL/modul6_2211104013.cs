using System;
using System.Collections.Generic;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        Random random = new Random();
        this.id = random.Next(10000, 99999); // 5-digit random ID
        this.title = title;
        this.playCount = 0;
    }

    public void IncreasePlayCount(int count)
    {
        playCount += count;
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
        Console.WriteLine("ID: " + id);
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Play Count: " + playCount);
    }
}

class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    public string Username { get; private set; }

    public SayaTubeUser(string username)
    {
        Random random = new Random();
        this.id = random.Next(10000, 99999); // 5-digit random ID
        this.Username = username;
        this.uploadedVideos = new List<SayaTubeVideo>();
    }

    public void AddVideo(SayaTubeVideo video)
    {
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
        Console.WriteLine("User: " + Username);
        for (int i = 0; i < uploadedVideos.Count; i++)
        {
            Console.WriteLine("Video " + (i + 1) + " judul: " + uploadedVideos[i].GetTitle());
        }
    }
}

class Program
{
    static void Main()
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
    }
}