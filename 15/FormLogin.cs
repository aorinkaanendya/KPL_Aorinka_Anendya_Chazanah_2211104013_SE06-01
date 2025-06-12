using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace modul15_NIM
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string hashedPassword = HashPassword(password);

            string path = "users.json";
            if (!File.Exists(path))
            {
                lblOutput.Text = "Data user belum ada!";
                return;
            }

            string json = File.ReadAllText(path);
            UserList list = JsonConvert.DeserializeObject<UserList>(json);

            foreach (User user in list.Users)
            {
                if (user.Username == username && user.Password == hashedPassword)
                {
                    lblOutput.Text = "Login Berhasil!";
                    return;
                }
            }

            lblOutput.Text = "Username atau Password salah!";
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
