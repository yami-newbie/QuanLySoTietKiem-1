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
    class CustomerViewModel : BaseViewModel
    {
        private ObservableCollection<KHACHHANG> _List;
        public ObservableCollection<KHACHHANG> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private ObservableCollection<KHACHHANG> _Init;
        public ObservableCollection<KHACHHANG> Init { get => _Init; set { _Init = value; OnPropertyChanged(); } }

        private String[] _FilterList;
        public String[] FilterList { get => _FilterList; set { _FilterList = value; OnPropertyChanged(); } }
        private string _Query;
        public string Query { get => _Query; set { _Query = value; OnPropertyChanged(); } }
        private string _SelectedFilter;
        public string SelectedFilter { get => _SelectedFilter; set { _SelectedFilter = value; OnPropertyChanged(); } }

        private KHACHHANG _SelectedItem;
        public KHACHHANG SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }
        private string _TenKhachHang;
        public string TenKhachHang { get => _TenKhachHang; set { _TenKhachHang = value; OnPropertyChanged(); } }
        private string _DiaChi;
        public string DiaChi { get => _DiaChi; set { _DiaChi = value; OnPropertyChanged(); } }
        private string _CMND;
        public string CMND { get => _CMND; set { _CMND = value; OnPropertyChanged(); } }
        public ICommand AddFormCommand { get; set; }
        public ICommand EditFormCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand SaveAddCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand SaveEditCommand { get; set; }
      
        public CustomerViewModel()
        {
            FilterList = new String[] { "Tên khách hàng", "Số CMND" };
            Init = new ObservableCollection<KHACHHANG>(DataProvider.Ins.DB.KHACHHANGs.Where(x => x.BiXoa != true));
            List = Init;
            AddFormCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ResetField();
                SelectedItem = null;
                AddCustomer add = new AddCustomer();
                add.ShowDialog();
            });

            EditFormCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (SelectedItem != null)
                {
                    TenKhachHang = SelectedItem.TenKhachHang;
                    CMND = SelectedItem.CMND;
                    DiaChi = SelectedItem.DiaChi;
                }
                EditCustomerWindow edit = new EditCustomerWindow();
                edit.ShowDialog();
            });
            ExitCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Close();
            });
           
        
            SaveAddCommand = new RelayCommand<object>(
                (p) =>
                {
                    return !(String.IsNullOrEmpty(DiaChi) || String.IsNullOrEmpty(CMND) || String.IsNullOrEmpty(TenKhachHang));
                },
                (p) =>
                {
                    AddCustomer();

                });

            SaveEditCommand = new RelayCommand<object>((p) => { return isEditFormValidate(); }, (p) =>
            {
                var kh = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.MaKhachHang == SelectedItem.MaKhachHang).SingleOrDefault();
                if (DataProvider.Ins.DB.KHACHHANGs.Where(x => x.CMND == CMND).Count() > 0)
                {
                    MessageBox.Show("CMND đã tồn tại!");
                    return;
                }
                kh.DiaChi = DiaChi;
                kh.CMND = CMND;
                kh.TenKhachHang = TenKhachHang;
                DataProvider.Ins.DB.SaveChanges();
                for (int i = 0; i < List.Count; i++)
                {
                    if (SelectedItem.MaKhachHang == List[i].MaKhachHang)
                    {
                        List[i] = new KHACHHANG { MaKhachHang = List[i].MaKhachHang, TenKhachHang = List[i].TenKhachHang, CMND = List[i].CMND, SOTIETKIEMs = List[i].SOTIETKIEMs, DiaChi = List[i].DiaChi, BiXoa = List[i].BiXoa };
                        break;
                    }
                }

                MessageBox.Show("Cập nhật thành công!");
                (p as Window).Close();
            });
            SearchCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                List = Init;
                if (SelectedFilter == null || String.IsNullOrEmpty(Query))
                    List = Init;
                else
                {
                    switch (SelectedFilter)
                    {
                        case "Tên khách hàng":
                            List = new ObservableCollection<KHACHHANG>(List.Where(x => x.BiXoa != true && x.TenKhachHang.Contains(Query)));
                            break;
                        case "Số CMND":
                            List = new ObservableCollection<KHACHHANG>(List.Where(x => x.BiXoa != true && x.CMND.Contains(Query)));
                            break;
                    }
                }
            });
        }
        private void ResetField()
        {
            
            CMND = "";
            TenKhachHang = "";
            DiaChi = "";
        }
        private void AddCustomer()
        {
            if (DataProvider.Ins.DB.KHACHHANGs.Where(x => x.CMND == CMND).Count() == 0)
            {
                var kh = new KHACHHANG() { TenKhachHang = TenKhachHang, DiaChi = DiaChi, CMND = CMND };
                DataProvider.Ins.DB.KHACHHANGs.Add(kh);
                DataProvider.Ins.DB.SaveChanges();
                List.Add(kh);
                MessageBox.Show("Thêm thành công!");
                ResetField();
            }
            else
            {
                MessageBox.Show("CMND đã tồn tại","Cảnh báo lỗi",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
           
        }
        private bool isEditFormValidate()
        {
            if (SelectedItem == null) return false;
            if (SelectedItem.TenKhachHang == TenKhachHang && SelectedItem.DiaChi == DiaChi && SelectedItem.CMND == CMND) return false;
            if ((String.IsNullOrEmpty(DiaChi) || String.IsNullOrEmpty(CMND) || String.IsNullOrEmpty(TenKhachHang))) return false;
            return true;
        }
    }

}
