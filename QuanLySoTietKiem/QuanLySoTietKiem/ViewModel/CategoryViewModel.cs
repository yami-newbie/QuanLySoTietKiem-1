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
    public class CategoryViewModel: BaseViewModel
    {
        private ObservableCollection<LOAITIETKIEM> _List;
        public ObservableCollection<LOAITIETKIEM> List { get => _List; set { _List = value; OnPropertyChanged(); } }
        private ObservableCollection<string> _YesNo;
        public ObservableCollection<string> YesNo { get => _YesNo; set { _YesNo = value; OnPropertyChanged(); } }
        private string _SelectedYesNo;
        public string SelectedYesNo { get => _SelectedYesNo; set { _SelectedYesNo = value; OnPropertyChanged(); } }
        private LOAITIETKIEM _SelectedItem;
        public LOAITIETKIEM SelectedItem 
        {
            get => _SelectedItem; 
            set 
            { 
                _SelectedItem = value;
                OnPropertyChanged();
            } 
        }
        private bool _isKhongKiHan;
        public bool isKhongKiHan { get => _isKhongKiHan; set { _isKhongKiHan = value; OnPropertyChanged(); } }
        private string _TenLoaiTietKiem;
        public string TenLoaiTietKiem { get => _TenLoaiTietKiem; set { _TenLoaiTietKiem = value; OnPropertyChanged(); } }
        private string _ThoiGianGoiToiThieu;
        public string ThoiGianGoiToiThieu { get => _ThoiGianGoiToiThieu; set { _ThoiGianGoiToiThieu = value; OnPropertyChanged(); } }
        private string _LaiSuat;
        public string LaiSuat { get => _LaiSuat; set { _LaiSuat = value; OnPropertyChanged(); } }
        public ICommand AddFormCommand { get; set; }
        public ICommand EditFormCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand SaveAddCommand { get; set; }
        public ICommand SaveEditCommand { get; set; }
        public CategoryViewModel()
        {
            YesNo = new ObservableCollection<string> {"Có", "Không"};
            List = new ObservableCollection<LOAITIETKIEM>(DataProvider.Ins.DB.LOAITIETKIEMs.Where(x=>x.BiDong != true));
            AddFormCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ResetField();
                SelectedItem = null;
                AddCategoryView add = new AddCategoryView();
                add.ShowDialog();
            });
            DeleteCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (SelectedItem != null)
                {
                    var result = MessageBox.Show("Bạn có muốn xóa loại tiết kiệm  này không (Tất cả dữ liệu của loại tiết kiệm này vẫn sẽ tồn tại)?", "Xóa", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    if (result == MessageBoxResult.Yes)
                    {
                        var ltk = DataProvider.Ins.DB.LOAITIETKIEMs.Where(x => x.MaLoaiTietKiem == SelectedItem.MaLoaiTietKiem).SingleOrDefault();
                        ltk.BiDong = true;
                        DataProvider.Ins.DB.SaveChanges();
                        List.Remove(ltk);
                        MessageBox.Show("Xóa thành công!");
                        p.Close();
                    }
                }
            });
            EditFormCommand = new RelayCommand<object>((p) => { return (SelectedItem != null); }, (p) =>
            {

                if (SelectedItem != null)
                {
                    LaiSuat = SelectedItem.LaiSuat.ToString();
                    isKhongKiHan = SelectedItem.TenLoaiTietKiem == "Không kì hạn";
                    ThoiGianGoiToiThieu = SelectedItem.ThoiGianGoiToiThieu.ToString();
                    SelectedYesNo = (bool)SelectedItem.PhaiRutToanBo ? "Có" : "Không";
                }
                EditCategoryView edit = new EditCategoryView();
                edit.ShowDialog();
            });
            ExitCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Close();
            });
            SaveAddCommand = new RelayCommand<object>(
                (p) => 
                {
                    return isValidatedAdd();
                },
                (p) =>
                {
                    int time = int.Parse(ThoiGianGoiToiThieu);
                    decimal laiSuat = decimal.Parse(LaiSuat);
                    bool rutHet = SelectedYesNo == "Có";
                    var ltk = new LOAITIETKIEM() { BiDong = false, TenLoaiTietKiem = TenLoaiTietKiem, LaiSuat = laiSuat, ThoiGianGoiToiThieu = time, PhaiRutToanBo = rutHet };
                    DataProvider.Ins.DB.LOAITIETKIEMs.Add(ltk);
                    DataProvider.Ins.DB.SaveChanges();
                    List.Add(ltk);
                    MessageBox.Show("Thêm thành công!");
                    ResetField();
                });
            SaveEditCommand = new RelayCommand<object>(
                (p) =>
                {
                    return isValidatedEdit();
                },
                (p) =>
                {

                    decimal laiSuat = decimal.Parse(LaiSuat);
                    int time = int.Parse(ThoiGianGoiToiThieu);
                    var ltk = DataProvider.Ins.DB.LOAITIETKIEMs.Where(x => x.MaLoaiTietKiem == SelectedItem.MaLoaiTietKiem).SingleOrDefault();
                    ltk.LaiSuat = laiSuat;
                    DataProvider.Ins.DB.SaveChanges();
                    SelectedItem.LaiSuat = laiSuat;
                    for (int i = 0; i < List.Count; i++)
                    {
                        if (SelectedItem.MaLoaiTietKiem == List[i].MaLoaiTietKiem)
                        {
                            List[i] = new LOAITIETKIEM { MaLoaiTietKiem = List[i].MaLoaiTietKiem, SOTIETKIEMs = List[i].SOTIETKIEMs, TenLoaiTietKiem = List[i].TenLoaiTietKiem, ThoiGianGoiToiThieu = time, LaiSuat = laiSuat, PhaiRutToanBo = List[i].PhaiRutToanBo, BiDong = List[i].BiDong };
                            break;
                        }
                    }
                    
                    MessageBox.Show("Cập nhật thành công!");
                    (p as Window).Close();
                });
        }
        private bool isValidatedAdd()
        {
            if ((String.IsNullOrEmpty(TenLoaiTietKiem) || String.IsNullOrEmpty(ThoiGianGoiToiThieu) || String.IsNullOrEmpty(LaiSuat) || String.IsNullOrEmpty(SelectedYesNo))) return false;
            if (decimal.TryParse(LaiSuat, out decimal res) == false || int.TryParse(ThoiGianGoiToiThieu, out int res1) == false) return false;
            return true;
        }
        private bool isValidatedEdit()
        {
            if (SelectedItem == null) return false;
            if (String.IsNullOrEmpty(LaiSuat) || String.IsNullOrEmpty(ThoiGianGoiToiThieu)) return false;
            if (decimal.TryParse(LaiSuat, out decimal res) == false || int.TryParse(ThoiGianGoiToiThieu, out int res1) == false) return false;
            if (!isKhongKiHan) 
            { 
                if (SelectedItem.LaiSuat == res) return false;
            }
            else
            {
                if (SelectedItem.LaiSuat == res && SelectedItem.ThoiGianGoiToiThieu == res1) return false; 
            }
            return true;
        }
        private void ResetField()
        {
            TenLoaiTietKiem = "";
            ThoiGianGoiToiThieu = "";
            LaiSuat = "";
            SelectedYesNo = "";
        }
    }
}
