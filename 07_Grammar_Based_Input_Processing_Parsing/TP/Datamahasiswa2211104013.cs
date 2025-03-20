using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpmodul7_2
{
    class DataMahasiswa2211104013
    {
        public string NamaDepan { get; set; }
        public string NamaBelakang { get; set; }
        public string NIM { get; set; }
        public string Fakultas { get; set; }

        public static void ReadJSON()
        {
            string filePath = "tp7_1_2211104013.json";

            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);

                // Parsing JSON ke Object
                var mahasiswa = JsonConvert.DeserializeObject<dynamic>(jsonData);

                string namaDepan = mahasiswa.nama.depan;
                string namaBelakang = mahasiswa.nama.belakang;
                string nim = mahasiswa.nim;
                string fakultas = mahasiswa.fakultas;

                Console.WriteLine($"Nama {namaDepan} {namaBelakang} dengan NIM {nim} dari fakultas {fakultas}");
            }
            else
            {
                Console.WriteLine("File JSON tidak ditemukan! Pastikan file berada di folder project.");
            }
        }
    }
}
