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
                ResetField();
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
            var stk = DataProvider.Ins.DB.SOTIETKIEMs.Where(x => x.MaSo == maSo && x.BiXoa == false).SingleOrDefault();
            if (stk == null) return;
            if (stk.KHACHHANG.TenKhachHang == TenKhachHang && stk.KHACHHANG.CMND == CMND)
            {
                var PHIEUGOITIEN = new PHIEUGOITIEN { SOTIETKIEM = stk, SoTienGoi = soTienGoi, MaSo = maSo, NgayGoi = DateTime.Now };
                DataProvider.Ins.DB.PHIEUGOITIENs.Add(PHIEUGOITIEN);
                DataProvider.Ins.DB.SaveChanges();
                List.Add(PHIEUGOITIEN);
            }
        }
    }
}
