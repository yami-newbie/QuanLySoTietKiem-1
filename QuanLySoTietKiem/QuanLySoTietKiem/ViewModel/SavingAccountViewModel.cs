using QuanLySoTietKiem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLySoTietKiem.ViewModel
{
    public class SavingAccountViewModel : BaseViewModel
    {
        private ObservableCollection<SOTIETKIEM> _List;
        public ObservableCollection<SOTIETKIEM> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private ObservableCollection<LOAITIETKIEM> _LoaiTietKiem;
        public ObservableCollection<LOAITIETKIEM> LoaiTietKiem { get => _LoaiTietKiem; set { _LoaiTietKiem = value; OnPropertyChanged(); } }
        private LOAITIETKIEM _SelectedLoai;
        public LOAITIETKIEM SelectedLoai { get => _SelectedLoai; set { _SelectedLoai = value; OnPropertyChanged(); } }
        private SOTIETKIEM _SelectedItem;
        public SOTIETKIEM SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }
        private string _TenKhachHang;
        public string TenKhachHang { get => _TenKhachHang; set { _TenKhachHang = value; OnPropertyChanged(); } }
        private string _DiaChi;
        public string DiaChi { get => _DiaChi; set { _DiaChi = value; OnPropertyChanged(); } }
        private string _SoTienGoi;
        public string SoTienGoi { get => _SoTienGoi; set { _SoTienGoi = value; OnPropertyChanged(); } }
        private string _CMND;
        public string CMND { get => _CMND; set { _CMND = value; OnPropertyChanged(); } }
        public ICommand AddFormCommand { get; set; }
        public ICommand EditFormCommand { get; set; }
        public ICommand RestoreFormCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand SaveAddCommand { get; set; }
        public ICommand SaveEditCommand { get; set; }
        public SavingAccountViewModel()
        {
            List = new ObservableCollection<SOTIETKIEM>(DataProvider.Ins.DB.SOTIETKIEMs.Where(x => x.BiXoa == false));
            LoaiTietKiem = new ObservableCollection<LOAITIETKIEM>(DataProvider.Ins.DB.LOAITIETKIEMs);
            AddFormCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                AddSavingAccountView add = new AddSavingAccountView();
                add.ShowDialog();
            });
            EditFormCommand = new RelayCommand<object>((p) => { return (SelectedItem != null); }, (p) =>
            {
                EditSavingAccountView edit = new EditSavingAccountView();
                edit.ShowDialog();
            });
            RestoreFormCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RestoreSavingAccountView restore = new RestoreSavingAccountView();
                restore.ShowDialog();
            });
            ExitCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Close();
            });
            DeleteCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (SelectedItem == null) return false;
                    return ( SelectedItem.SoTienGoi <= 0); 
                },
                (p) =>
                {
                    var result = MessageBox.Show("Bạn có muốn xóa sổ tiết kiệm này không?", "Xóa", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (result == MessageBoxResult.Yes)
                    {
                        var stk = DataProvider.Ins.DB.SOTIETKIEMs.Where(x => x.MaSo == SelectedItem.MaSo).SingleOrDefault();
                        stk.BiXoa = true;
                        DataProvider.Ins.DB.SaveChanges();
                        List.Remove(SelectedItem);
                        SelectedItem = null;
                    }
                });
            SaveAddCommand = new RelayCommand<object>(
                (p) =>
                {
                   return !(String.IsNullOrEmpty(DiaChi) || String.IsNullOrEmpty(CMND) || String.IsNullOrEmpty(TenKhachHang) || String.IsNullOrEmpty(SoTienGoi) || SelectedLoai == null);
                }, 
                (p) =>
                {
                    AddSavingAccount();
                    
                });
            SaveEditCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                
            });
        }
        private void ResetField()
        {
            SelectedLoai = null;
            CMND = "";
            TenKhachHang = "";
            SoTienGoi = "";
            DiaChi = "";
        }
        private void AddSavingAccount()
        {
            bool isIntSoTienGoi = int.TryParse(SoTienGoi, out int soTienGoi);
            if (!isIntSoTienGoi) 
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng tiền!");
                return; 
            }
            var kh = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.CMND == CMND).SingleOrDefault();
            if (soTienGoi < 1000000)
            {
                MessageBox.Show("số tiền gởi ban đầu chưa đạt mức tối thiểu !");
                return;
            }
            if (kh != null)
            {
                if(kh.TenKhachHang != TenKhachHang)
                {
                    MessageBox.Show("Thông tin khách hàng tồn tại nhưng không chính xác!");
                    return;
                }
            }
            else
            {
                kh = new KHACHHANG { BiXoa = false, CMND = CMND, DiaChi = DiaChi, TenKhachHang = TenKhachHang };
                DataProvider.Ins.DB.KHACHHANGs.Add(kh);
                DataProvider.Ins.DB.SaveChanges();
            }
            var SOTIETKIEM = new SOTIETKIEM { NgayMoSo = DateTime.Now, LOAITIETKIEM = SelectedLoai, BiXoa = false, SoTienGoi = soTienGoi, KHACHHANG = kh };
            DataProvider.Ins.DB.SOTIETKIEMs.Add(SOTIETKIEM);
            DataProvider.Ins.DB.SaveChanges();
            List.Add(SOTIETKIEM);
            ResetField();
            MessageBox.Show("Mở sổ tiết kiệm thành công!");
        }
    }
}
