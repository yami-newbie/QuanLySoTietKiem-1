using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLySoTietKiem.ViewModel
{
    public class RegisterViewModel:BaseViewModel
    {
        private LoginWindow _loginWindow;
        public LoginWindow LoginWindow { get => _loginWindow; set { _loginWindow = value; OnPropertyChanged(); } }
        public ICommand SignInCommand { get; set; }
        public ICommand DragMoveCommand { get; set; }
        public RegisterViewModel()
        {
            SignInCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Close();
                LoginWindow.Show();
            });
            DragMoveCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p != null) p.DragMove();

            });
        }
    }
}
