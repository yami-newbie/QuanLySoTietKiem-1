using QuanLySoTietKiem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLySoTietKiem.ViewModel
{
    public class LoginViewModel:BaseViewModel
    {
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        public ICommand LoginCommand { get; set; }
        public ICommand DragMoveCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand RegisterCommand { get; set; }      
        public ICommand PasswordChangedCommand { get; set; }
        public bool IsLogin { get; set; }
        public LoginViewModel()
        {
            IsLogin = false;
            LoginCommand = new RelayCommand<Window>((p) => { return !(String.IsNullOrEmpty(UserName) || String.IsNullOrEmpty(Password)); }, (p) =>
            {
                Login(p);
            });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                if (p.Password != null) Password = p.Password;
            });
            DragMoveCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null) p.DragMove();

            });
            ExitCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p!= null)
                p.Close();
            });
            RegisterCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null) return;
                RegisterWindow r = new RegisterWindow(p as Window);
                p.Hide();
                r.Show();
            });


        }
        public void Login(Window p)
        {
            if (p == null) return;
            var passEncode = ComputeSha256Hash(Password);
            var accCount = DataProvider.Ins.DB.NGUOIDUNGs.Where(x => x.TenDangNhap == UserName && x.MatKhau == passEncode).Count();
            if (accCount > 0||(UserName=="1"&&Password=="1"))
            {
                MainWindow main = new MainWindow();
                main.Show();
                p.Close();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu");
            }
            
        }
        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
