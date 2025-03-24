using System;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

class CovidConfig
{
    private const string ConfigFile = "covid_config.json";

    public string SatuanSuhu { get; set; } = "celcius";
    public int BatasHariDeman { get; set; } = 14;
    public string PesanDitolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
    public string PesanDiterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

    public CovidConfig()
    {
        LoadConfig();
    }

    private void LoadConfig()
    {
        if (File.Exists(ConfigFile))
        {
            string json = File.ReadAllText(ConfigFile);
            var config = JsonConvert.DeserializeObject<CovidConfig>(json);
            if (config != null)
            {
                SatuanSuhu = config.SatuanSuhu;
                BatasHariDeman = config.BatasHariDeman;
                PesanDitolak = config.PesanDitolak;
                PesanDiterima = config.PesanDiterima;
            }
        }
        else
        {
            SaveConfig();
        }
    }

    public void SaveConfig()
    {
        string json = JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(ConfigFile, json);
    }


    public void UbahSatuan()
    {
        SatuanSuhu = SatuanSuhu == "celcius" ? "fahrenheit" : "celcius";
        SaveConfig();
    }
}
