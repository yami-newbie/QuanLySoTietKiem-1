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
    public class DepositViewModel: BaseViewModel
    {
        int tienLai = 0;
        private ObservableCollection<PHIEUGOITIEN> _List;
        public ObservableCollection<PHIEUGOITIEN> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private ObservableCollection<PHIEUGOITIEN> _Init;
        public ObservableCollection<PHIEUGOITIEN> Init { get => _Init; set { _Init = value; OnPropertyChanged(); } }
        private String[] _FilterList;
        public String[] FilterList { get => _FilterList; set { _FilterList = value; OnPropertyChanged(); } }
        private string _TenKhachHang;
        public string TenKhachHang { get => _TenKhachHang; set { _TenKhachHang = value; OnPropertyChanged(); } }
        private string _MaSo;
        public string MaSo { get => _MaSo; set { _MaSo = value; OnPropertyChanged(); } }
        private string _SoTienGoi;
        public string SoTienGoi { get => _SoTienGoi; set { _SoTienGoi = value; OnPropertyChanged(); } }
        private string _CMND;
        public string CMND { get => _CMND; set { _CMND = value; OnPropertyChanged(); } }
            private string _SoDuCu;
        public string SoDuCu { get => _SoDuCu; set { _SoDuCu = value; OnPropertyChanged(); } }
        private string _Lai;
        public string Lai { get => _Lai; set { _Lai = value; OnPropertyChanged(); } }
        private string _SoDuMoi;
        public string SoDuMoi { get => _SoDuMoi; set { _SoDuMoi = value; OnPropertyChanged(); } }
        private string _Query;
        public string Query { get => _Query; set { _Query = value; OnPropertyChanged(); } }
        private string _SelectedFilter;
        public string SelectedFilter { get => _SelectedFilter; set { _SelectedFilter = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand SearchMaSoCommand { get; set; }
        public ICommand TextChangeCommand { get; set; }
        public DepositViewModel()
        {
            FilterList = new String[] { "Tên khách hàng", "Mã sổ tiết kiệm", "Loại tiết kiệm" };
            Init = new ObservableCollection<PHIEUGOITIEN>(DataProvider.Ins.DB.PHIEUGOITIENs);
            List = Init;
            AddCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                AddDepositView addDeposit = new AddDepositView(this);
                addDeposit.ShowDialog();
            });
            ExitCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Close();
            });
            SaveCommand = new RelayCommand<Window>(
                (p) =>
                {
                    return !(String.IsNullOrEmpty(MaSo) || String.IsNullOrEmpty(CMND) || String.IsNullOrEmpty(TenKhachHang) || String.IsNullOrEmpty(SoTienGoi)); 
                },
                (p) =>
                {
                AddDeposit();
                
                });
            SearchMaSoCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                var stk = DataProvider.Ins.DB.SOTIETKIEMs.Where(x => x.MaSo.ToString() == MaSo && x.BiXoa != true).SingleOrDefault();

                if (stk == null)
                {
                    MessageBox.Show("Không tìm thấy sổ tài khoản này!");
                    return;
                }
                if (stk.LOAITIETKIEM.TenLoaiTietKiem == "Không kì hạn")
                {
                    tienLai = (int)((decimal)stk.SoTienGoi * (decimal)stk.LOAITIETKIEM.LaiSuat * (decimal)(DateTime.Now - (DateTime)stk.NgayTinhLaiGanNhat).TotalDays / 36000);
                }
                else
                {
                    MessageBox.Show((DateTime.Now - (DateTime)stk.NgayMoSo).TotalDays.ToString ());
                    if ((DateTime.Now - (DateTime)stk.NgayMoSo).TotalDays < stk.LOAITIETKIEM.ThoiGianGoiToiThieu)
                    {
                        MessageBox.Show("Chưa đến kì hạn tính lãi suất để có thể gửi tiền!");
                        return;
                    }
                    var koKiHan = DataProvider.Ins.DB.LOAITIETKIEMs.Where(x => x.TenLoaiTietKiem == "Không kì hạn").SingleOrDefault();
                    if (koKiHan == null) return;
                    var laiSuatKoKiHan = koKiHan.LaiSuat;
                    int laiKiHan;
                    int laiKhongKiHan;
                    if (((DateTime)stk.NgayTinhLaiGanNhat - (DateTime)stk.NgayMoSo).TotalDays < stk.LOAITIETKIEM.ThoiGianGoiToiThieu)
                    {
                        laiKiHan = (int)((decimal)stk.SoTienGoi * (decimal)stk.LOAITIETKIEM.LaiSuat * stk.LOAITIETKIEM.ThoiGianGoiToiThieu / 36000);
                        laiKhongKiHan = (int)((decimal)stk.SoTienGoi * (decimal)laiSuatKoKiHan * (decimal)((DateTime.Now - (DateTime)stk.NgayTinhLaiGanNhat).TotalDays - stk.LOAITIETKIEM.ThoiGianGoiToiThieu) / 36000);
                    }
                    else
                    {
                        laiKiHan = 0;
                        laiKhongKiHan = (int)((decimal)stk.SoTienGoi * (decimal)laiSuatKoKiHan * (decimal)(DateTime.Now - (DateTime)stk.NgayTinhLaiGanNhat).TotalDays / 36000);
                    }
                    tienLai = laiKiHan + laiKhongKiHan;
                }
                TenKhachHang = stk.KHACHHANG.TenKhachHang;
                CMND = stk.KHACHHANG.CMND;
                SoDuCu = stk.SoTienGoi.ToString();
                Lai = tienLai.ToString();
            });
            TextChangeCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CMND = "";
                TenKhachHang = "";
                Lai = "0";
                SoDuCu = "0";
                SoDuMoi = "0";
                tienLai = 0;
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
                            List = new ObservableCollection<PHIEUGOITIEN>(List.Where(x => x.BiXoa != true && x.SOTIETKIEM.KHACHHANG.TenKhachHang.Contains(Query)));
                            break;
                        case "Mã sổ tiết kiệm":
                            List = new ObservableCollection<PHIEUGOITIEN>(List.Where(x => x.BiXoa != true && x.MaSo.ToString().Contains(Query)));
                            break;
                        case "Loại tiết kiệm":
                            List = new ObservableCollection<PHIEUGOITIEN>(List.Where(x => x.BiXoa != true && x.SOTIETKIEM.LOAITIETKIEM.TenLoaiTietKiem.ToString().Contains(Query)));
                            break;
                    }
                }
            });
        }
        private void ResetField()
        {
            MaSo = "";
            CMND = "";
            TenKhachHang = "";
            SoTienGoi = ""; 
        }
        private void AddDeposit()
        {
            
            bool isIntSoTienGoi = int.TryParse(SoTienGoi, out int soTienGoi);
            if (!isIntSoTienGoi)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng tiền");
                return;
            }
            var stk = DataProvider.Ins.DB.SOTIETKIEMs.Where(x => x.MaSo.ToString() == MaSo && x.BiXoa != true).SingleOrDefault();
            if (stk == null) return;
            var thamSo = DataProvider.Ins.DB.THAMSOes.Where(x => x.Id == "1").SingleOrDefault();
            if (soTienGoi < thamSo.SoTienGoiThemToiThieu)
            {
                MessageBox.Show("Số tiền gởi thêm tối thiểu là: " + thamSo.SoTienGoiThemToiThieu.ToString());
                return;
            }

                if (stk.LOAITIETKIEM.TenLoaiTietKiem == "Không kì hạn")
                {
                    stk.SoTienGoi +=  (int)((decimal)stk.SoTienGoi* (decimal)stk.LOAITIETKIEM.LaiSuat * (decimal)(DateTime.Now - (DateTime)stk.NgayTinhLaiGanNhat).TotalDays / 36000);
                    MessageBox.Show(((decimal)stk.SoTienGoi * (decimal)stk.LOAITIETKIEM.LaiSuat * (decimal)(DateTime.Now - (DateTime)stk.NgayTinhLaiGanNhat).TotalDays / 36000).ToString());
                }
                    
                else
                {

                
                stk.SoTienGoi += soTienGoi + tienLai;
                stk.NgayTinhLaiGanNhat = DateTime.Now;
                SoDuMoi = stk.SoTienGoi.ToString();
                var PHIEUGOITIEN = new PHIEUGOITIEN { SOTIETKIEM = stk, SoTienGoi = soTienGoi, MaSo = int.Parse(MaSo), NgayGoi = DateTime.Now };
                DataProvider.Ins.DB.PHIEUGOITIENs.Add(PHIEUGOITIEN);
                DataProvider.Ins.DB.SaveChanges();
                List.Add(PHIEUGOITIEN);
                MessageBox.Show("Gửi tiền thành công! Số dư mới là: " + SoDuMoi);
            }
        }
    }
}
