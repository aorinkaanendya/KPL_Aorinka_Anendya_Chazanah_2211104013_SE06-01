using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace jurnal_modul7
{
    class TeamMembers2211104013
    {
        public class Member
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }
            public string NIM { get; set; }
        }

        public class Team
        {
            public List<Member> Members { get; set; }
        }

        public static void ReadJSON()
        {
            string filePath = "jurnal7_2_2211104013.json";
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                Team team = JsonConvert.DeserializeObject<Team>(jsonContent);

                Console.WriteLine("Team member list:");
                foreach (var member in team.Members)
                {
                    Console.WriteLine($"{member.NIM} {member.FirstName} {member.LastName} ({member.Age} {member.Gender})");
                }
            }
            else
            {
                Console.WriteLine("File JSON tidak ditemukan.");
            }
        }
    }
}
