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
        private string _matKhaucu;
        public string MatKhauCu { get => _matKhaucu; set { _matKhaucu = value; OnPropertyChanged(); } }
        private string _matKhaumoi;
        public string MatKhauMoi { get => _matKhaumoi; set { _matKhaumoi = value; OnPropertyChanged(); } }
        public ICommand SignInCommand { get; set; }
        public ICommand DragMoveCommand { get; set; }
        public ICommand DoiMatKhau { get; set; }
        public RegisterViewModel()
        {
            SignInCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                ResetAll();
                p.Close();
                LoginWindow.Show();
            });
            DragMoveCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null) p.DragMove();

            });
            DoiMatKhau = new RelayCommand<Window>((p) => { return !(String.IsNullOrEmpty(TenDangNhap) || String.IsNullOrEmpty(MatKhauMoi)|| String.IsNullOrEmpty(MatKhauCu)); }, (p) =>
            {
                if(checkEmailvsMatKhau(TenDangNhap,MatKhauCu))
                {
                    var nguoi=DataProvider.Ins.DB.NGUOIDUNGs.Where(x => x.TenDangNhap == TenDangNhap).SingleOrDefault();
                    nguoi.MatKhau = ComputeSha256Hash(MatKhauMoi);
                    DataProvider.Ins.DB.SaveChanges();
                    MessageBox.Show("Cập nhật tài khoản thành công");
                    ResetAll();
                    p.Close();
                    LoginWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập,mật khẩu sai hoặc không tồn tại");
                }
              
            });

        }
        private void ResetAll()
        {
            TenDangNhap = "";
            MatKhauCu = "";
            MatKhauMoi = "";
        }
        private bool checkEmailvsMatKhau(string email,string matkhaucu)
        {
            matkhaucu = ComputeSha256Hash(matkhaucu);
            var nguoidung = DataProvider.Ins.DB.NGUOIDUNGs.Where(x => x.TenDangNhap == TenDangNhap&&x.MatKhau==matkhaucu).Count();
            if (nguoidung > 0)
            {
                return true;
            }
            else
            {
                return false;
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
