using QuanLySoTietKiem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects;
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
        private ObservableCollection<SOTIETKIEM> _Init;
        public ObservableCollection<SOTIETKIEM> Init { get => _Init; set { _Init = value; OnPropertyChanged(); } }
        private ObservableCollection<SOTIETKIEM> _ListDaDong;
        public ObservableCollection<SOTIETKIEM> ListDaDong { get => _ListDaDong; set { _ListDaDong = value; OnPropertyChanged(); } }
        private ObservableCollection<LOAITIETKIEM> _LoaiTietKiem;
        public ObservableCollection<LOAITIETKIEM> LoaiTietKiem { get => _LoaiTietKiem; set { _LoaiTietKiem = value; OnPropertyChanged(); } }
        private String[] _FilterList;
        public String[] FilterList { get => _FilterList; set { _FilterList = value; OnPropertyChanged(); } }
        private LOAITIETKIEM _SelectedLoai;
        public LOAITIETKIEM SelectedLoai { get => _SelectedLoai; set { _SelectedLoai = value; OnPropertyChanged(); } }
        private SOTIETKIEM _SelectedItem;
        public SOTIETKIEM SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }
        private SOTIETKIEM _SelectedItemDaXoa;
        public SOTIETKIEM SelectedItemDaXoa { get => _SelectedItemDaXoa; set { _SelectedItemDaXoa = value; OnPropertyChanged(); } }
        private string _TenKhachHang;
        public string TenKhachHang { get => _TenKhachHang; set { _TenKhachHang = value; OnPropertyChanged(); } }
        private string _DiaChi;
        public string DiaChi { get => _DiaChi; set { _DiaChi = value; OnPropertyChanged(); } }
        private string _SoTienGoi;
        public string SoTienGoi { get => _SoTienGoi; set { _SoTienGoi = value; OnPropertyChanged(); } }
        private string _CMND;
        public string CMND { get => _CMND; set { _CMND = value; OnPropertyChanged(); } }
        private string _Query;
        public string Query { get => _Query; set { _Query = value; OnPropertyChanged(); } }
        private string _SelectedFilter;
        public string SelectedFilter { get => _SelectedFilter; set { _SelectedFilter = value; OnPropertyChanged(); } }
        private Visibility _ClosedSavingVisible;
        public Visibility ClosedSavingVisible { get => _ClosedSavingVisible; set { _ClosedSavingVisible = value; OnPropertyChanged(); } }
        public ICommand AddFormCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand SearchCMNDCommand { get; set; }
        public ICommand RestoreFormCommand { get; set; }
        public ICommand RestoreCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand DeletePerformantlyCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand SaveAddCommand { get; set; }
        public ICommand TextChangeCommand { get; set; }
        public SavingAccountViewModel(NGUOIDUNG n)
        {
            ClosedSavingVisible = (n.MaNhom == 1) ? Visibility.Visible : Visibility.Hidden;
            FilterList = new String[] { "Tên khách hàng", "Mã sổ tiết kiệm", "Loại tiết kiệm" };
            Init = new ObservableCollection<SOTIETKIEM>(DataProvider.Ins.DB.SOTIETKIEMs.Where(x => x.BiDong != true));
            List = Init;
            ListDaDong = new ObservableCollection<SOTIETKIEM>(DataProvider.Ins.DB.SOTIETKIEMs.Where(x => x.BiDong == true));
            LoaiTietKiem = new ObservableCollection<LOAITIETKIEM>(DataProvider.Ins.DB.LOAITIETKIEMs.Where(x => x.BiDong != true));
            AddFormCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                AddSavingAccountView add = new AddSavingAccountView(this);
                add.ShowDialog();
            });

            RestoreFormCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

                RestoreSavingAccountView restore = new RestoreSavingAccountView(this);
                restore.ShowDialog();
            });
            ExitCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Close();
            });
            RestoreCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                {
                    var result = MessageBox.Show("Bạn có muốn phục hồi sổ tiết kiệm này không?", "Phục hồi", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (result == MessageBoxResult.Yes)
                    {
                        var stk = DataProvider.Ins.DB.SOTIETKIEMs.Where(x => x.MaSo == SelectedItemDaXoa.MaSo).SingleOrDefault();
                        if (stk != null)
                        {
                            stk.BiDong = false;
                            DataProvider.Ins.DB.SaveChanges();
                            List.Add(SelectedItemDaXoa);
                            ListDaDong.Remove(SelectedItemDaXoa);
                            SelectedItemDaXoa = null;
                        }
                    }
                }
            });
            DeletePerformantlyCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (SelectedItemDaXoa == null) return false;
                    return (SelectedItemDaXoa.SoTienGoi <= 0);
                },
                (p) =>
                {
                    var result = MessageBox.Show("Bạn có muốn xóa sổ tiết kiệm này vĩnh viễn không? (Tất cả dữ liệu đi kèm của sổ sẽ bị xóa)", "Xóa", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (result == MessageBoxResult.Yes)
                    {
                        var stk = DataProvider.Ins.DB.SOTIETKIEMs.Where(x => x.MaSo == SelectedItemDaXoa.MaSo).SingleOrDefault();
                        if (stk != null)
                        {
                            DataProvider.Ins.DB.SOTIETKIEMs.Remove(stk);
                            DataProvider.Ins.DB.SaveChanges();
                            ListDaDong.Remove(SelectedItemDaXoa);
                            SelectedItemDaXoa = null;
                            MessageBox.Show("Xóa sổ tiết kiệm thành công");
                        }
                    }
                });
            DeleteCommand = new RelayCommand<object>(
                (p) =>
                {
                    if (SelectedItem == null) return false;
                    return (SelectedItem.SoTienGoi <= 0);
                },
                (p) =>
                {
                    var result = MessageBox.Show("Bạn có muốn xóa sổ tiết kiệm này không?", "Xóa", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (result == MessageBoxResult.Yes)
                    {
                        var stk = DataProvider.Ins.DB.SOTIETKIEMs.Where(x => x.MaSo == SelectedItem.MaSo).SingleOrDefault();
                        stk.BiDong = true;
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
            SearchCMNDCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                var kh = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.CMND == CMND).SingleOrDefault();

                if (kh == null)
                {
                    MessageBox.Show("Không tìm thấy khách hàng này! Bạn có thể qua tab khách hàng để đăng kí thông tin khách hàng");
                    return;
                }
                TenKhachHang = kh.TenKhachHang;
                DiaChi = kh.DiaChi;
            });
            TextChangeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                DiaChi = "";
                TenKhachHang = "";
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
                            List = new ObservableCollection<SOTIETKIEM>(List.Where(x => x.BiDong != true && x.KHACHHANG.TenKhachHang.ToLowerInvariant().Contains(Query.ToLowerInvariant())));
                            break;
                        case "Mã sổ tiết kiệm":
                            List = new ObservableCollection<SOTIETKIEM>(List.Where(x => x.BiDong != true && x.MaSo.ToString().ToLowerInvariant().Contains(Query.ToLowerInvariant())));
                            break;
                        case "Loại tiết kiệm":
                            List = new ObservableCollection<SOTIETKIEM>(List.Where(x => x.BiDong != true && x.LOAITIETKIEM.TenLoaiTietKiem.ToString().ToLowerInvariant().Contains(Query.ToLowerInvariant())));
                            break;
                    }
                }
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
        private bool isSavingFormValidate()
        {
            return !(String.IsNullOrEmpty(CMND) || String.IsNullOrEmpty(SoTienGoi) || SelectedLoai == null);
        }

        public bool CheckSavingAccount()
        {
            if (!isSavingFormValidate())
                return false;
            bool isIntSoTienGoi = int.TryParse(SoTienGoi, out int soTienGoi);

            if (!isIntSoTienGoi)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng tiền!");
                return false;
            }
            var kh = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.CMND == CMND).SingleOrDefault();
            var thamSo = DataProvider.Ins.DB.THAMSOes.Where(x => x.TenThamSo == "SoTienGoiBanDau").SingleOrDefault();
            if (kh == null || thamSo == null) return false;
            if (soTienGoi < thamSo.GiaTri)
            {
                MessageBox.Show("Số tiền gởi ban đầu tối thiểu là: " + thamSo.GiaTri.ToString());
                return false;
            }
            return true;
        }
        public bool AddSavingAccount()
        {
            if (!CheckSavingAccount())
                return false;

            bool isIntSoTienGoi = int.TryParse(SoTienGoi, out int soTienGoi);
            var kh = DataProvider.Ins.DB.KHACHHANGs.Where(x => x.CMND == CMND).SingleOrDefault();
            var thamSo = DataProvider.Ins.DB.THAMSOes.Where(x => x.TenThamSo == "SoTienGoiBanDau").SingleOrDefault();
            var SOTIETKIEM = new SOTIETKIEM { LaiSuat = SelectedLoai.LaiSuat, NgayMoSo = DateTime.Now, LOAITIETKIEM = SelectedLoai, SoTienGoi = soTienGoi, KHACHHANG = kh, NgayTinhLaiGanNhat = DateTime.Now };
            // Thêm hoặc cập nhật báo cáo doah số ngày
            var bcaoList = new List<BCDOANHSOTHEONGAY> (DataProvider.Ins.DB.BCDOANHSOTHEONGAYs);
            var check = bcaoList.Where(x => x.Ngay.Value.Date == DateTime.Now.Date && x.LoaiTietKiem == SOTIETKIEM.LOAITIETKIEM.MaLoaiTietKiem).Count();
            BCDOANHSOTHEONGAY bcaoNgay;
           
            if (check > 0)
            {
                bcaoNgay = bcaoList.Where(x => x.Ngay.Value.Date == DateTime.Now.Date && x.LoaiTietKiem == SOTIETKIEM.LOAITIETKIEM.MaLoaiTietKiem).First();
                bcaoNgay.TongThu += soTienGoi;
                bcaoNgay.ChenhLech += soTienGoi;
            }
            else
            {
                bcaoNgay = new BCDOANHSOTHEONGAY { Ngay = DateTime.Now, LoaiTietKiem = SOTIETKIEM.LOAITIETKIEM.MaLoaiTietKiem, LOAITIETKIEM1 = SOTIETKIEM.LOAITIETKIEM, TongChi = 0, TongThu = soTienGoi, ChenhLech = soTienGoi };
                DataProvider.Ins.DB.BCDOANHSOTHEONGAYs.Add(bcaoNgay);
            }
            // Thêm hoặc cập nhật báo cáo đóng mở sổ tháng
            List<BCMODONGSOTHANG> bcaoDongMoList = new List<BCMODONGSOTHANG>(DataProvider.Ins.DB.BCMODONGSOTHANGs);
            var bcaoThangCount = bcaoDongMoList.Where(x => x.Nam == DateTime.Now.Year && x.Thang == DateTime.Now.Month && x.LoaiTietKiem == SOTIETKIEM.LOAITIETKIEM.MaLoaiTietKiem).Count();
            CTBCMODONGSOTHANG ctbcThang;
            BCMODONGSOTHANG bcaoThang;
            if (bcaoThangCount > 0)
            {
                bcaoThang = bcaoDongMoList.Where(x => x.Nam == DateTime.Now.Year && x.Thang == DateTime.Now.Month && x.LoaiTietKiem == SOTIETKIEM.LOAITIETKIEM.MaLoaiTietKiem).First();
                List<CTBCMODONGSOTHANG> ctbcThangList = new List<CTBCMODONGSOTHANG>(DataProvider.Ins.DB.CTBCMODONGSOTHANGs.Where(x => x.MaBaoCaoMoDongSo == bcaoThang.MaBaoCaoMoDongSo));
                var ctbcCount = ctbcThangList.Where(x => x.Ngay == DateTime.Now.Day).Count();
                if (ctbcCount > 0)
                {
                    ctbcThang = ctbcThangList.Where(x => x.Ngay == DateTime.Now.Day).Single();
                    ctbcThang.SoMo += 1;
                    ctbcThang.ChenhLech += 1;
                }
                else
                {
                    ctbcThang = new CTBCMODONGSOTHANG { ChenhLech = 1, 
                        SoMo = 1, 
                        SoDong = 0, 
                        BCMODONGSOTHANG = bcaoThang, 
                        MaBaoCaoMoDongSo = bcaoThang.MaBaoCaoMoDongSo,
                        Ngay = DateTime.Now.Day
                    };
                    DataProvider.Ins.DB.CTBCMODONGSOTHANGs.Add(ctbcThang);
                }
            }
            else
            {
               
                bcaoThang = new BCMODONGSOTHANG {
                    LoaiTietKiem = SOTIETKIEM.LOAITIETKIEM.MaLoaiTietKiem,
                    Nam = DateTime.Now.Year,
                    Thang = DateTime.Now.Month,
                    LOAITIETKIEM1 = SOTIETKIEM.LOAITIETKIEM,
                };
                DataProvider.Ins.DB.BCMODONGSOTHANGs.Add(bcaoThang);
                ctbcThang = new CTBCMODONGSOTHANG() { ChenhLech = 1, SoDong = 0, SoMo = 1, Ngay = DateTime.Now.Day, BCMODONGSOTHANG = bcaoThang};
                DataProvider.Ins.DB.CTBCMODONGSOTHANGs.Add(ctbcThang);
            }
            //
            DataProvider.Ins.DB.SOTIETKIEMs.Add(SOTIETKIEM);
            DataProvider.Ins.DB.SaveChanges();

            List.Add(SOTIETKIEM);
            ResetField();
            MessageBox.Show("Mở sổ tiết kiệm thành công!");
            return true;
        }
        private bool CompareDay(DateTime d1, DateTime d2)
        {
            return (d1.Year == d2.Year && d1.Month == d2.Month && d1.Day == d2.Day);
        }
    }
    
}
