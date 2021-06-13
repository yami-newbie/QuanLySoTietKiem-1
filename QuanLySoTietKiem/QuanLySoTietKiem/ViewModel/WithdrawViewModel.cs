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
    public class WithdrawViewModel: BaseViewModel
    {
        private ObservableCollection<PHIEURUTTIEN> _List;
        public ObservableCollection<PHIEURUTTIEN> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private string _TenKhachHang;
        public string TenKhachHang { get => _TenKhachHang; set { _TenKhachHang = value; OnPropertyChanged(); } }
        private string _MaSo;
        public string MaSo { get => _MaSo; set { _MaSo = value; CheckMaSTK(_MaSo); OnPropertyChanged(); } }
        private string _SoTienRut;
        public string SoTienRut { get => _SoTienRut; set { _SoTienRut = value; OnPropertyChanged(); } }
        private string _SoTienGui;
        public string SoTienGui { get => _SoTienGui; set { _SoTienGui = value; OnPropertyChanged(); } }
        private string _LoaiSTK;
        public string LoaiSTK { get => _LoaiSTK; set { _LoaiSTK = value; OnPropertyChanged(); } }

        private string _CMND;
        public string CMND { get => _CMND; set { _CMND = value; OnPropertyChanged(); } }
        public ICommand AddCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public WithdrawViewModel()
        {
            List = new ObservableCollection<PHIEURUTTIEN>(DataProvider.Ins.DB.PHIEURUTTIENs);
            AddCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RutTienWindow addWithDraw = new RutTienWindow();
                addWithDraw.ShowDialog();
            });
            ExitCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Close();
            });
            SaveCommand = new RelayCommand<Window>(
                (p) =>
                {
                    return !(String.IsNullOrEmpty(MaSo) );
                },
                (p) =>
                {
                    AddDeposit();
                    ResetField();
                });
        }
        private void ResetField()
        {
            CMND = "";
            TenKhachHang = "";
            SoTienRut = "";
            LoaiSTK = "";
            SoTienGui = "";
        }
        private void CheckMaSTK(string maSTK)
        {
            bool isIntMaSo = int.TryParse(maSTK, out int mastk);

            var stk = DataProvider.Ins.DB.SOTIETKIEMs.Where(x => x.MaSo == mastk && x.BiXoa == false).SingleOrDefault();
            if (stk == null) ResetField();
            else
            {
                CMND = stk.KHACHHANG.CMND;
                TenKhachHang = stk.KHACHHANG.TenKhachHang;
                LoaiSTK = stk.LOAITIETKIEM.TenLoaiTietKiem.ToString();
                SoTienGui = "Số dư: " + stk.SoTienGoi.ToString()+ " VNĐ";
                TimeSpan timedate = (TimeSpan)(DateTime.Now - stk.NgayMoSo);
                if(LoaiSTK=="Không kì hạn")
                {
                    if (kiemTraDateKhongKyHan((DateTime)stk.NgayMoSo))
                        MessageBox.Show(DateTime.Now + "---" + stk.NgayMoSo + "= " + timedate.Days.ToString());
                    else
                        MessageBox.Show("Chưa đủ 15 ngày để rút tiền. Số ngày mới gửi được: " + timedate.Days + " ngày");
                }

            }              
        }
        private bool kiemTraDateKhongKyHan(DateTime ngayMoSo)
        {
            TimeSpan timedate = (TimeSpan)(DateTime.Now - ngayMoSo);

            if (timedate.Days > 15) return true;
            return false;
        }
        private void AddDeposit()
        {

            bool isIntMaSo = int.TryParse(MaSo, out int maSo);
            bool isIntSoTienRut = int.TryParse(SoTienRut, out int soTienRut);
            if (!isIntMaSo || !isIntSoTienRut) return;
            var stk = DataProvider.Ins.DB.SOTIETKIEMs.Where(x => x.MaSo == maSo && x.BiXoa == false).SingleOrDefault();
            if (stk == null) return;
            CheckMaSTK(MaSo);
            if (stk.KHACHHANG.TenKhachHang == TenKhachHang && stk.KHACHHANG.CMND == CMND)
            {
                var PHIEURUTTIEN = new PHIEURUTTIEN { SOTIETKIEM = stk, SoTienRut = soTienRut, MaSo = maSo, NgayRut = DateTime.Now };
                DataProvider.Ins.DB.PHIEURUTTIENs.Add(PHIEURUTTIEN);
                DataProvider.Ins.DB.SaveChanges();
                //List.Add(PHIEURUTTIEN);
            }
        }
    }
}
