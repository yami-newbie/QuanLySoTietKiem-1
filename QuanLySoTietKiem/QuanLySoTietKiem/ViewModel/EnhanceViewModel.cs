using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
namespace QuanLySoTietKiem.ViewModel
{
    public class EnhanceViewModel : BaseViewModel
    {
        private String[] _backgroundColor = { "#D3DCD2", "", "",};
        public String[] BackgroundColor { get => _backgroundColor; set { _backgroundColor = value; OnPropertyChanged(); } }
        public ICommand UserCommand { get; set; }
        public ICommand CategoryCommand { get; set; }
        public ICommand MinimalDepositCommand { get; set; }
        private object _CurrentView { get; set; }
        public object CurrentView { get => _CurrentView; set { _CurrentView = value; OnPropertyChanged(); } }
        public EnhanceViewModel()
        {
            CurrentView = new CategoryView();
            CategoryCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                BackgroundColor = new String[] { "#D3DCD2", "", ""};
                CurrentView = new CategoryView();
            });
            UserCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                BackgroundColor = new String[] {  "", "#D3DCD2", ""};
            });
            MinimalDepositCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                BackgroundColor = new String[] {  "", "", "#D3DCD2" };
                CurrentView = new MinimalDepositView();
            });
        }
    }
}
