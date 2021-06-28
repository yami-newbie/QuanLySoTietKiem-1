using QuanLySoTietKiem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QuanLySoTietKiem.ViewModel
{
    public class DepositViewModel: BaseViewModel
    {
        int tienLai = 0;
        int tienGoi = 0;
        THAMSO thamSo;
        SOTIETKIEM stk;
        private ObservableCollection<PHIEUGOITIEN> _List;
        public ObservableCollection<PHIEUGOITIEN> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private ObservableCollection<PHIEUGOITIEN> _Init;
        public ObservableCollection<PHIEUGOITIEN> Init { get => _Init; set { _Init = value; OnPropertyChanged(); } }
        private String[] _FilterList;
        public String[] FilterList { get => _FilterList; set { _FilterList = value; OnPropertyChanged(); } }
        private PHIEUGOITIEN _SelectedItem;
        public PHIEUGOITIEN SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }
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
        public ICommand DepositChangedCommand { get; set; }
        public ICommand PrintWindowCommand { get; set; }
        public ICommand PrintCommand { get; set; }
        public DepositViewModel()
        {
             thamSo = DataProvider.Ins.DB.THAMSOes.Where(x => x.TenThamSo== "SoTienGoiThemToiThieu").SingleOrDefault();
            FilterList = new String[] { "Tên khách hàng", "Mã sổ tiết kiệm", "Loại tiết kiệm" };
            Init = new ObservableCollection<PHIEUGOITIEN>(DataProvider.Ins.DB.PHIEUGOITIENs);
            List = Init;
            AddCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                AddDepositView addDeposit = new AddDepositView(this);
                addDeposit.ShowDialog();
            });
            PrintCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                PrintDialog print = new PrintDialog();
                print.PrintVisual(p as Grid, "Phiếu gởi tiền");
            });
            PrintWindowCommand = new RelayCommand<object>((p) => { return (SelectedItem != null); }, (p) =>
            {
                DepositVoucherPrintView d = new DepositVoucherPrintView(this);
                d.ShowDialog();
            });
            ExitCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Close();
            });
            SaveCommand = new RelayCommand<Window>(
                (p) =>
                {
                    return CheckValidAdd();
                },
                (p) =>
                {
                AddDeposit();
                
                });
            SearchMaSoCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                stk = DataProvider.Ins.DB.SOTIETKIEMs.Where(x => x.MaSo.ToString() == MaSo && x.BiDong != true).SingleOrDefault();

                if (stk == null)
                {
                    MessageBox.Show("Không tìm thấy sổ tài khoản này!");
                    return;
                }
                if (stk.LOAITIETKIEM.TenLoaiTietKiem == "Không kì hạn")
                {
                    MessageBox.Show((DateTime.Now - (DateTime)stk.NgayTinhLaiGanNhat).TotalDays.ToString());
                    tienLai = (int)((decimal)stk.SoTienGoi * (decimal)stk.LOAITIETKIEM.LaiSuat * (decimal)(int)(DateTime.Now - (DateTime)stk.NgayTinhLaiGanNhat).TotalDays / 36000);
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
                        laiKhongKiHan = (int)((decimal)stk.SoTienGoi * (decimal)laiSuatKoKiHan * (decimal)(int)((DateTime.Now - (DateTime)stk.NgayTinhLaiGanNhat).TotalDays - stk.LOAITIETKIEM.ThoiGianGoiToiThieu) / 36000);
                    }
                    else
                    {
                        laiKiHan = 0;
                        laiKhongKiHan = (int)((decimal)stk.SoTienGoi * (decimal)laiSuatKoKiHan * (decimal)(int)(DateTime.Now - (DateTime)stk.NgayTinhLaiGanNhat).TotalDays / 36000);
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
            DepositChangedCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SoDuMoi = "0";
                if (stk == null) return;
                bool isIntSoTienGoi = int.TryParse(SoTienGoi, out tienGoi);
                if (!isIntSoTienGoi)
                {
                    SoDuMoi = "0";
                }
                else
                {
                    SoDuMoi = (stk.SoTienGoi + tienGoi + tienLai).ToString();
                }
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
                            List = new ObservableCollection<PHIEUGOITIEN>(List.Where(x =>  x.SOTIETKIEM.KHACHHANG.TenKhachHang.Contains(Query)));
                            break;
                        case "Mã sổ tiết kiệm":
                            List = new ObservableCollection<PHIEUGOITIEN>(List.Where(x =>  x.MaSo.ToString().Contains(Query)));
                            break;
                        case "Loại tiết kiệm":
                            List = new ObservableCollection<PHIEUGOITIEN>(List.Where(x =>  x.SOTIETKIEM.LOAITIETKIEM.TenLoaiTietKiem.ToString().Contains(Query)));
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
            if (stk == null) return;
            if (tienGoi < thamSo.GiaTri)
            {
                MessageBox.Show("Số tiền gởi thêm tối thiểu là: " + thamSo.GiaTri.ToString());
                return;
            }
            stk.SoTienGoi += tienGoi + tienLai;
            stk.NgayTinhLaiGanNhat = DateTime.Now;
            var PHIEUGOITIEN = new PHIEUGOITIEN { SOTIETKIEM = stk, SoTienGoi = tienGoi, MaSo = int.Parse(MaSo), NgayGoi = DateTime.Now };
            // Thêm hoặc cập nhật báo cáo
            var bcaoList = new List<BCDOANHSOTHEONGAY>(DataProvider.Ins.DB.BCDOANHSOTHEONGAYs);
            var check = bcaoList.Where(x => x.Ngay.Value.Date == DateTime.Now.Date && x.LoaiTietKiem == PHIEUGOITIEN.SOTIETKIEM.LOAITIETKIEM.MaLoaiTietKiem).Count();
            BCDOANHSOTHEONGAY bcaoNgay;

            if (check > 0)
            {
                bcaoNgay = bcaoList.Where(x => x.Ngay.Value.Date == DateTime.Now.Date && x.LoaiTietKiem == PHIEUGOITIEN.SOTIETKIEM.LOAITIETKIEM.MaLoaiTietKiem).First();
                bcaoNgay.TongThu += tienGoi;
                bcaoNgay.ChenhLech += tienGoi;
            }
            else
            {
                bcaoNgay = new BCDOANHSOTHEONGAY { Ngay = DateTime.Now, LoaiTietKiem = PHIEUGOITIEN.SOTIETKIEM.LOAITIETKIEM.MaLoaiTietKiem, LOAITIETKIEM1 = PHIEUGOITIEN.SOTIETKIEM.LOAITIETKIEM, TongChi = 0, TongThu = tienGoi, ChenhLech = tienGoi };
                DataProvider.Ins.DB.BCDOANHSOTHEONGAYs.Add(bcaoNgay);
            }
            //
            DataProvider.Ins.DB.PHIEUGOITIENs.Add(PHIEUGOITIEN);
            DataProvider.Ins.DB.SaveChanges();
            List.Add(PHIEUGOITIEN);         
            MessageBox.Show("Gửi tiền thành công! Số dư mới là: " + SoDuMoi);
            ResetField();
        }
        private bool CheckValidAdd()
        {
            bool isIntSoTienGoi = int.TryParse(SoTienGoi, out int i);
            if (!isIntSoTienGoi) return false;
            if (String.IsNullOrEmpty(MaSo) || String.IsNullOrEmpty(CMND) || String.IsNullOrEmpty(TenKhachHang) || String.IsNullOrEmpty(SoTienGoi)) return false;
            return true;
        }
    }
}
