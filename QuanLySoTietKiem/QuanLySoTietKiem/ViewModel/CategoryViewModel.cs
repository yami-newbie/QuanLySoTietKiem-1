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
        private string _TenLoaiTietKiem;
        public string TenLoaiTietKiem { get => _TenLoaiTietKiem; set { _TenLoaiTietKiem = value; OnPropertyChanged(); } }
        private string _KiHan;
        public string KiHan { get => _KiHan; set { _KiHan = value; OnPropertyChanged(); } }
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
            List = new ObservableCollection<LOAITIETKIEM>(DataProvider.Ins.DB.LOAITIETKIEMs);
            AddFormCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ResetField();
                SelectedItem = null;
                AddCategoryView add = new AddCategoryView();
                add.ShowDialog();
            });
            EditFormCommand = new RelayCommand<object>((p) => { return (SelectedItem != null); }, (p) =>
            {
                if (SelectedItem != null)
                    LaiSuat = _SelectedItem.LaiSuat.ToString();
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
                    int kiHan = int.Parse(KiHan);
                    decimal laiSuat = decimal.Parse(LaiSuat);
                    var ltk = new LOAITIETKIEM() { BiXoa = false, TenLoaiTietKiem = TenLoaiTietKiem, LaiSuat = laiSuat, KyHan = kiHan };
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
                    var ltk = DataProvider.Ins.DB.LOAITIETKIEMs.Where(x => x.MaLoaiTietKiem == SelectedItem.MaLoaiTietKiem).SingleOrDefault();
                    ltk.LaiSuat = laiSuat;
                    DataProvider.Ins.DB.SaveChanges();
                    SelectedItem.LaiSuat = laiSuat;
                    for (int i = 0; i < List.Count; i++)
                    {
                        if (SelectedItem.MaLoaiTietKiem == List[i].MaLoaiTietKiem)
                        {
                            List[i] = new LOAITIETKIEM { MaLoaiTietKiem = List[i].MaLoaiTietKiem, SOTIETKIEMs = List[i].SOTIETKIEMs, TenLoaiTietKiem = List[i].TenLoaiTietKiem, KyHan = List[i].KyHan, LaiSuat = laiSuat };
                            break;
                        }
                    }
                    
                    MessageBox.Show("Cập nhật thành công!");
                    (p as Window).Close();
                });
        }
        private bool isValidatedAdd()
        {
            if ((String.IsNullOrEmpty(TenLoaiTietKiem) || String.IsNullOrEmpty(KiHan) || String.IsNullOrEmpty(LaiSuat))) return false;
            if (decimal.TryParse(LaiSuat, out decimal res) == false || int.TryParse(KiHan, out int res1) == false) return false;
            return true;
        }
        private bool isValidatedEdit()
        {
            if (SelectedItem == null) return false;
            if (String.IsNullOrEmpty(LaiSuat)) return false;
            if (decimal.TryParse(LaiSuat, out decimal res) == false) return false;
            if (SelectedItem.LaiSuat == res) return false;
                return true;
        }
        private void ResetField()
        {
            TenLoaiTietKiem = "";
            KiHan = "";
            LaiSuat = "";
        }
    }
}
