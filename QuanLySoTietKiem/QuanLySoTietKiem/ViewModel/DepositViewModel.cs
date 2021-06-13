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
        private ObservableCollection<PHIEUGOITIEN> _List;
        public ObservableCollection<PHIEUGOITIEN> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private string _TenKhachHang;
        public string TenKhachHang { get => _TenKhachHang; set { _TenKhachHang = value; OnPropertyChanged(); } }
        private string _MaSo;
        public string MaSo { get => _MaSo; set { _MaSo = value; OnPropertyChanged(); } }
        private string _SoTienGoi;
        public string SoTienGoi { get => _SoTienGoi; set { _SoTienGoi = value; OnPropertyChanged(); } }
        private string _CMND;
        public string CMND { get => _CMND; set { _CMND = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public DepositViewModel()
        {
            List = new ObservableCollection<PHIEUGOITIEN>(DataProvider.Ins.DB.PHIEUGOITIENs);
            AddCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                AddDepositView addDeposit = new AddDepositView();
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
            
            bool isIntMaSo = int.TryParse(MaSo, out int maSo);
            bool isIntSoTienGoi = int.TryParse(SoTienGoi, out int soTienGoi);
            if (!isIntMaSo || !isIntSoTienGoi) return;
            var stk = DataProvider.Ins.DB.SOTIETKIEMs.Where(x => x.MaSo == maSo && x.BiXoa != true).SingleOrDefault();
            if (stk == null) return;
            var thamSo = DataProvider.Ins.DB.THAMSOes.Where(x => x.Id == "1").SingleOrDefault();
            if (soTienGoi < thamSo.SoTienGoiThemToiThieu)
            {
                MessageBox.Show("Số tiền gởi thêm tối thiểu là: " + thamSo.SoTienGoiThemToiThieu.ToString());
                return;
            }
            if (stk.KHACHHANG.TenKhachHang == TenKhachHang && stk.KHACHHANG.CMND == CMND)
            {
                if (stk.LOAITIETKIEM.TenLoaiTietKiem == "Không kì hạn")
                {
                    stk.SoTienGoi +=  (int)((decimal)stk.SoTienGoi* (decimal)stk.LOAITIETKIEM.LaiSuat * (decimal)(DateTime.Now - (DateTime)stk.NgayTinhLaiGanNhat).TotalDays / 36000);
                    MessageBox.Show(((decimal)stk.SoTienGoi * (decimal)stk.LOAITIETKIEM.LaiSuat * (decimal)(DateTime.Now - (DateTime)stk.NgayTinhLaiGanNhat).TotalDays / 36000).ToString());
                }
                    
                else
                {
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
                        MessageBox.Show("cc");
                        laiKiHan = (int)((decimal)stk.SoTienGoi * (decimal)stk.LOAITIETKIEM.LaiSuat * stk.LOAITIETKIEM.ThoiGianGoiToiThieu / 36000);
                        laiKhongKiHan = (int)((decimal)stk.SoTienGoi * (decimal)laiSuatKoKiHan * (decimal)((DateTime.Now - (DateTime)stk.NgayTinhLaiGanNhat).TotalDays - stk.LOAITIETKIEM.ThoiGianGoiToiThieu) / 36000);
                    }
                    else
                    {
                        laiKiHan = 0;
                        laiKhongKiHan = (int)((decimal)stk.SoTienGoi * (decimal)laiSuatKoKiHan * (decimal)(DateTime.Now - (DateTime)stk.NgayTinhLaiGanNhat).TotalDays / 36000);
                    }
                    stk.SoTienGoi += laiKiHan + laiKhongKiHan;
                }               
                stk.SoTienGoi += soTienGoi;
                stk.NgayTinhLaiGanNhat = DateTime.Now;
                var PHIEUGOITIEN = new PHIEUGOITIEN { SOTIETKIEM = stk, SoTienGoi = soTienGoi, MaSo = maSo, NgayGoi = DateTime.Now };
                DataProvider.Ins.DB.PHIEUGOITIENs.Add(PHIEUGOITIEN);
                DataProvider.Ins.DB.SaveChanges();
                List.Add(PHIEUGOITIEN);
                
                ResetField();
            }
        }
    }
}
