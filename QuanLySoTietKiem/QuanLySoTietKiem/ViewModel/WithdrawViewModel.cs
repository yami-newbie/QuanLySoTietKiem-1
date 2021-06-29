using QuanLySoTietKiem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using MessageBox = System.Windows.Forms.MessageBox;

namespace QuanLySoTietKiem.ViewModel
{
    public class WithdrawViewModel: BaseViewModel
    {
        private ObservableCollection<PHIEURUTTIEN> _List;
        public ObservableCollection<PHIEURUTTIEN> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private ObservableCollection<PHIEURUTTIEN> _Init;
        public ObservableCollection<PHIEURUTTIEN> Init { get => _Init; set { _Init = value; OnPropertyChanged(); } }
        private ObservableCollection<SOTIETKIEM> _ListSTK;
        public ObservableCollection<SOTIETKIEM> ListSTK { get => _ListSTK; set { _ListSTK = value; OnPropertyChanged(); } }
        private string _TenKhachHang;
        public string TenKhachHang { get => _TenKhachHang; set { _TenKhachHang = value; OnPropertyChanged(); } }
        private string _MaSo;
        public string MaSo { get => _MaSo; set { _MaSo = value; CheckMaSTK(_MaSo); OnPropertyChanged(); } }
        private string _SoTienRut;
        public string SoTienRut { get => _SoTienRut; set { _SoTienRut = value; checkTienRut(MaSo); OnPropertyChanged(); } }
        private string _SoTienGui;
        public string SoTienGui { get => _SoTienGui; set { _SoTienGui = value; OnPropertyChanged(); } }
        private string _LoaiSTK;
        public string LoaiSTK { get => _LoaiSTK; set { _LoaiSTK = value; OnPropertyChanged(); } }

        private string _CMND;
        public string CMND { get => _CMND; set { _CMND = value; OnPropertyChanged(); } }
        private String[] _FilterList;
        public String[] FilterList { get => _FilterList; set { _FilterList = value; OnPropertyChanged(); } }
        private PHIEURUTTIEN _SelectedItem;
        public PHIEURUTTIEN SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }
        private string _SelectedFilter;
        public string SelectedFilter { get => _SelectedFilter; set { _SelectedFilter = value; OnPropertyChanged(); } }
        private string _Query;
        public string Query { get => _Query; set { _Query = value; OnPropertyChanged(); } }
        bool clicked = false;
        public ICommand AddCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand PrintCommand { get; set; }
        public ICommand PrintWindowCommand { get; set; }


        public WithdrawViewModel()
        {
            FilterList = new String[] { "Tên khách hàng", "Mã sổ tiết kiệm", "Loại tiết kiệm" };
            Init = new ObservableCollection<PHIEURUTTIEN>(DataProvider.Ins.DB.PHIEURUTTIENs);
            List = Init;
            ListSTK = new ObservableCollection<SOTIETKIEM>(DataProvider.Ins.DB.SOTIETKIEMs);

            AddCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                RutTienWindow addWithDraw = new RutTienWindow(this);
                addWithDraw.ShowDialog();
            });
            ExitCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                ResetField();
                MaSo = "";
                p.Close();
            });
            SaveCommand = new RelayCommand<Window>(
                (p) =>
                {
                    if ((String.IsNullOrEmpty(MaSo)) != true && clicked==true )
                        return true;
                    else
                        return false;
                },
                (p) =>
                {
                    AddDeposit();
                    ResetField();
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
                            List = new ObservableCollection<PHIEURUTTIEN>(List.Where(x=> x.SOTIETKIEM.KHACHHANG.TenKhachHang.Contains(Query)));
                            break;
                        case "Mã sổ tiết kiệm":
                            List = new ObservableCollection<PHIEURUTTIEN>(List.Where(x => x.MaSo.ToString().Contains(Query)));
                            break;
                        case "Loại tiết kiệm":
                            List = new ObservableCollection<PHIEURUTTIEN>(List.Where(x => x.SOTIETKIEM.LOAITIETKIEM.TenLoaiTietKiem.ToString().Contains(Query)));
                            break;
                    }
                }
            });
            PrintCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                System.Windows.Controls.PrintDialog print = new System.Windows.Controls.PrintDialog();
                print.PrintVisual(p as Grid, "Phiếu rút tiền");
            });
            PrintWindowCommand = new RelayCommand<object>((p) => { return (SelectedItem != null); }, (p) =>
            {
                WithdrawVoucherPrint d = new WithdrawVoucherPrint(this);
                d.ShowDialog();
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

            var stk = ListSTK.Where(x => x.MaSo == mastk && x.BiDong != true).SingleOrDefault();
            if (stk == null)
            {
                clicked = false;
                ResetField();
            }
            else
            {
                CMND = stk.KHACHHANG.CMND;
                TenKhachHang = stk.KHACHHANG.TenKhachHang;
                LoaiSTK = stk.LOAITIETKIEM.TenLoaiTietKiem.ToString();
                SoTienGui = "Số dư khả dụng: " + TinhSoDu(maSTK) + " VNĐ";
                TimeSpan timedate = (TimeSpan)(DateTime.Now - stk.NgayMoSo);
                if (stk.LOAITIETKIEM.TenLoaiTietKiem == "Không kì hạn")
                {
                    if ((DateTime.Now - (DateTime)stk.NgayMoSo).TotalDays < stk.LOAITIETKIEM.ThoiGianGoiToiThieu)
                        MessageBox.Show("Chưa đủ thời gian để rút tiền. Số ngày mới gửi được: " + timedate.Days + " ngày");

                    else
                        MessageBox.Show(DateTime.Now + "---" + stk.NgayMoSo + "= " + timedate.Days.ToString());
                }
                else
                {
                    SoTienRut = TinhSoDu(maSTK).ToString();

                }


            }              
        }
        private bool checkTienRut(string maSTK)
        {
            bool isIntMaSo = int.TryParse(maSTK, out int mastk);
            bool isIntSoTienRut = int.TryParse(SoTienRut, out int soTienRut);
            if (soTienRut == 0)
            {
                clicked = false;
                return false;
            }
            var stk = ListSTK.Where(x => x.MaSo == mastk && x.BiDong != true).SingleOrDefault();
            if (stk == null)
            {
                clicked = false;
                return false;
            }
            else
            {
                if(stk.LOAITIETKIEM.TenLoaiTietKiem=="Không kì hạn")
                {
                    if (soTienRut <= TinhSoDu(stk.MaSo.ToString()))
                        {
                        clicked = true;
                        return true;
                    }
                    else {
                        clicked = false;
                        return false; 
                    }
                }
                else
                {
                    if (soTienRut!=TinhSoDu(maSTK))
                    {
                        SoTienRut = TinhSoDu(maSTK).ToString();

                         clicked = true;
                          return true;
                    }
                    else
                    {
                        clicked = true;
                        return true;
                    }
                }
            }
            return false;

        }
 
        private long TinhSoDu(string maSTK)
        {
            long soDu = 0;
            bool isIntMaSo = int.TryParse(maSTK, out int _mastk);
          //  bool isIntSoTienRut = int.TryParse(SoTienRut, out int soTienGoi);
            if (!isIntMaSo ) return 0;
            int luuSoTienGui = 0;
            var stk = ListSTK.Where(x => x.MaSo == _mastk && x.BiDong != true).SingleOrDefault();
            if (stk.LOAITIETKIEM.TenLoaiTietKiem == "Không kì hạn")
            {
                var koKiHan = DataProvider.Ins.DB.LOAITIETKIEMs.Where(x => x.TenLoaiTietKiem == "Không kì hạn").SingleOrDefault();
                if (koKiHan == null) return 0;
                var laiSuatKoKiHan = koKiHan.LaiSuat;
                if ((DateTime.Now - (DateTime)stk.NgayMoSo).TotalDays < stk.LOAITIETKIEM.ThoiGianGoiToiThieu) return 0;
                else
                    soDu = (long)(stk.SoTienGoi + ((int)((decimal)stk.SoTienGoi * laiSuatKoKiHan * (int)(DateTime.Now - (DateTime)stk.NgayTinhLaiGanNhat).TotalDays / 36000)));
                //  MessageBox.Show(((decimal)stk.SoTienGoi * (decimal)stk.LOAITIETKIEM.LaiSuat * (decimal)(DateTime.Now - (DateTime)stk.NgayTinhLaiGanNhat).TotalDays / 36000).ToString());
                return soDu;
            }

            else
            {
                if ((DateTime.Now - (DateTime)stk.NgayMoSo).TotalDays < stk.LOAITIETKIEM.ThoiGianGoiToiThieu)
                {
                    MessageBox.Show("Chưa đến kì hạn tính lãi suất để có thể rút tiền!");
                    clicked = false;
                    return 0;
                }
                var koKiHan = DataProvider.Ins.DB.LOAITIETKIEMs.Where(x => x.TenLoaiTietKiem == "Không kì hạn").SingleOrDefault();
                if (koKiHan == null) return 0;
                var laiSuatKoKiHan = koKiHan.LaiSuat;
                int laiKiHan=0;
                int laiKhongKiHan=0;
                /*   if (((DateTime)stk.NgayTinhLaiGanNhat - (DateTime)stk.NgayMoSo).TotalDays < stk.LOAITIETKIEM.ThoiGianGoiToiThieu)
                   {
                    //   MessageBox.Show("cc");
                       laiKiHan = (int)((decimal)stk.SoTienGoi * (decimal)stk.LOAITIETKIEM.LaiSuat * stk.LOAITIETKIEM.ThoiGianGoiToiThieu / 36000);
                       laiKhongKiHan = (int)((decimal)stk.SoTienGoi * (decimal)laiSuatKoKiHan * (int)((DateTime.Now - (DateTime)stk.NgayTinhLaiGanNhat).TotalDays - stk.LOAITIETKIEM.ThoiGianGoiToiThieu) / 36000);
                   }
                */
                //    else
                //    {
                var soLanKyHan = (int)((DateTime.Now.Date - (DateTime)stk.NgayTinhLaiGanNhat.Value.Date).TotalDays / (int)(stk.LOAITIETKIEM.ThoiGianGoiToiThieu));
                luuSoTienGui = (int)stk.SoTienGoi;
               // MessageBox.Show((DateTime.Now.Date - (DateTime)stk.NgayTinhLaiGanNhat.Value.Date).TotalDays.ToString()+"ngày, "+ soLanKyHan+ "Lần kì hạn/"+stk.LaiSuat/100);
                    if ((DateTime.Now - (DateTime)stk.NgayTinhLaiGanNhat).TotalDays > stk.LOAITIETKIEM.ThoiGianGoiToiThieu)
                    {
                        for(int i=0;i<soLanKyHan; i++)
                        {
                            laiKiHan = (int)((decimal)stk.SoTienGoi * (decimal)stk.LaiSuat * stk.LOAITIETKIEM.ThoiGianGoiToiThieu / 36000);

                            luuSoTienGui += laiKiHan;
                        }                           
                    }
              //  MessageBox.Show("So tien gui co ki han: " + luuSoTienGui);
                  //  laiKiHan = 0;
                laiKhongKiHan = (int)(luuSoTienGui * (decimal)laiSuatKoKiHan * (int)((DateTime.Now.Date - (DateTime)stk.NgayTinhLaiGanNhat.Value.Date).TotalDays - stk.LOAITIETKIEM.ThoiGianGoiToiThieu*soLanKyHan) / 36000);
                //  }
              //  MessageBox.Show("So tien gui khong  ki han: " + laiKhongKiHan);

                soDu = (int)(luuSoTienGui + laiKhongKiHan);
             //   MessageBox.Show("Số dư: " + soDu);
                return soDu;
            }

        }
        private void AddDeposit()
        {

            bool isIntMaSo = int.TryParse(MaSo, out int maSo);
            bool isIntSoTienRut = int.TryParse(SoTienRut, out int soTienRut);
            if (!isIntMaSo || !isIntSoTienRut) return;

            var stk = DataProvider.Ins.DB.SOTIETKIEMs.Where(x => x.MaSo == maSo && x.BiDong != true).SingleOrDefault();
            if (stk == null) return;

            CheckMaSTK(MaSo);
            if (checkTienRut(MaSo))
            {
                // MessageBox.Show("Vô nút save"+ "sotiengoi: "+stk.SoTienGoi);
                int copySoTienGui = 0;
                copySoTienGui = (int)(TinhSoDu(MaSo) - soTienRut);
               // MessageBox.Show(stk.SoTienGoi.ToString()+"= sodu:"+TinhSoDu(MaSo)+"+ sotienrut: "+soTienRut);
                var result2 = MessageBox.Show("Bạn muốn rút số tiền: " + SoTienRut.ToString(),
             "Kiểm tra lại thao tác",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Warning);
                if (result2.ToString() == "Yes")
                {
                    stk.NgayTinhLaiGanNhat = DateTime.Now;// cập nhật sau
                    if (copySoTienGui == 0)
                    {
                        stk.BiDong = true;
                        stk.SoTienGoi = 0;
                        //Them mo dong so
                        List<BCMODONGSOTHANG> bcaoDongMoList = new List<BCMODONGSOTHANG>(DataProvider.Ins.DB.BCMODONGSOTHANGs);
                        var bcaoThangCount = bcaoDongMoList.Where(x => x.Nam == DateTime.Now.Year && x.Thang == DateTime.Now.Month && x.LoaiTietKiem == stk.LOAITIETKIEM.MaLoaiTietKiem).Count();
                        CTBCMODONGSOTHANG ctbcThang;
                        BCMODONGSOTHANG bcaoThang;
                        if (bcaoThangCount > 0)
                        {
                            bcaoThang = bcaoDongMoList.Where(x => x.Nam == DateTime.Now.Year && x.Thang == DateTime.Now.Month && x.LoaiTietKiem == stk.LOAITIETKIEM.MaLoaiTietKiem).First();
                            List<CTBCMODONGSOTHANG> ctbcThangList = new List<CTBCMODONGSOTHANG>(DataProvider.Ins.DB.CTBCMODONGSOTHANGs.Where(x => x.MaBaoCaoMoDongSo == bcaoThang.MaBaoCaoMoDongSo));
                            var ctbcCount = ctbcThangList.Where(x => x.Ngay == DateTime.Now.Day).Count();
                            if (ctbcCount > 0)
                            {
                                ctbcThang = ctbcThangList.Where(x => x.Ngay == DateTime.Now.Day).Single();
                                ctbcThang.SoDong += 1;
                                ctbcThang.ChenhLech -= 1;
                            }
                            else
                            {
                                ctbcThang = new CTBCMODONGSOTHANG
                                {
                                    ChenhLech = -1,
                                    SoMo = 0,
                                    SoDong = 1,
                                    BCMODONGSOTHANG = bcaoThang,
                                    MaBaoCaoMoDongSo = bcaoThang.MaBaoCaoMoDongSo,
                                    Ngay = DateTime.Now.Day
                                };
                                DataProvider.Ins.DB.CTBCMODONGSOTHANGs.Add(ctbcThang);
                            }
                        }
                        else
                        {

                            bcaoThang = new BCMODONGSOTHANG
                            {
                                LoaiTietKiem = stk.LOAITIETKIEM.MaLoaiTietKiem,
                                Nam = DateTime.Now.Year,
                                Thang = DateTime.Now.Month,
                                LOAITIETKIEM1 = stk.LOAITIETKIEM,
                            };
                            DataProvider.Ins.DB.BCMODONGSOTHANGs.Add(bcaoThang);
                            ctbcThang = new CTBCMODONGSOTHANG() { ChenhLech = -1, SoDong = 1, SoMo = 0, Ngay = DateTime.Now.Day, BCMODONGSOTHANG = bcaoThang };
                            DataProvider.Ins.DB.CTBCMODONGSOTHANGs.Add(ctbcThang);
                        }
                     }
                    stk.SoTienGoi = copySoTienGui;
                   
                        var PHIEURUTTIEN = new PHIEURUTTIEN { SOTIETKIEM = stk, SoTienRut = soTienRut, MaSo = maSo, NgayRut = DateTime.Now };
                        DataProvider.Ins.DB.PHIEURUTTIENs.Add(PHIEURUTTIEN);
                        //  var bcTheoNgay = DataProvider.Ins.DB.BCDOANHSOTHEONGAYs.Where(x => x.Ngay.Value.Day == DateTime.Now.Day&&x.Ngay.Value.Month==DateTime.Now.Month&&x.Ngay.Value.Year==DateTime.Now.Year).SingleOrDefault();
                        var bcaoList = new List<BCDOANHSOTHEONGAY>(DataProvider.Ins.DB.BCDOANHSOTHEONGAYs);
                        var check = bcaoList.Where(x => x.Ngay.Value.Date == DateTime.Now.Date && x.LoaiTietKiem == stk.LOAITIETKIEM.MaLoaiTietKiem).Count();
                        BCDOANHSOTHEONGAY bcaoNgay;

                        if (check > 0)
                        {
                            bcaoNgay = bcaoList.Where(x => x.Ngay.Value.Date == DateTime.Now.Date && x.LoaiTietKiem == stk.LOAITIETKIEM.MaLoaiTietKiem).First();
                            bcaoNgay.TongChi += soTienRut;
                            bcaoNgay.ChenhLech -= bcaoNgay.TongChi;
                            DataProvider.Ins.DB.SaveChanges();
                        }
                        else
                        {
                            bcaoNgay = new BCDOANHSOTHEONGAY { Ngay = DateTime.Now, LoaiTietKiem = stk.LOAITIETKIEM.MaLoaiTietKiem, LOAITIETKIEM1 = PHIEURUTTIEN.SOTIETKIEM.LOAITIETKIEM, TongChi = soTienRut, TongThu = 0, ChenhLech = -soTienRut };
                            DataProvider.Ins.DB.BCDOANHSOTHEONGAYs.Add(bcaoNgay);
                            DataProvider.Ins.DB.SaveChanges();
                        }

                        DataProvider.Ins.DB.SaveChanges();
                        List.Add(PHIEURUTTIEN);
                        MaSo = "";
                    MessageBox.Show("Bạn đã rút tiền thành công", "Thông báo", MessageBoxButtons.OK, (MessageBoxIcon)MessageBoxImage.Information);

                }
                else
                {

                    MaSo = "";
                }
               
            }

        }
    }
}
