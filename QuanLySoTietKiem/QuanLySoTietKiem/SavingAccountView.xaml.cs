using QuanLySoTietKiem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLySoTietKiem
{
    /// <summary>
    /// Interaction logic for SavingAccountView.xaml
    /// </summary>
    public partial class SavingAccountView : UserControl
    {
        public SavingAccountView(NGUOIDUNG n)
        {
            InitializeComponent();
            DataContext = new ViewModel.SavingAccountViewModel(n);
        }
    }
}
