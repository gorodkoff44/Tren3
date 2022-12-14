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
    /// Логика взаимодействия для StroyPage.xaml
    /// </summary>
    public partial class StroyPage : Page
    {
        private TrenEntities _context = new TrenEntities();
        public StroyPage()
        {
            InitializeComponent();
            //Login login = new Login();
            //if (login.tlogin == 0)
            //{
            //    add.Visibility = Visibility.Collapsed;
            //    del.Visibility = Visibility.Collapsed;
            //}
            //else
            //{
            //    add.Visibility = Visibility.Visible;
            //    del.Visibility = Visibility.Visible;
            //}
            LVStroy.ItemsSource = _context.StroyMaterial.ToList();
        }
        private void UpdateStroy()
        {
            var currentStroy = _context.StroyMaterial.ToList();
            {
                currentStroy = currentStroy.FindAll(x => x.Name.Contains(SearchBox.Text));
                LVStroy.ItemsSource = currentStroy;
            }
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateStroy();
            if (SearchBox.Text == "")
            {
                rezsearchtb.Visibility = Visibility.Collapsed;
            }
            else
                rezsearchtb.Visibility = Visibility.Visible;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/Pages/AddStroyPage.xaml", UriKind.RelativeOrAbsolute));
            NavigationService.Navigate(new AddStroyPage(null));
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            _context.StroyMaterial.Remove((StroyMaterial)LVStroy.SelectedItem);
            _context.SaveChanges();
            UpdateStroy();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddStroyPage((sender as Button).DataContext as StroyMaterial));
        }

        private void btnUpd_Click(object sender, RoutedEventArgs e)
        {
            LVStroy.ItemsSource = _context.StroyMaterial.ToList();
        }
    }
}
