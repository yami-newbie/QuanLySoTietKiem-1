using QuanLySoTietKiem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using MessageBox = System.Windows.MessageBox;

namespace QuanLySoTietKiem.ViewModel
{
    public class ReportViewModel : BaseViewModel
    {
        private ObservableCollection<ThongKe1> _List1;
        public ObservableCollection<ThongKe1> List1 { get => _List1; set { _List1 = value; OnPropertyChanged(); } }
        private ObservableCollection<ThongKe2> _List2;
        public ObservableCollection<ThongKe2> List2 { get => _List2; set { _List2 = value; OnPropertyChanged(); } }
        private ObservableCollection<ThongKe2> _List3;
        public ObservableCollection<ThongKe2> List3 { get => _List3; set { _List3 = value; OnPropertyChanged(); } }
        private ObservableCollection<LOAITIETKIEM> _ListLoaiTietKiem;
        public ObservableCollection<LOAITIETKIEM> ListLoaiTietKiem { get => _ListLoaiTietKiem; set { _ListLoaiTietKiem = value; OnPropertyChanged(); } }
        private ObservableCollection<SOTIETKIEM> _ListSTK;
        public ObservableCollection<SOTIETKIEM> ListSTK { get => _ListSTK; set { _ListSTK = value; OnPropertyChanged(); } }
        private ObservableCollection<PHIEUGOITIEN> _ListGoiTien;
        public ObservableCollection<PHIEUGOITIEN> ListGoiTien { get => _ListGoiTien; set { _ListGoiTien = value; OnPropertyChanged(); } }
        private ObservableCollection<PHIEURUTTIEN> _ListRutTien;
        public ObservableCollection<PHIEURUTTIEN> ListRutTien { get => _ListRutTien; set { _ListRutTien = value; OnPropertyChanged(); } }
        private string _TenLoaiTietKiem;
        public string TenLoaiTietKiem { get => _TenLoaiTietKiem; set { _TenLoaiTietKiem = value; OnPropertyChanged(); } }

        private LOAITIETKIEM _SelectedLoai;
        public LOAITIETKIEM SelectedLoai { get => _SelectedLoai; set { _SelectedLoai = value; CheckLTKvsThangvsNam(); OnPropertyChanged(); } }

        private ThongKe2 _SelectedItem;
        public ThongKe2 SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;

                OnPropertyChanged();
                if (SelectedItem != null)
                    MessageBox.Show(SelectedItem.SoMo.ToString());



            }
        }
        private int _SelectedThang;
        public int SelectedThang { get => _SelectedThang; set { _SelectedThang = value; CheckLTKvsThangvsNam(); OnPropertyChanged(); } }
        private int[] _cbxThang = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        public int[] cbxThang { get => _cbxThang; set { _cbxThang = value; OnPropertyChanged(); } }
        private int _SelectedNam;
        public int SelectedNam { get => _SelectedNam; set { _SelectedNam = value; CheckLTKvsThangvsNam(); OnPropertyChanged(); } }
        private int[] _cbxNam = new int[] { 2021, 2022, 2023, 2024, 2025 };
        public int[] cbxNam { get => _cbxNam; set { _cbxNam = value; OnPropertyChanged(); } }
        private int _STT;
        public int STT { get => _STT; set { _STT = value; OnPropertyChanged(); } }
        private string _LoaiTietKiem;
        public string LoaiTietKiem { get => _LoaiTietKiem; set { _LoaiTietKiem = value; OnPropertyChanged(); } }
        private DateTime? _DateInput;
        public DateTime? DateInput { get => _DateInput; set { _DateInput = value; CheckDateIn(); OnPropertyChanged(); } }
        private int _TongThu;
        public int TongThu { get => _TongThu; set { _TongThu = value; OnPropertyChanged(); } }
        private int _TongChi;
        public int TongChi { get => _TongChi; set { _TongChi = value; OnPropertyChanged(); } }

        private int _ChenhLech;
        public int ChenhLech { get => _ChenhLech; set { _ChenhLech = value; OnPropertyChanged(); } }
        public ICommand ExcelDate { get; set; }
        public ICommand ExcelMonth { get; set; }


        public ReportViewModel()
        {
            List2 = new ObservableCollection<ThongKe2>();
            ListLoaiTietKiem = new ObservableCollection<LOAITIETKIEM>(DataProvider.Ins.DB.LOAITIETKIEMs);
            ListSTK = new ObservableCollection<SOTIETKIEM>(DataProvider.Ins.DB.SOTIETKIEMs);
            ListGoiTien = new ObservableCollection<PHIEUGOITIEN>(DataProvider.Ins.DB.PHIEUGOITIENs);
            ListRutTien = new ObservableCollection<PHIEURUTTIEN>(DataProvider.Ins.DB.PHIEURUTTIENs);
            ExcelDate = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                if (List1!=null)
                {
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm| CSV|*.csv";
                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter sw = new StreamWriter(new FileStream(saveFile.FileName, FileMode.Create), Encoding.UTF8))
                        {
                            StringBuilder sb = new StringBuilder();
                            string date = DateTime.Now.ToString("dd/M/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                            sb.AppendLine("BÁO CÁO THỐNG KÊ THEO NGÀY " + DateInput.Value.ToString("dd/MM/yyyy"));
                            //   sb.AppendLine("Thời gian xuất file: "+date);
                            sb.AppendLine("STT, Tên loại tiết kiệm ,Tổng thu(VNĐ), Tổng chi(VNĐ), Chênh lệch(VNĐ)");
                            var i = 0;
                            foreach (var item in List1)
                            {
                                i++;
                                sb.AppendLine(string.Format("{0},{1},{2},{3},{4}", i, item.LoaiTietKiem, item.TongThu, item.TongChi, item.ChenhLech));

                            }
                            await sw.WriteAsync(sb.ToString());
                            MessageBox.Show("Báo cáo của bạn đã được xuất ra file thành công", "Tin nhắn", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Thống kê đang trống, không xuất được file", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
               
            });
            ExcelMonth = new RelayCommand<object>((p) => { return true; }, async (p) =>
            {
                if(List2.Count()>0)
                {
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm| CSV|*.csv";
                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter sw = new StreamWriter(new FileStream(saveFile.FileName, FileMode.Create), Encoding.UTF8))
                        {
                            StringBuilder sb = new StringBuilder();
                            string date = DateTime.Now.ToString("dd/M/yyyy hh:mm:ss", CultureInfo.InvariantCulture);
                            sb.AppendLine("BÁO CÁO THỐNG KÊ THEO THÁNG " + SelectedThang.ToString() + "/" + SelectedNam.ToString());
                            //   sb.AppendLine("Thời gian xuất file: " + date);
                            sb.AppendLine("Loại tiết kiệm: " + SelectedLoai.TenLoaiTietKiem);
                            sb.AppendLine("STT, Thời gian ,Tổng sổ mở ,Tổng sổ đóng, Chênh lệch(Sổ)");
                            foreach (var item in List2)
                            {
                                sb.AppendLine(string.Format("{0},{1},{2},{3},{4}", item.STT, item.Ngay.ToString(),item.SoMo, item.SoDong, item.ChenhLech2));
                            }
                            await sw.WriteAsync(sb.ToString());
                            MessageBox.Show("Báo cáo của bạn đã được xuất ra file thành công", "Tin nhắn", MessageBoxButton.OK, (MessageBoxImage)MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Thống kê đang trống, không xuất được file", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
        }
        public void CheckDateIn()
        {
            if (List1 != null)
            {
                List1.Clear();
            }
            var bcaoList = new List<BCDOANHSOTHEONGAY>(DataProvider.Ins.DB.BCDOANHSOTHEONGAYs);
            var ListCopy = new ObservableCollection<BCDOANHSOTHEONGAY>(bcaoList.Where(x => x.Ngay.Value.Date == DateInput.Value.Date));
           
            if (ListCopy.Count() < 1)
            {
                List1 = null;
                MessageBox.Show("Không có thông tin để hiển thị", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (ListCopy.Count() > 0)
            {
                List1 = new ObservableCollection<ThongKe1>();
                for(int i = 0; i < ListCopy.Count(); i++)
                {
                    List1.Add(new ThongKe1 { STT = i + 1,LoaiTietKiem=ListCopy[i].LOAITIETKIEM1.TenLoaiTietKiem, TongThu= (int)ListCopy[i].TongThu,TongChi=(int)ListCopy[i].TongChi,ChenhLech=(int)ListCopy[i].ChenhLech });
                }
            }
            /*  int i = 0;
              if (ListLoaiTietKiem.Count() > 0)
                  foreach (var _ltk in ListLoaiTietKiem)
                  {
                      i++;
                      List1.Add(new ThongKe1 { STT = i, LoaiTietKiem = _ltk.TenLoaiTietKiem, TongThu = (int)TongTienGoi1Ngay(_ltk.TenLoaiTietKiem), TongChi = (int)TongTienRut1Ngay(_ltk.TenLoaiTietKiem), ChenhLech = (int)TongTienGoi1Ngay(_ltk.TenLoaiTietKiem) - (int)TongTienRut1Ngay(_ltk.TenLoaiTietKiem) });
                  }*/
            // var formatDateInput = String.Format("{0:d}", DateInput);

        }
        public void CheckLTKvsThangvsNam()
        {
            List2.Clear();
            if (SelectedLoai != null && (SelectedThang >= 1 && SelectedThang <= 12) && (SelectedNam >= 2021 && SelectedNam <= 2025))
            {
                TongSo(SelectedLoai.TenLoaiTietKiem, SelectedThang, SelectedNam);
            }
        }


        public double TongTienGoi1Ngay(string strLoaiTietKiem)
        {
            int sumGoi = 0;
            var inputSTK = ListSTK.Where(x => x.LOAITIETKIEM.TenLoaiTietKiem == strLoaiTietKiem);
            var formatDateInput = String.Format("{0:d}", DateInput);
            foreach (var item in inputSTK)
            {
                var phieuGoiTien = ListGoiTien.Where(x => x.MaSo == item.MaSo);
                foreach (var itemPhieuGoiTien in phieuGoiTien)
                {
                    var formatNgayGoiTien = String.Format("{0:d}", itemPhieuGoiTien.NgayGoi);

                    if (formatDateInput == formatNgayGoiTien)
                    {
                        sumGoi += (int)itemPhieuGoiTien.SoTienGoi;
                    }
                }
            }
            return sumGoi;

        }
        public double TongTienRut1Ngay(string strLoaiTietKiem)
        {
            int sumRut = 0;
            var inputSTK = ListSTK.Where(x => x.LOAITIETKIEM.TenLoaiTietKiem == strLoaiTietKiem);
            var formatDateInput = String.Format("{0:d}", DateInput);
            foreach (var item in inputSTK)
            {
                // var formatMoSo = String.Format("{0:d}", item.NgayMoSo);
                // if (formatDateInput==formatMoSo)
                //  {
                var phieuRutTien = ListRutTien.Where(x => x.MaSo == item.MaSo);
                foreach (var itemPhieuRutTien in phieuRutTien)
                {
                    var formatNgayRutTien = String.Format("{0:d}", itemPhieuRutTien.NgayRut);

                    if (formatDateInput == formatNgayRutTien)
                    {
                        sumRut += (int)itemPhieuRutTien.SoTienRut;
                    }
                }
            }
            return sumRut;
        }
        public void TongSo(string strLoaiTietKiem, int soThang, int soNam)
        {
            List<BCMODONGSOTHANG> bcaoDongMoList = new List<BCMODONGSOTHANG>(DataProvider.Ins.DB.BCMODONGSOTHANGs);
            var bcaoThangCount = bcaoDongMoList.Where(x => x.Nam == soNam && x.Thang == soThang && x.LOAITIETKIEM1.TenLoaiTietKiem==strLoaiTietKiem).Count();
            if (bcaoThangCount < 1)
            {
                if (List2 != null)
                    List2.Clear();
                MessageBox.Show("Không có thông tin để hiển thị", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            BCMODONGSOTHANG bcaoList = bcaoDongMoList.Where(x => x.Nam == soNam && x.Thang == soThang && x.LOAITIETKIEM1.TenLoaiTietKiem==strLoaiTietKiem).First();
            List<CTBCMODONGSOTHANG> ctbcThangList = new List<CTBCMODONGSOTHANG>(DataProvider.Ins.DB.CTBCMODONGSOTHANGs.Where(x => x.MaBaoCaoMoDongSo == bcaoList.MaBaoCaoMoDongSo).OrderBy(v=>v.Ngay));

         
            List3 = new ObservableCollection<ThongKe2>();
 
            for (int i = 0; i < ctbcThangList.Count(); i++)
            {
                List3.Add(new ThongKe2 { STT = i + 1, Ngay = ctbcThangList[i].Ngay.ToString() + "/" + soThang + "/" + soNam, SoMo = (int)ctbcThangList[i].SoMo, SoDong = (int)ctbcThangList[i].SoDong, ChenhLech2 = (int)ctbcThangList[i].ChenhLech });
            }



            List2 = List3;

        }
        public int TongSoDong(string strLoaiTietKiem, int soThang)
        {
            int sumTongSo = 0;
            var inputSTK = ListSTK.Where(x => x.BiDong == true);
            foreach (var item in inputSTK)
            {
                DateTime ngayTinhLaiGanNhat = (DateTime)item.NgayTinhLaiGanNhat;
                if (ngayTinhLaiGanNhat.Month == soThang)
                {
                    sumTongSo += 1;
                }
            }
            return sumTongSo;
        }
    }



    public class ThongKe1
    {
        public int STT { get; set; }
        public string LoaiTietKiem { get; set; }
        public int TongChi { get; set; }
        public int TongThu { get; set; }
        public int ChenhLech { get; set; }

    }
    public class ThongKe2
    {
        public int STT { get; set; }
        public string Ngay { get; set; }
        public int SoMo { get; set; }
        public int SoDong { get; set; }
        public int ChenhLech2 { get; set; }

    }
}

