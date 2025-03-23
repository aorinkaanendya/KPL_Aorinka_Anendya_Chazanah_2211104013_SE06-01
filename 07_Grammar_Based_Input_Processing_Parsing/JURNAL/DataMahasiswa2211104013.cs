using System;
using System.IO;
using Newtonsoft.Json;

namespace jurnal_modul7
{
    class DataMahasiswa2211104013
    {
        public class Address
        {
            public string StreetAddress { get; set; }
            public string City { get; set; }
            public string State { get; set; }
        }

        public class Course
        {
            public string Code { get; set; }
            public string Name { get; set; }
        }

        public class Mahasiswa
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public Address Address { get; set; }
            public Course[] Courses { get; set; }
        }

        public static void ReadJSON()
        {
            string filePath = "jurnal7_1_2211104013.json";
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                Mahasiswa mahasiswa = JsonConvert.DeserializeObject<Mahasiswa>(jsonContent);

                Console.WriteLine("Mahasiswa Details:");
                Console.WriteLine($"Name: {mahasiswa.FirstName} {mahasiswa.LastName}");
                Console.WriteLine($"Gender: {mahasiswa.Gender}");
                Console.WriteLine($"Age: {mahasiswa.Age}");
                Console.WriteLine($"Address: {mahasiswa.Address.StreetAddress}, {mahasiswa.Address.City}, {mahasiswa.Address.State}");
                Console.WriteLine("Courses:");
                foreach (var course in mahasiswa.Courses)
                {
                    Console.WriteLine($" - {course.Code}: {course.Name}");
                }
            }
            else
            {
                Console.WriteLine("File JSON tidak ditemukan.");
            }
        }
    }
}
