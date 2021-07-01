using QuanLySoTietKiem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLySoTietKiem.ViewModel
{
    class UserViewModel : BaseViewModel

    {
        private ObservableCollection<NGUOIDUNG> _List;
        public ObservableCollection<NGUOIDUNG> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private ObservableCollection<NHOMNGUOIDUNG> _GroupList;
        public ObservableCollection<NHOMNGUOIDUNG> GroupList { get => _GroupList; set { _GroupList = value; OnPropertyChanged(); } }
        private NHOMNGUOIDUNG _SelectedGroup;
        public NHOMNGUOIDUNG SelectedGroup { get => _SelectedGroup; set { _SelectedGroup = value; OnPropertyChanged(); } }
        private NGUOIDUNG _SelectedItem;
        public NGUOIDUNG SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                OnPropertyChanged();
            }
        }

        private string _TenDangNhap;
        public string TenDangNhap { get => _TenDangNhap; set { _TenDangNhap = value; OnPropertyChanged(); } }
        private string _TenThat;
        public string TenThat { get => _TenThat; set { _TenThat = value; OnPropertyChanged(); } }
        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        public ICommand AddFormCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand EditFormCommand { get; set; }
        public ICommand SaveAddCommand { get; set; }
        public ICommand SaveEditCommand { get; set; }
        public ICommand DisableCommand { get; set; }
        public ICommand ResetPassCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public UserViewModel()
        {
            List = new ObservableCollection<NGUOIDUNG>(DataProvider.Ins.DB.NGUOIDUNGs);
            GroupList = new ObservableCollection<NHOMNGUOIDUNG>(DataProvider.Ins.DB.NHOMNGUOIDUNGs);
            AddFormCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ResetField();
                SelectedItem = null;
                AddUser add = new AddUser();
                add.ShowDialog();
            });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                if (p.Password != null) Password = p.Password;
            });
            DisableCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (SelectedItem != null)
                {
                    var result = MessageBox.Show("Bạn có muốn xóa tài khoản này không?", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (result == MessageBoxResult.Yes)
                    {
                        var user = DataProvider.Ins.DB.NGUOIDUNGs.Where(x => x.TenDangNhap == SelectedItem.TenDangNhap).SingleOrDefault();
                        DataProvider.Ins.DB.NGUOIDUNGs.Remove(user);
                        DataProvider.Ins.DB.SaveChanges();
                        List.Remove(user);
                        MessageBox.Show("Xóa người dùng thành công!");
                        p.Close();
                    }
                }
            });
            ExitCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Close();
            });
            EditFormCommand = new RelayCommand<object>((p) => { return (SelectedItem != null); }, (p) =>
            {

                if (SelectedItem != null)
                {
                    SelectedGroup = SelectedItem.NHOMNGUOIDUNG;
                    TenThat = SelectedItem.TenThat;
                }
                EditUser edit = new EditUser();
                edit.ShowDialog();
            });
            SaveAddCommand = new RelayCommand<object>(
                (p) =>
                {
                    return isValidatedAdd();
                },
                (p) =>
                {
                    if (!CheckValidUsername(TenDangNhap))
                    {
                        MessageBox.Show("Tên đăng nhập đã tồn tại!");
                        return;
                    }
                    var user = new NGUOIDUNG() { MaNhom = SelectedGroup.MaNhom, NHOMNGUOIDUNG = SelectedGroup, MatKhau = ComputeSha256Hash(Password), TenDangNhap = TenDangNhap, TenThat = TenThat };
                    DataProvider.Ins.DB.NGUOIDUNGs.Add(user);
                    DataProvider.Ins.DB.SaveChanges();
                    List.Add(user);
                    MessageBox.Show("Thêm thành công!");
                    ResetField();
                });
                SaveEditCommand = new RelayCommand<object>(
                (p) =>
                {
                    return isValidatedEdit();
                },
                (p) =>
                {
                    var user = DataProvider.Ins.DB.NGUOIDUNGs.Where(x => x.TenDangNhap == SelectedItem.TenDangNhap).SingleOrDefault();
                    user.NHOMNGUOIDUNG = SelectedGroup;
                    user.TenThat = TenThat;
                    DataProvider.Ins.DB.SaveChanges();
                    for (int i = 0; i < List.Count; i++)
                    {
                        if (SelectedItem.TenDangNhap == List[i].TenDangNhap)
                        {
                            List[i] = new NGUOIDUNG { TenDangNhap = List[i].TenDangNhap, TenThat = List[i].TenThat, NHOMNGUOIDUNG = List[i].NHOMNGUOIDUNG, MaNhom = List[i].MaNhom, MatKhau = List[i].MatKhau};
                            break;
                        }
                    }
                    MessageBox.Show("Cập nhật thành công!");
                    (p as Window).Close();
                });
            ResetPassCommand = new RelayCommand<object>(
              (p) =>
              {
                  return CheckUserName();
              },
              (p) =>
              {
                  var user = DataProvider.Ins.DB.NGUOIDUNGs.Where(x => x.TenDangNhap == SelectedItem.TenDangNhap).SingleOrDefault();
                  user.MatKhau = ComputeSha256Hash("1");
                  DataProvider.Ins.DB.SaveChanges();
                 
                  MessageBox.Show("Cập nhật thành công, mật khẩu mới là: 1");
                  (p as Window).Close();
              });
        }
        private bool isValidatedAdd()
        {
            if (SelectedGroup == null || String.IsNullOrEmpty(TenThat) || String.IsNullOrEmpty(TenDangNhap) || String.IsNullOrEmpty(Password)) return false;
            return true;
        }
        private bool CheckUserName()
        {
            if (SelectedItem == null) return false;
            return true;
        }
        private bool isValidatedEdit()
        {
            if (SelectedItem == null) return false;
            if (String.IsNullOrEmpty(TenThat) || SelectedGroup == null) return false;
            if (SelectedItem.TenThat == TenThat && SelectedItem.NHOMNGUOIDUNG == SelectedGroup) return false;
            return true;
        }
        private bool CheckValidUsername(string u)
        {
            var nguoidung = DataProvider.Ins.DB.NGUOIDUNGs.Where(x => x.TenDangNhap == u).Count();
            if (nguoidung > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void ResetField()
        {

            SelectedGroup = null;
            TenThat = "";
            Password = "";
            TenDangNhap = "";
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
