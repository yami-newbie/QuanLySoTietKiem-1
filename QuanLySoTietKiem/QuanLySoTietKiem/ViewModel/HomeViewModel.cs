using QuanLySoTietKiem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;

namespace QuanLySoTietKiem.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        private ObservableCollection<BieuDo1> _List;
        public ObservableCollection<BieuDo1> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private int _countCus;
        public int countCus { get => _countCus; set { _countCus = value; OnPropertyChanged(); } }
        private int _countSoMo;
        public int countSoMo { get => _countSoMo; set { _countSoMo = value; OnPropertyChanged(); } }
        private int _countSoDong;
        public int countSoDong { get => _countSoDong; set { _countSoDong = value; OnPropertyChanged(); } }
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public int[] tongThu { get; set; }
        public int[] tongChi { get; set; }

        public Func<double, string> Formatter { get; set; }


        public HomeViewModel()
        {
            List = new ObservableCollection<BieuDo1>();
            TinhToan();
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

            //also adding values updates and animates the chart automatically

            Labels = new[] { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" };
            Formatter = value => value.ToString("N");

            // TinhToan();
            TinhCacCount();

        }
        public void TinhToan()
        {
            int sumThuThang = 0;
            int sumChiThang = 0;
            tongThu = new int[13];
            tongChi = new int[13];
            var listPhieuRutTien = DataProvider.Ins.DB.PHIEURUTTIENs;
            var listPhieuGoiTien = DataProvider.Ins.DB.PHIEUGOITIENs;
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