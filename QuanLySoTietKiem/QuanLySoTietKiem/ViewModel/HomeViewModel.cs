using QuanLySoTietKiem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows;
using LiveCharts.Defaults;

namespace QuanLySoTietKiem.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        private ObservableCollection<BieuDo1> _List;
        public ObservableCollection<BieuDo1> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private ObservableCollection<PHIEUGOITIEN> _ListGoiTien;
        public ObservableCollection<PHIEUGOITIEN> ListGoiTien { get => _ListGoiTien; set { _ListGoiTien = value; OnPropertyChanged(); } }
        private ObservableCollection<SOTIETKIEM> _ListSTK;
        public ObservableCollection<SOTIETKIEM> ListSTK { get => _ListSTK; set { _ListSTK = value; OnPropertyChanged(); } }
        private ObservableCollection<PHIEURUTTIEN> _ListRutTien;
        public ObservableCollection<PHIEURUTTIEN> ListRutTien { get => _ListRutTien; set { _ListRutTien = value; OnPropertyChanged(); } }
        private int _countCus;
        public int countCus { get => _countCus; set { _countCus = value; OnPropertyChanged(); } }
        private int _countSoMo;
        public int countSoMo { get => _countSoMo; set { _countSoMo = value; OnPropertyChanged(); } }
        private int _countSoDong;
        public int countSoDong { get => _countSoDong; set { _countSoDong = value; OnPropertyChanged(); } }
        private int _SelectedNam;
        public int SelectedNam { get => _SelectedNam; set { _SelectedNam = value; TinhToan(SelectedNam) ; OnPropertyChanged(); } }
        private int[] _listNam = new int[] {2020,2021,2022,2023,2024,2025 };
        public int[] listNam { get => _listNam; set { _listNam = value; OnPropertyChanged(); } }
        private SeriesCollection _SeriesCollection;
        public SeriesCollection SeriesCollection { get => _SeriesCollection; set { _SeriesCollection = value; OnPropertyChanged(); } }
        private SeriesCollection _SeriesCollection1;
        public SeriesCollection SeriesCollection1 { get => _SeriesCollection1; set { _SeriesCollection1 = value; OnPropertyChanged(); } }
        public string[] Labels { get; set; }
        public int[] tongThu { get; set; }
        public int[] tongChi { get; set; }

        public Func<double, string> Formatter { get; set; }


        public HomeViewModel()
        {
            List = new ObservableCollection<BieuDo1>();
            ListGoiTien = new ObservableCollection<PHIEUGOITIEN>(DataProvider.Ins.DB.PHIEUGOITIENs);
            ListRutTien = new ObservableCollection<PHIEURUTTIEN>(DataProvider.Ins.DB.PHIEURUTTIENs);
            ListSTK = new ObservableCollection<SOTIETKIEM>(DataProvider.Ins.DB.SOTIETKIEMs.Where(x=>x.BiXoa!=true));
            TinhTongTungLoaiTietKiem();

            //also adding values updates and animates the chart automatically
            SelectedNam = 2021;
            Labels = new[] { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" };
            Formatter = value => value.ToString("N");

            // TinhToan();
            TinhCacCount();

        }
        public void TinhTongTungLoaiTietKiem()
        {
            SeriesCollection1 = new SeriesCollection();
            var LoaiSTK = DataProvider.Ins.DB.LOAITIETKIEMs.Where(x=>x.BiXoa!=true);
            int count = 0;
            foreach(var loaitk in LoaiSTK)
            {
                foreach(var item in ListSTK)
                {
                    if (item.LOAITIETKIEM.TenLoaiTietKiem == loaitk.TenLoaiTietKiem)
                    {
                        count++;
                    }
                }
                SeriesCollection1.Add(
                    new PieSeries
                    {
                        Title = loaitk.TenLoaiTietKiem,
                        Values = new ChartValues<ObservableValue> { new ObservableValue(count)},
                        DataLabels = true
                    }
                );
                count = 0;
            }
        }
        public void TinhToan(int yeaR)
        {
            int sumThuThang = 0;
            int sumChiThang = 0;
            tongThu = new int[13];
            tongChi = new int[13];
            var listPhieuRutTien = ListRutTien.Where(x=>x.NgayRut.Value.Year==yeaR);
            var listPhieuGoiTien = ListGoiTien.Where(x=>x.NgayGoi.Value.Year==yeaR);
            if (listPhieuGoiTien == null && listPhieuRutTien == null) return;
            for (int i = 1; i < 13; i++)
            {
                foreach (var item in listPhieuGoiTien)
                {
                    DateTime ngayGoi = (DateTime)item.NgayGoi;
                    if (ngayGoi.Month == i)
                    {
                        sumThuThang += (int)item.SoTienGoi;
                    }
                }
                foreach (var item in listPhieuRutTien)
                {
                    DateTime ngayRut = (DateTime)item.NgayRut;
                    if (ngayRut.Month == i)
                    {
                        sumChiThang += (int)item.SoTienRut;
                    }
                }
                //  List.Add(new BieuDo1 { Thang = i,TongThu=sumThuThang,TongChi=sumChiThang });
                tongThu[i - 1] = sumThuThang;
                tongChi[i - 1] = sumChiThang;
                sumChiThang = 0;
                sumThuThang = 0;

            }
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Tổng thu",
                    Values = new ChartValues<int>(tongThu)

                }
            };

            //adding series will update and animate the chart automatically
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Tổng chi",
                Values = new ChartValues<int>(tongChi)
            });
        }
        public void TinhCacCount()
        {
            countCus = DataProvider.Ins.DB.KHACHHANGs.Count();
            countSoMo = DataProvider.Ins.DB.SOTIETKIEMs.Where(x => x.BiXoa != true).Count();
            countSoDong = DataProvider.Ins.DB.SOTIETKIEMs.Where(x => x.BiXoa == true).Count();
        }
    }
    public class BieuDo1
    {
        public int Thang { get; set; }
        public int TongChi { get; set; }
        public int TongThu { get; set; }

    }

}