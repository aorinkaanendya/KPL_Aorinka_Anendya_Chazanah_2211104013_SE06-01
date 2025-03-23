using System;
using System.IO;
using Newtonsoft.Json;

namespace jurnal_modul7
{
    class GlossaryItem2211104013
    {
        public class GlossDef
        {
            public string Para { get; set; }
            public string[] GlossSeeAlso { get; set; }
        }

        public class GlossEntry
        {
            public string ID { get; set; }
            public string SortAs { get; set; }
            public string GlossTerm { get; set; }
            public string Acronym { get; set; }
            public string Abbrev { get; set; }
            public GlossDef GlossDef { get; set; }
            public string GlossSee { get; set; }
        }

        public class GlossList
        {
            public GlossEntry GlossEntry { get; set; }
        }

        public class GlossDiv
        {
            public string Title { get; set; }
            public GlossList GlossList { get; set; }
        }

        public class Glossary
        {
            public string Title { get; set; }
            public GlossDiv GlossDiv { get; set; }
        }

        public class Root
        {
            public Glossary Glossary { get; set; }
        }

        public static void ReadJSON()
        {
            string filePath = "jurnal7_3_2211104013.json";
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                Root glossaryData = JsonConvert.DeserializeObject<Root>(jsonContent);

                GlossEntry entry = glossaryData.Glossary.GlossDiv.GlossList.GlossEntry;

                Console.WriteLine("Glossary Entry Details:");
                Console.WriteLine($"ID: {entry.ID}");
                Console.WriteLine($"GlossTerm: {entry.GlossTerm}");
                Console.WriteLine($"Acronym: {entry.Acronym}");
                Console.WriteLine($"Abbreviation: {entry.Abbrev}");
                Console.WriteLine($"Definition: {entry.GlossDef.Para}");
                Console.WriteLine("GlossSeeAlso: " + string.Join(", ", entry.GlossDef.GlossSeeAlso));
                Console.WriteLine($"GlossSee: {entry.GlossSee}");
            }
            else
            {
                Console.WriteLine("File JSON tidak ditemukan.");
            }
        }
    }
}
