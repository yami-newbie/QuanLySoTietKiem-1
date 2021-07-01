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
                var span = (DateTime.Now.Date - stk.NgayTinhLaiGanNhat.Value.Date).TotalDays;
                if ((bool)!stk.LOAITIETKIEM.PhaiRutToanBo)
                {
                    tienLai = (int)((decimal)stk.SoTienGoi * (decimal)stk.LaiSuat * (decimal)(int)span / 36000);
                }
                else
                {
                    if (span < stk.LOAITIETKIEM.ThoiGianGoiToiThieu)
                    {
                        MessageBox.Show(
                            "Chưa đến kì hạn tính lãi suất để có thể gửi tiền! Khoảng thời gian từ lúc cập nhật mới nhất cho đến bây giờ là  "
                            + span.ToString() + " ngày! Cần " + (stk.LOAITIETKIEM.ThoiGianGoiToiThieu - (int)span).ToString() + " ngày nữa mới có thể gửi tiền!");
                        return;
                    }
                    if ((int)span % stk.LOAITIETKIEM.ThoiGianGoiToiThieu != 0)
                    {
                        MessageBox.Show(
                            "Chưa đến kì hạn tính lãi suất để có thể gửi tiền! Khoảng thời gian từ lúc cập nhật mới nhất cho đến bây giờ là "
                            + span.ToString() + " ngày! Cần " + (stk.LOAITIETKIEM.ThoiGianGoiToiThieu - (int)span % stk.LOAITIETKIEM.ThoiGianGoiToiThieu) .ToString() + " ngày nữa mới có thể gửi tiền!");
                        return;
                    }
                    int soLanDaoHan = (int)span /(int) stk.LOAITIETKIEM.ThoiGianGoiToiThieu;
                    int stg = (int)stk.SoTienGoi;
                    for (int i = 0; i < soLanDaoHan; i++)
                    {
                        tienLai = (int)((decimal)stg * (decimal)stk.LaiSuat * stk.LOAITIETKIEM.ThoiGianGoiToiThieu / 36000);
                        stg += tienLai;
                    }
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
                            List = new ObservableCollection<PHIEUGOITIEN>(List.Where(x =>  x.SOTIETKIEM.KHACHHANG.TenKhachHang.ToLowerInvariant().Contains(Query.ToLowerInvariant())));
                            break;
                        case "Mã sổ tiết kiệm":
                            List = new ObservableCollection<PHIEUGOITIEN>(List.Where(x =>  x.MaSo.ToString().ToLowerInvariant().Contains(Query.ToLowerInvariant())));
                            break;
                        case "Loại tiết kiệm":
                            List = new ObservableCollection<PHIEUGOITIEN>(List.Where(x =>  x.SOTIETKIEM.LOAITIETKIEM.TenLoaiTietKiem.ToString().ToLowerInvariant().Contains(Query.ToLowerInvariant())));
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
            stk.LaiSuat = stk.LOAITIETKIEM.LaiSuat;
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
