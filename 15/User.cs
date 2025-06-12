using System.Collections.Generic;

namespace modul15_NIM
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserList
    {
        public List<User> Users { get; set; } = new List<User>();
    }
}
