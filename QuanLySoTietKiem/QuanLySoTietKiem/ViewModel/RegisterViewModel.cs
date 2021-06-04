using QuanLySoTietKiem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLySoTietKiem.ViewModel
{
    public class RegisterViewModel:BaseViewModel
    {
        private LoginWindow _loginWindow;
        public LoginWindow LoginWindow { get => _loginWindow; set { _loginWindow = value; OnPropertyChanged(); } }
        private string _tenDangNhap;
        public string TenDangNhap { get => _tenDangNhap; set { _tenDangNhap = value; OnPropertyChanged(); } }
        private string _matKhau;
        public string MatKhau { get => _matKhau; set { _matKhau = value; OnPropertyChanged(); } }
        public ICommand SignInCommand { get; set; }
        public ICommand DragMoveCommand { get; set; }
        public ICommand Login { get; set; }
        public RegisterViewModel()
        {
            SignInCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Close();
                LoginWindow.Show();
            });
            DragMoveCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null) p.DragMove();

            });
            Login = new RelayCommand<Window>((p) => { return !(String.IsNullOrEmpty(TenDangNhap) || String.IsNullOrEmpty(MatKhau)); }, (p) =>
            {
                if(checkEmail(TenDangNhap))
                {
                    var passChanged = ComputeSha256Hash(MatKhau);
                    var _nguoiDung = new NGUOIDUNG { TenDangNhap = TenDangNhap, MatKhau = passChanged };
                    DataProvider.Ins.DB.NGUOIDUNGs.Add(_nguoiDung);
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Đăng ký tài khoản thành công");
                    p.Close();
                    LoginWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập tồn tại");
                }
              
            });

        }
        private bool checkEmail(string email)
        {
            var nguoidung = DataProvider.Ins.DB.NGUOIDUNGs.Where(x => x.TenDangNhap == TenDangNhap).Count();
            if (nguoidung > 0)
            {
                return false;
            }
            else
            {
                return true;
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
