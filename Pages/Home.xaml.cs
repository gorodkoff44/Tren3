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

namespace Tren3
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
        }

        private void BtnSklad_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/Pages/SkladPage.xaml", UriKind.RelativeOrAbsolute));
            NavigationService.Navigate(new SkladPage());
        }

        private void BtnStroy_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/Pages/StroyPage.xaml", UriKind.RelativeOrAbsolute));
            NavigationService.Navigate(new StroyPage());
        }

        //private void autorisebtn_Click(object sender, RoutedEventArgs e)
        //{
        //    Login login = new Login();
        //    login.Show();
        //}
    }
}
