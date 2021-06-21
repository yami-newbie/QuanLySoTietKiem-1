using QuanLySoTietKiem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

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

        public ReportViewModel()
        {

            List1 = new ObservableCollection<ThongKe1>();
            List2 = new ObservableCollection<ThongKe2>();
            ListLoaiTietKiem = new ObservableCollection<LOAITIETKIEM>(DataProvider.Ins.DB.LOAITIETKIEMs);
            ListSTK = new ObservableCollection<SOTIETKIEM>(DataProvider.Ins.DB.SOTIETKIEMs);
            ListGoiTien = new ObservableCollection<PHIEUGOITIEN>(DataProvider.Ins.DB.PHIEUGOITIENs);
            ListRutTien = new ObservableCollection<PHIEURUTTIEN>(DataProvider.Ins.DB.PHIEURUTTIENs);
        }
        public void CheckDateIn()
        {
            List1.Clear();
            int i = 0;
            if (ListLoaiTietKiem.Count() > 0)
                foreach (var _ltk in ListLoaiTietKiem)
                {
                    i++;
                    List1.Add(new ThongKe1 { STT = i, LoaiTietKiem = _ltk.TenLoaiTietKiem, TongThu = (int)TongTienGoi1Ngay(_ltk.TenLoaiTietKiem), TongChi = (int)TongTienRut1Ngay(_ltk.TenLoaiTietKiem), ChenhLech = (int)TongTienGoi1Ngay(_ltk.TenLoaiTietKiem) - (int)TongTienRut1Ngay(_ltk.TenLoaiTietKiem) });
                }
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
            int sumTongSoMo = 1;
            int sumTongSoDong = 1;
            int stt = 0;
            var listSoMo = new ObservableCollection<SOTIETKIEM>(DataProvider.Ins.DB.SOTIETKIEMs.Where(x => x.LOAITIETKIEM.TenLoaiTietKiem == strLoaiTietKiem && x.NgayMoSo.Value.Month == soThang && x.NgayMoSo.Value.Year == soNam).OrderBy(v => v.NgayMoSo));
            var listSoDong = new ObservableCollection<SOTIETKIEM>(DataProvider.Ins.DB.SOTIETKIEMs.Where(x => x.LOAITIETKIEM.TenLoaiTietKiem == strLoaiTietKiem && x.NgayTinhLaiGanNhat.Value.Month == soThang && x.NgayTinhLaiGanNhat.Value.Year == soNam && x.BiXoa == true).OrderBy(v => v.NgayTinhLaiGanNhat));
            //  var listSoMo = (ObservableCollection<SOTIETKIEM>)ListSTK.Where(x => x.LOAITIETKIEM.TenLoaiTietKiem == strLoaiTietKiem && x.NgayMoSo.Value.Month==soThang &&x.BiXoa!=true).OrderBy(v=>v.NgayMoSo);
            // var listSoDong = ListSTK.Where(x => x.LOAITIETKIEM.TenLoaiTietKiem == strLoaiTietKiem && x.NgayTinhLaiGanNhat.Value.Month == soThang &&x.BiXoa==true).OrderBy(v => v.NgayTinhLaiGanNhat);
            List3 = new ObservableCollection<ThongKe2>();

            for (int i = 0; i < listSoMo.Count(); i++)
            {
                if (i != listSoMo.Count() - 1 && listSoMo[i].NgayMoSo.Value.Day == listSoMo[i + 1].NgayMoSo.Value.Day)
                {
                    sumTongSoMo += 1;
                }
                else
                {
                    if (i == listSoMo.Count() - 1)
                    {
                        stt++;
                        List3.Add(new ThongKe2 { STT = stt, Ngay = (DateTime)listSoMo[i].NgayMoSo, SoMo = sumTongSoMo, SoDong = 0, ChenhLech2 = 0 });
                        sumTongSoMo = 1;
                    }
                    else
                    {
                        stt++;
                        List3.Add(new ThongKe2 { STT = stt, Ngay = (DateTime)listSoMo[i].NgayMoSo, SoMo = sumTongSoMo, SoDong = 0, ChenhLech2 = 0 });
                        sumTongSoMo = 1;
                    }

                }
            }
            for (int i = 0; i < listSoDong.Count(); i++)
            {

                if (i != listSoDong.Count() - 1 && listSoDong[i].NgayTinhLaiGanNhat.Value.Day == listSoDong[i + 1].NgayTinhLaiGanNhat.Value.Day)
                {
                    sumTongSoDong += 1;
                }
                else
                {
                    if (i == listSoDong.Count() - 1)
                    {
                        stt++;
                        List3.OrderBy(v => v.Ngay.Date);
                        List3.Add(new ThongKe2 { STT = stt, Ngay = (DateTime)listSoDong[i].NgayTinhLaiGanNhat, SoMo = 0, SoDong = sumTongSoDong, ChenhLech2 = 0 });
                        sumTongSoDong = 1;
                    }
                    else
                    {
                        stt++;
                        List3.OrderBy(v => v.Ngay.Date);
                        List3.Add(new ThongKe2 { STT = stt, Ngay = (DateTime)listSoDong[i].NgayTinhLaiGanNhat, SoMo = 0, SoDong = sumTongSoDong, ChenhLech2 = 0 });
                        sumTongSoDong = 1;
                    }

                }
            }
            for (int i = 0; i < List3.Count(); i++)
            {
                for (int j = i + 1; j < List3.Count(); j++)
                {
                    if (List3[i].Ngay.Date == List3[j].Ngay.Date)
                    {
                        List3[i].SoDong = List3[j].SoDong;

                        List3.RemoveAt(j);

                    }
                }
            }
            //Tinh chenh lech
            for (int i = 0; i < List3.Count(); i++)
            {
                List3[i].ChenhLech2 = Math.Abs(List3[i].SoMo - List3[i].SoDong);
            }
            //Sap xep theo ngay
            for (int i = 0; i < List3.Count(); i++)
            {
                for (int j = 0; j < List3.Count() - 1; j++)
                {
                    if (List3[j].Ngay.Date > List3[j + 1].Ngay.Date)
                    {
                        var c = List3[j];
                        List3[j] = List3[j + 1];
                        List3[j + 1] = c;
                    }
                }
            }
            for (int i = 0; i < List3.Count(); i++)
            {
                List3[i].STT = i + 1;
            }
            if (List3.Count() == 0)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị");
            }
            List2 = List3;

            /* foreach(var item in listSTK2)
             {

                 DateTime ngayMoSo = (DateTime)item.NgayMoSo;
                 //var formatngayTinhLaiGanNhat = String.Format("{0:d}", ngayTinhLaiGanNhat);
                 if (ngayMoSo.Month == soThang)
                 {
                     stt++;
                     List2.Add(new ThongKe2 { STT = stt, Ngay= ngayMoSo,SoMo = item.MaSo.ToString(), SoDong = "Null", ChenhLech2 = 0 });
                 }
             }
             foreach (var item in listSTK2)
             {
                 DateTime ngayTinhLaiGanNhat = (DateTime)item.NgayTinhLaiGanNhat;
                 //var formatngayTinhLaiGanNhat = String.Format("{0:d}", ngayTinhLaiGanNhat);
                 if (ngayTinhLaiGanNhat.Month == soThang&&item.BiXoa==true)
                 {
                     stt++;
                     List2.Add(new ThongKe2 { STT = stt, Ngay = ngayTinhLaiGanNhat, SoMo = "Null", SoDong = item.MaSo.ToString(), ChenhLech2 = 0 });
                 }
             }*/


            /*  for (int i=0;i<ListSTK.Count();i++)
              {
                  DateTime ngayMoSo = (DateTime)ListSTK[i].NgayMoSo;
                  var formatngayMoSo = String.Format("{0:d}", ngayMoSo);
                  DateTime ngayTinhLaiGanNhat = (DateTime)ListSTK[i].NgayTinhLaiGanNhat;
                  var formatngayTinhLaiGanNhat = String.Format("{0:d}", ngayTinhLaiGanNhat);
                  if ((ngayMoSo.Month == soThang||(ngayTinhLaiGanNhat.Month==soThang&& ListSTK[i].BiXoa==true))&&ListSTK[i].LOAITIETKIEM.TenLoaiTietKiem==strLoaiTietKiem)
                  {
                      for(int j=i;j<ListSTK.Count();j++)
                      {
                          DateTime ngayMoSo2 = (DateTime)ListSTK[j].NgayMoSo;
                          var formatngayMoSo2 = String.Format("{0:d}", ngayMoSo2);
                          DateTime ngayTinhLaiGanNhat2 = (DateTime)ListSTK[j].NgayTinhLaiGanNhat;
                          var formatngayTinhLaiGanNhat2 = String.Format("{0:d}", ngayTinhLaiGanNhat2);

                          if (formatngayMoSo2==formatngayMoSo&&ListSTK[j].LOAITIETKIEM.TenLoaiTietKiem==strLoaiTietKiem)
                          {
                              MessageBox.Show("vo so mo" + "- thang:" + soThang);

                              sumTongSoMo += 1;
                          }
                          if((formatngayTinhLaiGanNhat2==formatngayTinhLaiGanNhat)&& ListSTK[j].BiXoa==true && ListSTK[j].LOAITIETKIEM.TenLoaiTietKiem == strLoaiTietKiem)
                          {
                              MessageBox.Show("vo so dong" + "- thang:" + soThang);

                              sumTongSoDong += 1;
                          }

                      }
                      if (sumTongSoMo != 0||sumTongSoDong!=0)
                      {
                          i++;
                          if(sumTongSoMo!=0 && sumTongSoDong==0)
                              List2.Add(new ThongKe2 { STT = i,Ngay=ngayMoSo ,SoMo = sumTongSoMo, SoDong = sumTongSoDong, ChenhLech2 = 0 });
                          else if(sumTongSoDong!=0 && sumTongSoMo == 0)
                          {
                              List2.Add(new ThongKe2 { STT = i,Ngay=ngayTinhLaiGanNhat, SoMo = sumTongSoMo, SoDong = sumTongSoDong, ChenhLech2 = 0 });
                          }
                          else
                              List2.Add(new ThongKe2 { STT = i, Ngay=ngayMoSo,SoMo = sumTongSoMo, SoDong = sumTongSoDong, ChenhLech2 = 0 });
                          sumTongSoDong = 0;
                          sumTongSoMo = 0;

                      }
                  }
              }*/
        }
        public int TongSoDong(string strLoaiTietKiem, int soThang)
        {
            int sumTongSo = 0;
            var inputSTK = ListSTK.Where(x => x.BiXoa == true);
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
        public DateTime Ngay { get; set; }
        public int SoMo { get; set; }
        public int SoDong { get; set; }
        public int ChenhLech2 { get; set; }

    }
}

