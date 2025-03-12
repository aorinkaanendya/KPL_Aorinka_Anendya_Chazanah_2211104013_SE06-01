using System;

public class HaloGeneric
{
    public static void SapaUser<T>(T nama)
    {
        Console.WriteLine($"Halo user {nama}");
    }
}


public class DataGeneric<T>
{
    public T Data { get; set; }

    public DataGeneric(T data)
    {
        Data = data;
    }

    public void PrintData()
    {
        Console.WriteLine($"Data yang tersimpan adalah: {Data}");
    }
}

class Program
{
    static void Main()
    {
        HaloGeneric.SapaUser<string>("Aorinka");
        DataGeneric<string> dataNIM = new DataGeneric<string>("2211104013");
        dataNIM.PrintData();
    }
}
