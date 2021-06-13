using QuanLySoTietKiem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLySoTietKiem.ViewModel
{
    class MinimalDepositInitViewModel : BaseViewModel
    {
        private string _MinimalInit;
        public string MinimalInit { get => _MinimalInit; set { _MinimalInit = value; OnPropertyChanged(); } }
        public ICommand SaveMinimalCommand { get; set; }
        public MinimalDepositInitViewModel()
        {
            MinimalInit = DataProvider.Ins.DB.THAMSOes.Where(x => x.Id == "1").SingleOrDefault().SoTienGoiBanDauToiThieu.ToString();
            SaveMinimalCommand = new RelayCommand<object>((p) => { return isValidate(); }, (p) =>
            {
                var thamSo = DataProvider.Ins.DB.THAMSOes.Where(x => x.Id == "1").SingleOrDefault();
                thamSo.SoTienGoiBanDauToiThieu = int.Parse(MinimalInit);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Cập nhật thành công");
               
            });
        }
        private bool isValidate()
        {
            if (int.TryParse(MinimalInit, out int res) == false) return false;
            if (String.IsNullOrEmpty(MinimalInit)) return false;
            if (res == DataProvider.Ins.DB.THAMSOes.Where(x => x.Id == "1").SingleOrDefault().SoTienGoiBanDauToiThieu) return false;
            return true;
        }
    }
}
