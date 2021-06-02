using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QuanLySoTietKiem.ViewModel
{
    public class LoginViewModel:BaseViewModel
    {
        public ICommand LoginCommand { get; set; }
        public bool IsLogin { get; set; }
        public LoginViewModel()
        {
            IsLogin = false;
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                IsLogin = true;
            });

        }
        public void Login(Window p)
        {
            if (p == null) return;
            IsLogin = true;
            p.Close();
        }
    }
}
