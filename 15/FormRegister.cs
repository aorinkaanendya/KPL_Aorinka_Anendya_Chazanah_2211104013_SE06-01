using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Drawing;

namespace modul15_NIM
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
            BuildCustomDesign();
        }

        private void BuildCustomDesign()
        {
            // Form Setting
            this.Text = "Registrasi User";
            this.BackColor = Color.LightGray;
            this.Size = new Size(400, 350);

            // Panel Utama
            Panel panel = new Panel();
            panel.Size = new Size(320, 250);
            panel.Location = new Point(35, 30);
            panel.BackColor = Color.White;
            panel.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(panel);

            // Label Username
            Label lblUsername = new Label();
            lblUsername.Text = "Masukkan Username";
            lblUsername.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblUsername.Location = new Point(20, 20);
            lblUsername.AutoSize = true;
            panel.Controls.Add(lblUsername);

            // TextBox Username
            TextBox txtUsername = new TextBox();
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(260, 25);
            txtUsername.Location = new Point(20, 50);
            panel.Controls.Add(txtUsername);

            // Label Password
            Label lblPassword = new Label();
            lblPassword.Text = "Masukkan Password";
            lblPassword.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblPassword.Location = new Point(20, 90);
            lblPassword.AutoSize = true;
            panel.Controls.Add(lblPassword);

            // TextBox Password
            TextBox txtPassword = new TextBox();
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(260, 25);
            txtPassword.Location = new Point(20, 120);
            txtPassword.PasswordChar = '●';
            panel.Controls.Add(txtPassword);

            // Tombol Registrasi
            Button btnRegister = new Button();
            btnRegister.Text = "Registrasi";
            btnRegister.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnRegister.Size = new Size(260, 40);
            btnRegister.Location = new Point(20, 170);
            btnRegister.BackColor = Color.FromArgb(0, 123, 255);
            btnRegister.ForeColor = Color.White;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Click += (s, e) =>
            {
                Register(txtUsername.Text, txtPassword.Text);
            };
            panel.Controls.Add(btnRegister);
        }

        private void Register(string username, string password)
        {
            // Validasi panjang username & password
            if (username.Length < 8 || username.Length > 20 || password.Length < 8 || password.Length > 20)
            {
                MessageBox.Show("Username/Password harus 8-20 karakter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validasi username hanya huruf dan angka
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Username hanya boleh huruf dan angka.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Password harus mengandung angka dan karakter unik
            if (!Regex.IsMatch(password, @"[0-9]") || !Regex.IsMatch(password, @"[!@#$%^&*]"))
            {
                MessageBox.Show("Password harus mengandung angka dan karakter unik (!@#$%^&*).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Password tidak boleh mengandung username
            if (password.ToLower().Contains(username.ToLower()))
            {
                MessageBox.Show("Password tidak boleh mengandung username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hash password
            string hashedPassword = HashPassword(password);

            // Simpan ke file JSON
            User newUser = new User { Username = username, Password = hashedPassword };
            SaveUser(newUser);

            MessageBox.Show("Registrasi berhasil!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void SaveUser(User user)
        {
            string path = "users.json";
            UserList list = new UserList();

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                list = JsonConvert.DeserializeObject<UserList>(json) ?? new UserList();
            }

            list.Users.Add(user);
            File.WriteAllText(path, JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
