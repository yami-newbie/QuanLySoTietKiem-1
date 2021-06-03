using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace QuanLySoTietKiem
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public string _username;
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();

        }

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }



        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWD = new RegisterWindow();
            registerWD.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            _username = txtUser.Text;
        }
    }
}
